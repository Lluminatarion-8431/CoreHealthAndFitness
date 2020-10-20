﻿using System;
using System.Collections.Generic;
using System.Text;
using Core_Health_and_Fitness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core_Health_and_Fitness.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Name = "Client",
                    NormalizedName = "CLIENT"
                },
                new IdentityRole
                {
                    Name = "PersonalTrainer",
                    NormalizedName = "PERSONALTRAINER"
                }
            );
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainers { get; set; }
        public DbSet<WorkoutSchedule> WorkoutSchedule { get; set; }
        public DbSet<DietPlan> DietPlan { get; set; }
        public DbSet<ClientProfile> ClientProfile { get; set; }
    }
}
