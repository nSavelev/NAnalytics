using System;

namespace NAnalytics.Runtime.Interfaces
{
    public interface IAnalyticProvider : IAnalyticEventSender, IDisposable
    {
        void Init();
        void SetGlobalParamsSetter(IAnalyticGlobalParamsSetter globalSetter);
    }
}