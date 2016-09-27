using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBowl
{
    public class Bowl
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Location { get; set; }

        [Display(Name = "Food Name")]
        public string FoodName { get; set; }

        [Display(Name = "Food Amount")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n2}")]
        public decimal FoodAmount { get; set; }

        [Display(Name = "Alert Amount")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n2}")]
        public decimal AlertAmount { get; set; }

        [Display(Name = "Assigned Pets")]
        public ICollection<BowlPet> BowlPet { get; set; }

        [NotMapped]
        public bool Locked { get; set; }
        [NotMapped]
        public bool Dispensing { get; set; }

    }
}
