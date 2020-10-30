using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Health_and_Fitness.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Address(required)")]
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string FitnessGoal { get; set; }

        [Display(Name ="Weight goal time line (start date)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Weight goal time line (end date)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Ending weight")]
        public string WeightGoal { get; set; }

        [Display(Name = "Medical Provider (if applicable or N/A)")]
        public string MedicalProvider { get; set; }
        public string PastInjuries { get; set; }
        
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        

        [ForeignKey("PersonalTrainer")]
        [Display(Name = "Personal Trainers")]
        public int PersonalTrainerId { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }

        [NotMapped]
        public SelectList PersonalTrainers { get; set; }
    }
}
