using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBowl
{
    public class BowlPet
    {
        
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public int BowlId { get; set; }
        public Bowl Bowl { get; set; }

    }
}
