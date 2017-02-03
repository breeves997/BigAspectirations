using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations.Contracts
{
    public abstract class RequestBase
    {
        public object Payload { get; set; }

    }
}
