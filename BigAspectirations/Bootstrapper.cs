using BigAspectirations.Interceptors;
//using Castle.DynamicProxy;
//using Castle.MicroKernel.Registration;
//using Castle.Windsor;
using System;
using FSConnect.Accessories;
using Q.Omni.Testing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSConnect.Accessories.Database;
using Q.Omni.Testing.Data;
using BigAspectirations.Entities;
using BigAspectirations.Services;
using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Interception.Infrastructure.Language;
using BigAspectirations.Logging;
using Castle.DynamicProxy;

namespace BigAspectirations
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {

            //Initialize repo
            MockRepo repo = new MockRepo();
            repo.MapRepoFor<People>(() => new MockRepoFor<People, int>(DataStore.PeopleRepo, new UseRandomIntIds("Pid")));
            repo.MapRepoFor<Qualities>(() => new MockRepoFor<Qualities, int>(DataStore.QualitiesRepo, new UseRandomIntIds("Pid")));

            //Inject standard repo into all classes which depend on ICrudCapable via constructor injection
            Bind<ICrudCapable>().ToConstant<MockRepo>(repo);
            //Inject repo with interception on qualities service. Ninject has overrides to make this smarter
            Bind<ICrudCapable>().ToConstant<MockRepo>(repo).WhenInjectedExactlyInto<QualitiesService>().Intercept().With<LoggerInterceptor>();
            //Inject standard service logger
            Bind<IServiceLogger>().To<ServiceLogger>();
            //I don't think this does anything since we never instantiate a concrete ServiceBase
            Bind<INullDependency>().ToMethod(ctx => null);

            //Give the people service self interception, meaning all it's method calls will hit the interceptor. NOTE we need to create a parameterless constructor for this to work.
            //Ninject is smart enough to call the base class constructor to inject the dependencies, then call the parameterless constructor so CastleWindsor can proxy it
            Bind(typeof(PeopleService)).ToSelf().Intercept().With<LoggerInterceptor>();
        }

    }
    public static class Bootstrapper
    {
        public static void Execute()
        {
            //Wire up dependencies based on ServiceModule's bindings
            IKernel kernel = new StandardKernel(new ServiceModule());
            ServiceBase.RepoIocContainer.InjectAs(() => kernel.Get<ICrudCapable>());
        }


    }
}
