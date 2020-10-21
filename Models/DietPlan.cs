using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Health_and_Fitness.Models
{
    public class DietPlan
    {
        [Key]
        public int DietPlanID { get; set; }

        [Display(Name = "Caloric Intake")]
        public int CaloricIntake { get; set; }

        [Display(Name = "Protein Intake(grams)")]
        public int Protein { get; set;}

        [Display(Name = "Carbohydrate Intake(grams)")]
        public int Carbohydrates { get; set; }

        [Display(Name = "Fat Intake(grams)")]
        public int Fat { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }
}
