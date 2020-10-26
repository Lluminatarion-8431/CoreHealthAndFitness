using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Health_and_Fitness.Models
{
    public class ClientProfile
    {
        [Key]
        public int ClientProfileId { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Height")]
        public double Height { get; set; }

        [Display(Name = "Weight")]
        public double Weight { get; set; }

        [Display(Name = "Medical Provider")]
        public string MedicalProvider { get; set; }

        [Display(Name = "Past Injuries")]
        public string MedicalHistory { get; set; }

        [Display(Name = "Fitness Goal")]
        public string FitnessGoal { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("PersonalTrainer")]
        public int PersonalTrainerId { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }
    }
}
