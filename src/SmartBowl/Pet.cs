using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SmartBowl
{
    public class Pet
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Breed { get; set; }

        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:n2}")]
        public decimal Weight { get; set; }

        [Display(Name = "Assigned Bowls")]
        public ICollection<BowlPet> BowlPet { get; set; }

    }
}
