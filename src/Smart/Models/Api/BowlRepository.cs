using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using SmartBowl;

namespace Smart.Models.Api
{
    public class BowlRepository : IBowlRepository
    {
        private PetsDbContext _context;

        public BowlRepository() { }
        public BowlRepository(PetsDbContext context)
        {
            _context = context;
        }

        public Bowl Add(Bowl item)
        {
            _context.Bowl.Add(item);
            if (_context.SaveChanges() > 0)
            {
                return item;
            }
            return null;

        }

        public Bowl Find(int id)
        {
            return _context.Bowl.Include(a => a.BowlPet).SingleOrDefault(b => b.ID == id);
        }

        public IEnumerable<Bowl> GetAll()
        {
            return _context.Bowl.ToList();
        }

        public Bowl Remove(int id)
        {
            Bowl b = _context.Bowl.Include(a => a.BowlPet).First(a => a.ID == id);
            if (b != null)
            {
                _context.Bowl.Remove(b);
                _context.SaveChangesAsync();
                return b;
            }

            return null;
        }

        public async void Update(Bowl item)
        {
            try
            {
                var bowl = _context.Bowl.Include(a => a.BowlPet).SingleOrDefault(b => b.ID == item.ID);
                bowl.AlertAmount = item.AlertAmount;
                bowl.Dispensing = item.Dispensing;
                bowl.FoodAmount = item.FoodAmount;
                bowl.FoodName = item.FoodName;
                bowl.GUID = item.GUID;
                bowl.Location = item.Location;
                bowl.Locked = item.Locked;
                bowl.Name = item.Name;
                bowl.BowlPet = item.BowlPet;

                _context.Update(bowl);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {

            }
        }
    }
}

