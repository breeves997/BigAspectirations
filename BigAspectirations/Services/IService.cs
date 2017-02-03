using BigAspectirations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigAspectirations.Services
{
    public interface IService
    {
        void GetAction(RequestBase request);


        void PostAction(RequestBase request);


        void PutAction(RequestBase request);


        void DeleteAction(RequestBase request);
    }
}
