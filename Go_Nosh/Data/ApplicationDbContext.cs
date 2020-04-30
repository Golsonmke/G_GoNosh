using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Go_Nosh.Models;

namespace Go_Nosh.Data
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
                   Name = "Customer",
                   NormalizedName = "CUSTOMER"

               }
               );
            builder.Entity<IdentityRole>()
               .HasData(new IdentityRole
               {
                   Name = "Owner",
                   NormalizedName = "OWNER"

               }
               );



        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FoodTruck> FoodTrucks { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Go_Nosh.Models.FoodTruckAPI> FoodTruckAPI { get; set; }


    }
}
