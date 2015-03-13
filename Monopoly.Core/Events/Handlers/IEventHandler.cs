namespace Monopoly.Core.Events.Handlers
{
    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        void Handle(TEvent value);
    } 
  
}