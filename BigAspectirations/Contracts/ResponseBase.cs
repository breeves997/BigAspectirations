using FSConnect.Accessories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations.Contracts
{
    public abstract class ResponseBase
    {
        public ServiceResult Result { get; set; }
    }
}
