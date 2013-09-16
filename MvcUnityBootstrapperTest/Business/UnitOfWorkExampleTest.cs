using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcUnityBootstrapperTest.Logging;

namespace MvcUnityBootstrapperTest.Business
{
    public class UnitOfWorkExampleTest : IUnitOfWorkExample
    {
        static int _counter = 0; 
        public UnitOfWorkExampleTest()
        {
            _counter++;
            UnityEventLogger.Log.CreateUnityMessage("UnitOfWorkExampleTest " + _counter );
        }

        private bool _disposed = false;

        public void Dispose()
        {
            UnityEventLogger.Log.LogUnityMessage("Entered Dispose" + _counter);
            if (!_disposed)
            {
                _counter--;
                UnityEventLogger.Log.DisposeUnityMessage("UnitOfWorkExampleTest " + _counter);
                _disposed = true;
            }
        }

        public string HelloFromUnitOfWorkExample()
        {
            UnityEventLogger.Log.LogUnityMessage("Hello UnitOfWorkExampleTest " + _counter);
            return "HelloFromUnitOfWorkExample";
        }
    }
}