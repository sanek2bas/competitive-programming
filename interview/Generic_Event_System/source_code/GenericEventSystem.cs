using Cysharp.Threading.Tasks;
using Mirror;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Forestline.Core.EventSystem
{
    public class GenericEventSystem : NetworkBehaviour
    {
        private const int TimeoutFrames = 600;

        private readonly SyncList<NetworkEvent> _events = new();

        private bool _isNetworkReady;

        public event Action<NetworkEvent> OnEventTriggered;

        private void Awake()
        {
            if (netIdentity == null)
            {
                Debug.LogError("GenericEventSystem: netIdentity отсутствует в Awake", this);
                return;
            }

            EnsureNetworkReady().Forget();
        }

        private async UniTask EnsureNetworkReady()
        {
            if (_isNetworkReady)
                return;

            if (netIdentity == null)
            {
                Debug.LogError("EnsureNetworkReady: netIdentity отсутствует", this);
                return;
            }

            var frameCount = 0;
            while ((NetworkServer.active || NetworkClient.active) && netIdentity.sceneId == 0)
            {
                if (frameCount >= TimeoutFrames)
                {
                    Debug.LogError(
                        $"EnsureNetworkReady: Таймаут ожидания sceneId. netId={netIdentity.netId}, sceneId={netIdentity.sceneId}, isServer={netIdentity.isServer}, isClient={netIdentity.isClient}");
                    return;
                }

                await UniTask.NextFrame();
                frameCount++;
            }

            _isNetworkReady = true;
        }

        private static byte[] SerializeToBinary(Dictionary<string, string> data)
        {
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream);

            writer.Write(data.Count);
            foreach (var kvp in data)
            {
                writer.Write(kvp.Key);
                writer.Write(kvp.Value);
            }

            return stream.ToArray();
        }

        public static Dictionary<string, string> DeserializeFromBinary(byte[] bytes)
        {
            var result = new Dictionary<string, string>();
            using var stream = new MemoryStream(bytes);
            using var reader = new BinaryReader(stream);

            var count = reader.ReadInt32();
            for (var i = 0; i < count; i++)
            {
                var key = reader.ReadString();
                var value = reader.ReadString();
                result[key] = value;
            }

            return result;
        }

        private static string SerializeToJson(Dictionary<string, string> data) => JsonConvert.SerializeObject(data);

        public static Dictionary<string, string> DeserializeFromJson(string json) =>
            JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        [Server]
        public async UniTaskVoid TriggerEventAsync(string eventType, string instigatorId, string instigatorType,
            Dictionary<string, string> eventData, bool useBinary = true)
        {
            await UniTask.WaitUntil(() => NetworkClient.isConnected);

            if (!_isNetworkReady || netIdentity == null)
                return;

            if (string.IsNullOrEmpty(eventType) || string.IsNullOrEmpty(instigatorId))
            {
                Debug.LogWarning("TriggerEventAsync: Неверный eventType или instigatorId");
                return;
            }

            var networkEvent = new NetworkEvent
            {
                EventType = eventType,
                InstigatorId = instigatorId,
                InstigatorType = instigatorType,
                Timestamp = DateTime.UtcNow
            };

            if (useBinary)
                networkEvent.RawData = SerializeToBinary(eventData);
            else
                networkEvent.EventDataJson = SerializeToJson(eventData);

            await EnsureNetworkReady();
            if (!_isNetworkReady || netIdentity == null || netIdentity.sceneId == 0)
            {
                Debug.LogWarning(
                    $"TriggerEventAsync: Network context не готов (isServer={netIdentity.isServer}, isClient={netIdentity.isClient}, netId={netIdentity.netId}, sceneId={netIdentity.sceneId}). Отказ от ивента.");
                return;
            }

            if (netIdentity.isClient && !NetworkClient.isConnected)
            {
                Debug.LogWarning("Клиент не подключен, событие не отправлено");
                return;
            }

            if (netIdentity.isServer || netIdentity.isClient && NetworkClient.isConnected)
                AddEvent(networkEvent);

            await UniTask.Yield();
        }

        [Server]
        private void AddEvent(NetworkEvent networkEvent)
        {
            if (!NetworkServer.active)
                return;

            if (netIdentity == null || netIdentity.netId == 0)
            {
                Debug.LogError(
                    $"CmdAddEvent: netIdentity не определена, netId={(netIdentity != null ? netIdentity.netId : null)}, sceneId={(netIdentity != null ? netIdentity.sceneId : null)}, isServer={(netIdentity != null ? netIdentity.isServer : null)}",
                    this);
                return;
            }

            if (string.IsNullOrEmpty(networkEvent.EventType) || string.IsNullOrEmpty(networkEvent.InstigatorId))
            {
                Debug.LogWarning("CmdAddEvent: Получены неверные данные ивента");
                return;
            }

            if (_events.Count >= 100)
                _events.RemoveAt(0);

            _events.Add(networkEvent);
            NotifyClientsRpc(networkEvent);

            if (NetworkServer.active && NetworkClient.active)
                OnEventTriggered?.Invoke(networkEvent);
        }

        [ClientRpc]
        private void NotifyClientsRpc(NetworkEvent networkEvent)
        {
            if (netIdentity == null)
            {
                Debug.LogError(
                    $"RpcNotifyClients: netIdentity не определена, netId={netIdentity?.netId}, sceneId={netIdentity?.sceneId}, isClient={netIdentity?.isClient}",
                    this);
                return;
            }

            if (NetworkServer.active)
                return;

            OnEventTriggered?.Invoke(networkEvent);
        }

        public Dictionary<string, string> GetEventData(NetworkEvent networkEvent)
        {
            if (string.IsNullOrEmpty(networkEvent.EventDataJson))
                return new Dictionary<string, string>();

            try
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(networkEvent.EventDataJson);
            }
            catch (Exception exception)
            {
                Debug.LogError($"Ошибка десереализации GetEventData: {exception.Message}");
                return new Dictionary<string, string>();
            }
        }

        public List<NetworkEvent> GetEvents()
        {
            if (NetworkServer.active || NetworkClient.active)
                return new List<NetworkEvent>(_events);

            Debug.LogWarning("GetEvents: Network context не активен. Возвращаем пустой список.");
            return new List<NetworkEvent>();
        }

        [Serializable]
        public struct NetworkEvent
        {
            public string EventType;
            public string InstigatorId;
            public string InstigatorType;
            public byte[] RawData;
            public string EventDataJson;
            public long TimestampTicks;

            [JsonIgnore]
            public DateTime Timestamp
            {
                get => new(TimestampTicks, DateTimeKind.Utc);
                set => TimestampTicks = value.Ticks;
            }
        }
    }
}