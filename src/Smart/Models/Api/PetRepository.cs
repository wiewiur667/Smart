using Smart.Models.Api.Interfaces;
using System;
using System.Collections.Generic;

using SmartBowl;
using Smart.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Smart.Models.Api
{
    public class PetRepository : IPetRepository
    {

        private PetsDbContext _context;

        public PetRepository(PetsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pet> Get()
        {
            return _context.Pet
                .Include(a => a.BowlPet)
                .ThenInclude(b=> b.Bowl)
                .ToList();
        }

        public Pet GetPet(int id)
        {
            return _context.Pet
                .Include(a => a.BowlPet)
                .ThenInclude(b => b.Bowl)
                .FirstOrDefault(b => b.ID == id);
        }

        public Pet AddPet(Pet pet)
        {
            _context.Pet.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        public Pet Update(int id, Pet pet)
        {
            var entity = GetPet(id);

            if (entity != null)
            {
                entity.Name = pet.Name;
                entity.Breed = pet.Breed;
                entity.Weight = pet.Weight;
                entity.BowlPet = pet.BowlPet;

                _context.SaveChanges();

                return entity;
            }
            return null;
        }

        public Pet AddBowl(int id, Bowl bowl)
        {
            throw new NotImplementedException();
        }

        public Pet Delete(int id)
        {
            var entity = GetPet(id);
            if(entity != null)
            {
                _context.Pet.Remove(entity);
                _context.SaveChanges();
            }

            return entity;
            
        }

        

        

        
    }
}
