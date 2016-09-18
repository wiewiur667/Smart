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

        public string Name { get; set; }

        public string Breed { get; set; }

        public decimal Weight { get; set; }

        [Display(Name = "Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Added Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Added { get; private set; }

        [JsonIgnore]
        [Display(Name = "Assigned Bowls")]
        public ICollection<BowlPet> BowlPet { get; set; }


        #region Methods
        public void SetAdded(DateTime added)
        {
            Added = added;

        }
        #endregion
    }
}
