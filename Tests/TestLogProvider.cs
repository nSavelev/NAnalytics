using System;
using System.Collections.Generic;
using System.Linq;
using NAnalytics.Runtime;
using UnityEngine;

namespace NAnalytics.Tests
{
    public class TestLogProvider : AbstractAnalyticsProvider
    {
        protected override void SendEvent(string name, Dictionary<string, object> eventParams)
        {
            Debug.Log($"[ANALYTICS] event: {name}, params: {DictToString(eventParams)}");
        }

        private string DictToString(Dictionary<string, object> evtParams)
        {
            return String.Join(";", evtParams.Select(e => $"{e.Key}:{e.Value}"));
        }

        public override void Init()
        {
        }
    }
}