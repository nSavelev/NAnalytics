using System.Collections.Generic;
using NAnalytics.Runtime;
using NAnalytics.Runtime.Interfaces;
using NUnit.Framework;
using UnityEngine;

namespace NAnalytics.Tests
{
    public struct TestEvent1 : IAnalyticEvent
    {
        public int Param1;
        public string Param2;
        public string Name => "test_1";
        public void FillParams(Dictionary<string, object> eventParams)
        {
            eventParams["e1_t1"] = Param1;
            eventParams["e1_t2"] = Param2;
        }
    }

    public struct TestEvent2 : IAnalyticEvent
    {
        public int Param1;
        public string Param2;
        public string Name => "test_2";
        public void FillParams(Dictionary<string, object> eventParams)
        {
            eventParams["e2_t1"] = Param1;
            eventParams["e2_t2"] = Param2;
        }
    }

    public class InterceptedProvider : TestLogProvider
    {
        public override void SendEvent<TEvent>(TEvent @event)
        {
            switch (@event)
            {
                case TestEvent2 evt2:
                    Debug.Log($"{evt2} intercepted");
                    var dict = GetEventParamsDictionary();
                    GlobalSetter.FillParams(dict);
                    dict["p1"] = evt2.Param1;
                    dict["p2"] = evt2.Param2;
                    SendEvent("intercepted_evt", dict);
                    break;
                default:
                    base.SendEvent(@event);
                    break;
            }
        }

        public override void Init()
        {
        }
    }
    
    public class AnalyticTests
    {
        private AnalyticService _service;

        [SetUp]
        public void Setup()
        {
            var globals = new TestGlobalParamsSetter();
            _service = new AnalyticService();
            var testLog = new TestLogProvider();
            testLog.SetGlobalParamsSetter(globals);
            var testExeption = new TestExceptionProvider();
            testExeption.SetGlobalParamsSetter(globals);
            var testInterception = new InterceptedProvider();
            testInterception.SetGlobalParamsSetter(globals);
            _service.AddProvider(testExeption);
            _service.AddProvider(testLog);
            _service.AddProvider(testInterception);
            _service.Init();
        }

        // Not passing in reason of Debug.LogException 
        [Test]
        public void Test1()
        {
            var evt = new TestEvent1()
            {
                Param1 = 123,
                Param2 = "param2"
            };
            _service.SendEvent(evt);
            var evt2 = new TestEvent2()
            {
                Param1 = 55,
                Param2 = "66"
            };
            _service.SendEvent(evt2);
        }
    }
}
