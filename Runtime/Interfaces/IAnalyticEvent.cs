using System.Collections.Generic;

namespace NAnalytics.Runtime.Interfaces
{
    public interface IAnalyticEvent
    {
        string Name { get; }
        void FillParams(Dictionary<string, object> eventParams);
    }
}