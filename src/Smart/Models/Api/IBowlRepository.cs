using SmartBowl;
using System.Collections.Generic;
namespace Smart.Models.Api
{
    public interface IBowlRepository
    {
        Bowl Add(Bowl item);
        IEnumerable<Bowl> GetAll();
        Bowl Find(int id);
        Bowl Remove(int id);
        void Update(Bowl item);

    }
}
