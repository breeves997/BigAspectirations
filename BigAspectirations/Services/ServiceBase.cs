using BigAspectirations.Contracts;
using BigAspectirations.Logging;
using FSConnect.Accessories.Database;
using Q.Omni.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations.Services
{
    //public abstract class ServiceBase
    //{
    //    public ResponseBase Get(RequestBase request) { return this.GetAction(request); }

    //    protected abstract ResponseBase GetAction(RequestBase request);

    //    public  ResponseBase Post(RequestBase request) { return this.PostAction(request); }

    //    protected abstract ResponseBase PostAction(RequestBase request);

    //    public ResponseBase Put(RequestBase request) { return this.PutAction(request); }

    //    protected abstract ResponseBase PutAction(RequestBase request);

    //    public ResponseBase Delete(RequestBase request) { return this.DeleteAction(request); }

    //    protected abstract ResponseBase DeleteAction(RequestBase request);
    //}
    public abstract class ServiceBase : IService
    {
        public static InjectConfig<ICrudCapable> RepoIocContainer = new InjectConfig<ICrudCapable>();
        internal ICrudCapable Repo { get; set; }
        internal IServiceLogger Logger { get; set; }
        public ServiceBase(ICrudCapable repo, IServiceLogger logger)
        {
            this.Repo = repo ?? RepoIocContainer.Create() ;
            this.Logger = logger;
        }

        public ServiceBase() { }

        public T SetResultFor<T>(ServiceResult result) where T : ResponseBase, new()
        {
            T serviceResult = new T()
            {
                Result = result
            };
            return serviceResult;
        }

        public virtual void GetAction(RequestBase request)
        {
            Logger.LogTrace("Logging get");
        }


        public virtual void PostAction(RequestBase request) 
        {
            Logger.LogTrace("Logging post");
        }


        public virtual void PutAction(RequestBase request) 
        {
            Logger.LogTrace("Logging put");
        }


        public virtual void DeleteAction(RequestBase request) 
        {
            Logger.LogTrace("Logging delete");
        }
    }
}
