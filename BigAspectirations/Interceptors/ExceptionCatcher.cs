using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations.Interceptors
{
    public class ExceptionCatcher : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured! Log this in your favourite logging format: {ex.GetType()} {ex.Message}");
                throw;
            }
        }
    }
}
