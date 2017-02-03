using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigAspectirations.Contracts;
using FSConnect.Accessories.Database;
using BigAspectirations.Entities;
using Newtonsoft.Json;
using BigAspectirations.Logging;

namespace BigAspectirations.Services
{
    public class PeopleService : ServiceBase
    {
        public PeopleService(ICrudCapable repo, IServiceLogger logger, INullDependency nullable) : 
            base(repo, logger)
        {
            string s = "something";
        }
        protected PeopleService() : this(null, null, null)
        {
            string p = "something";
        }
        public virtual PeopleResponse Delete(PeopleRequest request)
        {
            base.DeleteAction(request);
            var result = Repo.TryDelete<People>(request.Pid);
            return base.SetResultFor<PeopleResponse>(result);
        }

        public virtual PeopleResponse Get(PeopleRequest request)
        {
            base.GetAction(request);
            People fetched;
            var result = Repo.TryGet<People>(request.Pid, out fetched);
            return base.SetResultFor<PeopleResponse>(result);
        }

        public virtual PeopleResponse Post(PeopleRequest request)
        {
            base.PostAction(request);
            People saved;
            var json = JsonConvert.SerializeObject(request);
            People entity = JsonConvert.DeserializeObject<People>(json);
            var result = Repo.TryInsert<People>(entity, out saved);
            return base.SetResultFor<PeopleResponse>(result);
        }

        public virtual PeopleResponse Put(PeopleRequest request)
        {
            base.PutAction(request);
            People saved;
            var json = JsonConvert.SerializeObject(request);
            People entity = JsonConvert.DeserializeObject<People>(json);
            var result = Repo.TrySave<People>(entity, out saved);
            return base.SetResultFor<PeopleResponse>(result);
        }
    }
}
