using Microsoft.AspNetCore.Identity;
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

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("PersonalTrainer")]
        public int PersonalTrainerId { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }

        [ForeignKey("ClientProfileId")]
        public int ClientProfileId { get; set; }
        public ClientProfile ClientProfile { get; set; }
    }
}
