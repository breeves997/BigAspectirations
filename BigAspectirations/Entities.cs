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
    public class Quality 
    {
        public Quality(int id)
        {
            Id = id;
        }
        public Quality() : this(0)
        {
            Id = Guid.NewGuid().GetHashCode();
        }
       public string Name { get; set; }
        public int Desirability { get; set; }
        public string Description { get; set; }
        public int Id { get; private set; }
    }

    public class Person 
    {
        public Person() : this(0)
        {
            Id = Guid.NewGuid().GetHashCode();
        }
        public Person(int id)
        {
            QualityIds = new List<int>();
            Qualities = new List<Quality>();
            Id = id;
        }
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public long CoolnessFactor { get; set; }
        public string Notes { get; set; }
        public List<int> QualityIds { get;  set;}
        public List<Quality> Qualities { get;  set;}
        public long GeekFactor { get;  set; }
    }
}
