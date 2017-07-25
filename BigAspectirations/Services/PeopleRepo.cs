using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigAspectirations.Entities;
using Newtonsoft.Json;
using BigAspectirations.Logging;
using Microsoft.Extensions.Logging;

namespace BigAspectirations.Services
{
    public class PeopleRepo : IPeopleRepo
    {
        private readonly ILogger _logger;
        private static Dictionary<int, Person> _dataStore = new Dictionary<int, Person>()
        {
            [1] = new Person(1) { Age = 24, CoolnessFactor = 100000000, GeekFactor = 10, FirstName = "Ben", LastName = "Reeves", QualityIds = new List<int>() {1, 2, 3 } },
            [2] = new Person(2) { Age = 45, CoolnessFactor = -150, GeekFactor = 10, FirstName = "Mark", LastName = "Freydl", Notes = "Ben's Boss. Coolness Factor adjusted accordingly", QualityIds = new List<int> {3} },
            [3] = new Person(3) { Age = 35, CoolnessFactor = 30, GeekFactor = 5, FirstName = "Ron", LastName = "Burgundy", QualityIds = new List<int>() { 2 } },
            [4] = new Person(4) { Age = 65, CoolnessFactor = 15, GeekFactor = 10, FirstName = "Rick", LastName = "Sanchez"}
        };
        private readonly IQualitiesRepo _qualitiesRepo;

        public PeopleRepo(ILogger logger, IQualitiesRepo qualitiesRepo)
        {
            _logger = logger;
            _qualitiesRepo = qualitiesRepo;

        }
        public virtual void Delete(int id)
        {
            _dataStore.Remove(id);
        }

        public virtual Person Get(int id)
        {
            Person person = _dataStore[id];
            foreach (var qid in person.QualityIds)
            {
                person.Qualities.Add(_qualitiesRepo.Get(qid));
            }
            return person;
        }

        public virtual Person Create(Person newPerson)
        {
            _dataStore[newPerson.Id] = newPerson;
            return newPerson;
        }

        public virtual Person Update(Person toUpdate)
        {
            _dataStore[toUpdate.Id] = toUpdate;
            return toUpdate;
        }
    }
}
