using System.Collections.Generic;
using NAnalytics.Runtime.Interfaces;

namespace NAnalytics.Runtime
{
    public abstract class AbstractAnalyticsProvider : IAnalyticProvider
    {
        protected IAnalyticGlobalParamsSetter GlobalSetter { get; private set; }

        public virtual void SendEvent<TEvent>(TEvent @event) where TEvent : IAnalyticEvent
        {
            var name = GetEventName(@event);
            var paramsDictionary = GetEventParamsDictionary();
            GlobalSetter?.FillParams(paramsDictionary);
            @event.FillParams(paramsDictionary);
            SendEvent(name, paramsDictionary);
        }

        protected virtual Dictionary<string, object> GetEventParamsDictionary()
        {
            return new Dictionary<string, object>();
        }

        protected virtual string GetEventName<TEvent>(TEvent @event) where TEvent : IAnalyticEvent
        {
            return @event.Name;
        }

        protected abstract void SendEvent(string name, Dictionary<string, object> eventParams);

        public virtual void Dispose()
        {
        }

        public abstract void Init();

        public void SetGlobalParamsSetter(IAnalyticGlobalParamsSetter globalSetter)
        {
            GlobalSetter = globalSetter;
        }
    }
}