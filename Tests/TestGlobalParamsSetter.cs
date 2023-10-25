using System.Collections.Generic;
using NAnalytics.Runtime.Interfaces;

namespace NAnalytics.Tests
{
    public class TestGlobalParamsSetter : IAnalyticGlobalParamsSetter
    {
        public void FillParams(Dictionary<string, object> eventParams)
        {
            eventParams["test_global1"] = 1;
            eventParams["test_global2"] = "global_str";
        }
    }
}