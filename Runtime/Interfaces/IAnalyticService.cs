namespace NAnalytics.Runtime.Interfaces
{
    public interface IAnalyticService : IAnalyticEventSender
    {
        bool IsInitialized { get; }
        void Init();
        void AddProvider(IAnalyticProvider provider);
    }
}