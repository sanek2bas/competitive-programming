using System;
using System.Collections.Generic;
using Forestline.UI;
using Newtonsoft.Json;
using UnityEngine;

namespace Forestline.Core.EventSystem
{
    public abstract class UIEventHandler : IEventHandler
    {
        protected readonly IUIService _uiService;
        private readonly UIMessageType _messageType;

        protected UIEventHandler(IUIService uiService) => _uiService = uiService;

        protected UIEventHandler(IUIService uiService, UIMessageType messageType = UIMessageType.Toast)
        {
            _uiService = uiService;
            _messageType = messageType;
        }

        public abstract bool CanHandle(GenericEventSystem.NetworkEvent networkEvent);

        public virtual void Handle(GenericEventSystem.NetworkEvent networkEvent)
        {
            // Подготавливаем данные
            var eventData = DeserializeEventData(networkEvent);
            var messageText = GetMessageText(networkEvent, eventData);

            object payload = _messageType switch
            {
                UIMessageType.Toast => messageText, // string → для UIMessageToast

                UIMessageType.Dialog => new DialogPayload
                {
                    Message = messageText,
                    Title = GetTitleText(networkEvent, eventData),
                    OnSubmit = Submit()
                },

                _ => throw new ArgumentOutOfRangeException()
            };

            // Спавним с payload — всё остальное делает система!
            UIItem uiItem = _messageType switch
            {
                UIMessageType.Toast => _uiService.SpawnUIItem<UIMessageToast>(payload),
                UIMessageType.Dialog => _uiService.SpawnUIItem<UIMessageDialog>(payload),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (uiItem == null)
            {
                Debug.LogWarning($"{GetType().Name}: {_messageType} добавлен в очередь (лимит достигнут)");
                // ← Это нормально! Он появится позже с правильными данными
                return;
            }

            Debug.Log($"{GetType().Name}: {_messageType} показан сразу: \"{messageText}\"");
        }

        protected Dictionary<string, string> DeserializeEventData(GenericEventSystem.NetworkEvent networkEvent)
        {
            if (networkEvent.RawData is { Length: > 0 })
            {
                try { return GenericEventSystem.DeserializeFromBinary(networkEvent.RawData); }
                catch (Exception ex) { Debug.LogError($"Десериализация RawData ошибка: {ex.Message}"); }
            }
            else if (!string.IsNullOrEmpty(networkEvent.EventDataJson))
            {
                try { return GenericEventSystem.DeserializeFromJson(networkEvent.EventDataJson); }
                catch (JsonException ex) { Debug.LogError($"Десериализация JSON ошибка: {ex.Message}"); }
            }

            return new Dictionary<string, string>();
        }

        protected virtual string GetMessageText(GenericEventSystem.NetworkEvent networkEvent,
                Dictionary<string, string> eventData)
        {
            throw new NotImplementedException($"GetMessageText не реализован в {GetType().Name}");
        }
        protected virtual string GetTitleText(GenericEventSystem.NetworkEvent networkEvent, 
            Dictionary<string, string> eventData) => string.Empty;

        protected virtual Action Submit() => null;
    }

    public enum UIMessageType
    {
        Toast,
        Dialog
    }
}