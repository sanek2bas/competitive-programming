namespace Forestline.Core.EventSystem
{
    public interface IEventHandler
    {
        bool CanHandle(GenericEventSystem.NetworkEvent networkEvent);
        void Handle(GenericEventSystem.NetworkEvent networkEvent);
    }
}