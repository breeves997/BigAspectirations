using BigAspectirations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations.Contracts
{
    public class PeopleRequest : RequestBase 
    {
        public PeopleRequest()
        {
            Qualities = new List<QualitiesResponse>();
        }
        public long Pid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public long CoolnessFactor { get; set; }
        public long GeekFactor { get; set; }
        public string Notes { get; set; }
        List<QualitiesResponse> Qualities { get;  set;}
    }

    public class PeopleResponse : ResponseBase
    {
        public PeopleResponse()
        {
            Qualities = new List<QualitiesResponse>();
        }
        public long Pid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public long CoolnessFactor { get; set; }
        public long GeekFactor { get; set; }
        public string Notes { get; set; }
        List<QualitiesResponse> Qualities { get;  set;}
    }
}
