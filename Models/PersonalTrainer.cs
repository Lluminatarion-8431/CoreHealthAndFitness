using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Health_and_Fitness.Models
{
    public class PersonalTrainer
    {
        [Key]
        public int PersonalTrainerId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Address(required)")]
        public string AddressLine { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        [Display(Name = "List of Known health care physicians")]
        public string MedicalProviders { get; set; }

        public double Lat { get; set; }
        public double Long { get; set; }

        [Display(Name = "Calories")]
        public int CaloricIntake { get; set; }
        public int ProteinInGrams { get; set; }
        public int CarbohydratesInGrams { get; set; }
        public int FatInGram { get; set; }

        [Display(Name = "Monday")]
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednsday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


    }
}
