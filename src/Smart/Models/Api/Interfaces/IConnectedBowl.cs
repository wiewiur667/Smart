using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models.Api.Interfaces
{
    public interface IConnectedBowl
    {
        bool GetStatus(int id);
        bool Lock(int id);
        bool Unlock(int id);
        decimal SetFoodAmount(decimal amount);
        decimal SetAlarmAmount(decimal amount);
    }
}
