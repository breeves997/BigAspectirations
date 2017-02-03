using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations.Contracts
{
    public class QualitiesRequest : RequestBase
    {
        public string Name { get; set; }
        public int Desirability { get; set; }
        public string Description { get; set; }

        public long Pid { get; set; }

    }

    public class QualitiesResponse : ResponseBase
    {
        public string Name { get; set; }
        public int Desirability { get; set; }
        public string Description { get; set; }

        public long Pid { get; set; }


    }
}
