using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Extensions.Interception;
//using Castle.DynamicProxy;

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

            invocation.Proceed();

            Console.WriteLine(invocation.ReturnValue);
        }
    }
//#region Standard logging interceptor

//public class LogInterceptor : SimpleInterceptor {

//    private readonly ILogger _logger;

//    public LogInterceptor(ILogger logger) {

//        _logger = logger;
//    }

//    protected override void BeforeInvoke(IInvocation invocation) {

//    }

//    protected override void AfterInvoke(IInvocation invocation) {

//        _logger.ForContext(invocation.Request.Target.GetType())
//            .Information("Method: {Name} called with arguments {@Arguments} returned {@ReturnValue}",
//                invocation.Request.Method.Name,
//                invocation.Request.Arguments,
//				invocation.ReturnValue);
//    }
//}

//#endregion

//#region Error logging interceptor

//public class LogErrorInterceptor : IInterceptor {

//    private readonly ILogger _logger;

//    public LogErrorInterceptor(ILogger logger) {

//        _logger = logger;
//    }

//    public void Intercept(IInvocation invocation) {

//        try {

//            invocation.Proceed();
//        }
//        catch (Exception exception) {

//            _logger.ForContext(invocation.Request.Target.GetType())
//                .Error(exception, "Error at Method: {@Name} Arguments: {@Arguments}",
//                    invocation.Request.Method.Name,
//                    invocation.Request.Arguments);

//            throw;
//        }
//    }
//}

//#endregion

//#region Timer interceptor

//public class TimerInterceptor : IInterceptor {

//    private readonly string _timerName;
//    private readonly ILogger _logger;

//    public TimerInterceptor(string timerName, ILogger logger) {

//        _timerName = timerName;
//        _logger = logger;
//    }

//    public void Intercept(IInvocation invocation) {

//        using (_logger.ForContext(invocation.Request.Target.GetType())
//            .BeginTimedOperation(_timerName, invocation.Request.Method.Name)) {
//            invocation.Proceed();
//        }
//    }
//}

//#endregion
}
