using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models.Api.Interfaces;
using SmartBowl;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Smart.Models.Api
{
    public class BowlRepository : IBowlRepository
    {
        private PetsDbContext _context;
        
        public BowlRepository(PetsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Bowl> Get()
        {
            return _context.Bowl
                .Include(a => a.BowlPet)
                .ThenInclude(a => a.Pet)
                .ToList();
        }


        public Bowl GetBowl(int id)
        {
            return _context.Bowl
                .Include(a=> a.BowlPet)
                .ThenInclude(b => b.Pet)
                .FirstOrDefault(c=>c.ID == id);
        }

        public Bowl AddBowl(Bowl bowl)
        {
            _context.Bowl.Add(bowl);
            _context.SaveChanges();
            return bowl;
        }

        public Bowl Update(int id, Bowl bowl)
        {
            var entity = GetBowl(id);

            if(entity != null)
            {
                entity.AlertAmount  = bowl.AlertAmount;
                entity.BowlPet      = bowl.BowlPet;
                entity.Dispensing   = bowl.Dispensing;
                entity.FoodAmount   = bowl.FoodAmount;
                entity.FoodName     = bowl.FoodName;
                entity.Location     = bowl.Location;
                entity.Name         = bowl.Name;

                _context.SaveChanges();
                return bowl;
            }
            return null;
        }

        public Bowl AddPet(int id, Pet pet)
        {
            var entity = GetBowl(id);

            if(entity!= null)
            {
                _context.Pet.Include(a => a.BowlPet).FirstOrDefault(b => b.ID == pet.ID);
                return entity;
            }

            return null;
        }

        public Bowl Delete(int id)
        {
            var entity = GetBowl(id);
            if(entity != null)
            {
                _context.Set<Bowl>().Remove(entity);
                _context.SaveChanges();
            }

            return entity;
        }

        public void LockBowl(int id, bool locked)
        {
            var entity = GetBowl(id);
            if(entity != null)
            {
                entity.Locked = locked;
                _context.Bowl.Update(entity);
                _context.SaveChanges();
            }
        }

        public void Dispense(int id, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
