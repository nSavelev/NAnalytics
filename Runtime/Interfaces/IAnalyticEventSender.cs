namespace NAnalytics.Runtime.Interfaces
{
    public interface IAnalyticEventSender
    {
        void SendEvent<TEvent>(TEvent @event) where TEvent : struct, IAnalyticEvent;
    }
}