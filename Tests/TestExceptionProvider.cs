using System;
using System.Collections.Generic;
using NAnalytics.Runtime;

namespace NAnalytics.Tests
{
    public class TestExceptionProvider : AbstractAnalyticsProvider
    {
        protected override void SendEvent(string name, Dictionary<string, object> eventParams)
        {
            throw new Exception(name);
        }

        public override void Init()
        {
        }
    }
}