using BigAspectirations.Interceptors;
//using Castle.DynamicProxy;
//using Castle.MicroKernel.Registration;
//using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigAspectirations.Entities;
using BigAspectirations.Services;
using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Interception.Infrastructure.Language;
using BigAspectirations.Logging;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace BigAspectirations
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {

            //One interceptor
            //Bind<IPeopleRepo>().To<PeopleRepo>().Intercept().With<LoggerInterceptor>();
            //Bind<IQualitiesRepo>().To<QualitiesRepo>().Intercept().With<LoggerInterceptor>();

            //multiple
            var bindingPeople = Bind<IPeopleRepo>().To<PeopleRepo>();
            bindingPeople.Intercept().With<LoggerInterceptor>().InOrder(1);
            bindingPeople.Intercept().With<ExceptionCatcher>().InOrder(2);
            var bindingQualities = Bind<IQualitiesRepo>().To<QualitiesRepo>();
            bindingQualities.Intercept().With<LoggerInterceptor>().InOrder(2);
            bindingQualities.Intercept().With<ExceptionCatcher>().InOrder(1);

            Bind<ILogger>().To<ServiceLogger>();

            //Give the people service self interception, meaning all it's method calls will hit the interceptor. NOTE we need to create a parameterless constructor for this to work.
            //Ninject is smart enough to call the base class constructor to inject the dependencies, then call the parameterless constructor so CastleWindsor can proxy it
            Bind(typeof(PeopleRepo)).ToSelf().Intercept().With<LoggerInterceptor>();
        }

    }
    public static class Bootstrapper
    {
        public static IKernel Kernel;
        public static void Execute()
        {
            //Wire up dependencies based on ServiceModule's bindings
            Kernel = new StandardKernel(new ServiceModule());
        }


    }
}
