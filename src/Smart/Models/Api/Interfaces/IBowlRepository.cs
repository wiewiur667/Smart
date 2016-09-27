using SmartBowl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models.Api.Interfaces
{
    public interface IBowlRepository
    {
        IEnumerable<Bowl> Get();
        Bowl GetBowl(int id);
        Bowl AddBowl(Bowl bowl);
        Bowl Update(int id, Bowl bowl);
        Bowl Delete(int id);
        void LockBowl(int id, bool locked);
        void Dispense(int id, decimal amount);

    }
}
