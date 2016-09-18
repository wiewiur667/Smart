using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
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

        [JsonIgnore]
        public ICollection<BowlPet> BowlPet { get; set; }


        [NotMapped]
        public string GUID { get; set; }
        [NotMapped]
        public bool Locked { get; set; }
        [NotMapped]
        public bool Dispensing { get; set; }

        //public History FoodHistory { get; private set; }

        public Bowl() { }

        public Bowl(string name, string foodName, decimal foodAmount, decimal alertAmount)
        {
            Name = name;
            FoodName = foodName;
            FoodAmount = foodAmount;
            AlertAmount = alertAmount;
        }

        public void DispenseFood() { }
        public void Unlock() { }
        public void Lock() { }
        public void Reset() { }
        public void SendStatus() { }
    }
}
