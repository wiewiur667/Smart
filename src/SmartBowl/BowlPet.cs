using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBowl
{
    public class BowlPet
    {
        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        [ForeignKey("Bowl")]
        public int BowlId { get; set; }
        public Bowl Bowl { get; set; }

        public BowlPet() { }

        public BowlPet(Pet pet, Bowl bowl)
        {
            Pet = pet;
            PetId = pet.ID;

            Bowl = bowl;
            BowlId = bowl.ID;
        }

        public BowlPet(int petID, int bowlID)
        {
            PetId = petID;
            BowlId = bowlID;
        }

        public class BowlPetEqualityComparer : EqualityComparer<BowlPet>
        {
            public override bool Equals(BowlPet x, BowlPet y)
            {
                if (x == null && y == null) return true;
                else if (x == null || y == null) return false;

                if (x.BowlId == y.BowlId && x.PetId == y.PetId) return true;
                else return false;
            }

            public override int GetHashCode(BowlPet obj)
            {
                int h = obj.BowlId ^ obj.PetId;
                return h.GetHashCode();
            }
        }
    }
}
