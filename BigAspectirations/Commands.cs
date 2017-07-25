using BigAspectirations.Entities;
using BigAspectirations.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BigAspectirations.Commands
{
    public static class Commands
    {
        public static string DoSomething(int id, string data)
        {
            return string.Format(
                "I did something to the record Id {0} and save the data {1}", id, data);
        }


        public static string CreateQuality()
        {
            Quality quality = new Quality()
            {
                Name = "Great Dancer",
                Description = "He's got the moves like Jagger",
                Desirability = 70,
            };
            IQualitiesRepo svc = Bootstrapper.Kernel.Get<IQualitiesRepo>(); 
            var result = svc.Create(quality);
            return "Created new quality";
        }
        public static string DescribePerson(int id)
        {
            IPeopleRepo svc = Bootstrapper.Kernel.Get<IPeopleRepo>();
            Person person = svc.Get(id);
            var sb = new StringBuilder($"{person.FirstName} {person.LastName} is {person.Age} years old with {person.Qualities.Count} qualities. They are ");
            foreach (var q in person.Qualities)
            {
                sb.Append(q.Name + " " + q.Description + ", ");
            }
            sb.Length -= 2;
            sb.Append($". This results in a total awesome factor of {person.CoolnessFactor * person.GeekFactor + person.GeekFactor * person.Qualities.Sum(x => x.Desirability) }");
            return sb.ToString();
        }

    }
}
