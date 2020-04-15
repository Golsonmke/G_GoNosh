using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Nosh.Models
{
    public class Owner
    {
        private readonly string _key;

        public Owner()
        {
            _key = Guid.NewGuid().ToString();
        }
        [Key]
        public int OwnerPrimary{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int  ZipCode { get; set; }
        

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public int FoodTruckPrimarayKey{ get; set; }


    }
}

