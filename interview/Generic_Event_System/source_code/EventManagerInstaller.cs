namespace Forestline.Core.EventSystem
{
    public class EventManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EventManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

            Container.Bind<IEventHandler>().To<ExplosionUIEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<AgentDestructionUIEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<RegionPointsLostUIEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<ScenarioStatsUIEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<ScenarioCompletedUIEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<PlayerFailedUIEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<RegionCompletedUIEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<ConvoyPerishedUIEventHandler>().AsSingle();
            Container.BindInterfacesTo<MasterPlayerAssignedUIEventHandler>().AsSingle();

            Container.Bind<IEventHandler>().To<CannonAfterShotAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<StageValidationAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<DeathPlayerAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<CannonEmptyAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<PointsLostAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<AgentsDiedAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<MasterPlayerAssignedAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<RandomEventDroneAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<MineDetectorAssignedAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<MissionFailedAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<ConvoyPerishedAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<StageMineClearingAudioEventHandler>().AsSingle();
            Container.Bind<IEventHandler>().To<DroneDestroyedAudioEventHandler>().AsSingle();
        }
    }
}