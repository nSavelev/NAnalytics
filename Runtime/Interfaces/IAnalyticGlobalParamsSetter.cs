using System.Collections.Generic;

namespace NAnalytics.Runtime.Interfaces
{
    public interface IAnalyticGlobalParamsSetter
    {
        void FillParams(Dictionary<string, object> eventParams);
    }
}