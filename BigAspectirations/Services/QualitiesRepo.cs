using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigAspectirations.Entities;
using Microsoft.Extensions.Logging;

namespace BigAspectirations.Services
{
    public class QualitiesRepo : IQualitiesRepo
    {
        private readonly ILogger _logger;
        private static Dictionary<int, Quality> _dataStore = new Dictionary<int, Quality>()
        {
            [1] = new Quality(1) { Name = "Super good looking", Description = "like a sexy Ryan Reynolds", Desirability = 100, },
            [2] = new Quality(2) { Name = "Incredibly humble", Description = "", Desirability = 10},
            [3] = new Quality(3) { Name = "Awesome Developer", Description = "who writes code that would make a unicorn cry with joy", Desirability = 140},
        };

        public QualitiesRepo(ILogger logger)
        {
            _logger = logger;
        }
        public virtual void Delete(int id)
        {
            _dataStore.Remove(id);
        }

        public virtual Quality Get(int id)
        {
            return _dataStore[id];
        }

        public virtual Quality Create(Quality newQuality)
        {
            _dataStore[newQuality.Id] = newQuality;
            return newQuality;
        }

        public virtual Quality Update(Quality toUpdate)
        {
            _dataStore[toUpdate.Id] = toUpdate;
            return toUpdate;
        }
    }
}
