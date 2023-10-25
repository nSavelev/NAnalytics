using System;
using System.Collections.Generic;
using NAnalytics.Runtime.Interfaces;
using UnityEngine;

namespace NAnalytics.Runtime
{
    public class AnalyticService : IAnalyticService
    {
        public bool IsInitialized { get; private set; }

        private List<IAnalyticProvider> _providers = new();

        public void AddProvider(IAnalyticProvider provider)
        {
            _providers.Add(provider);
            if (IsInitialized)
            {
                provider.Init();
            }
        }

        public void SendEvent<TEvent>(TEvent @event) where TEvent : IAnalyticEvent
        {
            for (var i = 0; i < _providers.Count; i++)
            {
                try
                {
                    _providers[i].SendEvent(@event);
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }
        }

        public void Init()
        {
            for (var i = 0; i < _providers.Count; i++)
            {
                _providers[i].Init();
            }
        }
    }
}