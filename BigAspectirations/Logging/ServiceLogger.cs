using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations.Logging
{
    public class ServiceLogger : IServiceLogger
    {
        public void LogAndTriggerAlarm(Exception ex, string message)
        {
            throw new NotImplementedException();
        }

        public void LogAndTriggerAlarm(Exception ex, string messageTemplate, params object[] templateValues)
        {
            throw new NotImplementedException();
        }

        public void LogException(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void LogException(Exception ex, string message)
        {
            throw new NotImplementedException();
        }

        public void LogException(Exception ex, string messageTemplate, params object[] templateValues)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string messageTemplate, params object[] templateValues)
        {
            throw new NotImplementedException();
        }

        public void LogTrace(string message)
        {
            Console.WriteLine(message);
        }

        public void LogTrace(string messageTemplate, params object[] templateValues)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string messageTemplate, params object[] templateValues)
        {
            throw new NotImplementedException();
        }
    }
}
