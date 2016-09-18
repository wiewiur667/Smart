using SmartBowl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smart.Models.PetsViewModel
{
    public class StandardViewModel
    {
        public Pet Pet { get; set; }
        [Display(Name = "Bowls access")]
        public virtual ICollection<Bowl> Bowls { get; set; }

        public StandardViewModel()
        {
            Bowls = new List<Bowl>();
        }
        public StandardViewModel(Pet pet) : this()
        {
            Pet = pet;
        }

        public StandardViewModel(Pet pet, ICollection<Bowl> bowls)
        {
            Pet = pet;
            Bowls = bowls;
        }
    }
}
