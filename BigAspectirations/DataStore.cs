using BigAspectirations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations
{
    public static class DataStore
    {
        static DataStore()
        {
            PeopleRepo = new Dictionary<long, People>()
            {
                [1] = new People() { Pid = 1, Age = 24, CoolnessFactor = 100000000, GeekFactor = 450000, FirstName = "Ben", LastName = "Reeves" },
                [2] = new People() { Pid = 2, Age = 45, CoolnessFactor = -150, GeekFactor = 1000000, FirstName = "Mark", LastName = "Freydl", Notes = "Ben's Boss" },
                [3] = new People() { Pid = 3, Age = 35, CoolnessFactor = 30, GeekFactor = 1300000, FirstName = "Shawn", LastName = "Cutter" },
                [4] = new People() { Pid = 4, Age = 35, CoolnessFactor = 15, GeekFactor = 1000000, FirstName = "Matt", LastName = "Linder" }
            };

            QualitiesRepo = new Dictionary<long, Qualities>()
            {
                [1] = new Qualities() { Name = "Super good looking", Description = "Like a sexy Ryan Reynolds", Desirability = 100, Pid = 1 },
                [2] = new Qualities() { Name = "Has Tattoos", Description = "", Desirability = 40, Pid = 2 },
                [3] = new Qualities() { Name = "Awesome Developer", Description = "Writes code that would make a unicorn cry with joy", Desirability = 140, Pid = 3 },
            };
        }
        public static Dictionary<long, People> PeopleRepo { get; set; }
        public static Dictionary<long, Qualities> QualitiesRepo { get; set; }
    }
}
