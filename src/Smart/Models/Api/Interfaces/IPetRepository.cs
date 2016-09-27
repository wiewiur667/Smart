using SmartBowl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models.Api.Interfaces
{
    public interface IPetRepository
    {
        IEnumerable<Pet> Get();
        Pet GetPet(int id);
        Pet AddPet(Pet pet);
        Pet Update(int id, Pet pet);
        Pet Delete(int id);
        Pet AddBowl(int id, Bowl bowl);
    }
}
