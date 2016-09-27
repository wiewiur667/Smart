using Smart.Models.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models.Api
{
    public class ConnectedBowl : IConnectedBowl
    {

        public bool GetStatus(int id)
        { 
            throw new NotImplementedException();
        }

        public bool Lock(int id)
        {
            throw new NotImplementedException();
        }

        public decimal SetAlarmAmount(decimal amount)
        {
            throw new NotImplementedException();
        }

        public decimal SetFoodAmount(decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool Unlock(int id)
        {
            throw new NotImplementedException();
        }
    }
}
