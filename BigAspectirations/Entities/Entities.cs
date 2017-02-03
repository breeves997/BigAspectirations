using FSConnect.Accessories.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations.Entities
{
    /// <summary>
    /// Class that describes various qualities of individuals
    /// </summary>
    public class Qualities : IFSDomainEntity
    {
       public string Name { get; set; }
        public int Desirability { get; set; }
        public string Description { get; set; }

        public long Pid { get; set; }
    }

    public class People : IFSDomainEntity
    {
        public People()
        {
            Qualities = new List<Qualities>();
        }
        public long Pid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public long CoolnessFactor { get; set; }
        public string Notes { get; set; }
        List<Qualities> Qualities { get;  set;}
        public long GeekFactor { get;  set; }
    }
}
