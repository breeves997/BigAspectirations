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
    public class QualitiesService : ServiceBase
    {
        public QualitiesService(ICrudCapable repo, IServiceLogger logger) : base(repo, logger) { }
        public QualitiesResponse Delete(QualitiesRequest request)
        {
            base.DeleteAction(request);
            var result = Repo.TryDelete<Qualities>(request.Pid);
            return base.SetResultFor<QualitiesResponse>(result);
        }

        public QualitiesResponse Get(QualitiesRequest request)
        {
            base.GetAction(request);
            Qualities fetched;
            var result = Repo.TryGet<Qualities>(request.Pid, out fetched);
            return base.SetResultFor<QualitiesResponse>(result);
        }

        public QualitiesResponse Post(QualitiesRequest request)
        {
            base.PostAction(request);
            Qualities saved;
            var json = JsonConvert.SerializeObject(request);
            Qualities entity = JsonConvert.DeserializeObject<Qualities>(json);
            var result = Repo.TryInsert<Qualities>(entity, out saved);
            return base.SetResultFor<QualitiesResponse>(result);
        }

        public QualitiesResponse Put(QualitiesRequest request)
        {
            base.PutAction(request);
            Qualities saved;
            var json = JsonConvert.SerializeObject(request);
            Qualities entity = JsonConvert.DeserializeObject<Qualities>(json);
            var result = Repo.TrySave<Qualities>(entity, out saved);
            return base.SetResultFor<QualitiesResponse>(result);
        }

        //protected override ResponseBase DeleteAction(RequestBase request)
        //{
        //    return this.Delete(request);
        //}

        //protected override ResponseBase GetAction(RequestBase request)
        //{
        //    return this.Get(request);
        //}

        //protected override ResponseBase PostAction(RequestBase request)
        //{
        //    return this.Post(request);
        //}

        //protected override ResponseBase PutAction(RequestBase request)
        //{
        //    return this.Put(request);
        //}
    }
}
