using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Extensions.Interception;
using System.Diagnostics;

namespace BigAspectirations.Interceptors
{
    public class LoggerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Logger Interceptor called on method " + invocation.Request.Method.Name);
            StringBuilder sb = new StringBuilder();
            sb.Append("Logger interceptor picked up the following args: ");
            foreach (var arg in invocation.Request.Arguments)
            {
                if (arg == null) continue;
                sb.Append(arg?.GetType().Name);
                sb.Append(": ");
                sb.Append(arg?.ToString());
                sb.Append(", ");
            }
            Console.WriteLine(sb.ToString());

            var sw = new Stopwatch();
            sw.Start();
            invocation.Proceed();
            sw.Stop();
            Console.WriteLine("Executing action " + invocation.Request.Method.Name + " took " + sw.ElapsedMilliseconds + " ms.");
        }
    }
}
