using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Nosh.Models
{
    public class Customer
    {
        private readonly string _key;

        public Customer()
        {
            _key = Guid.NewGuid().ToString();
        }


        [Key]
        public string CustomerPrimaryKey { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Zipcode { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public int ZipCode { get; set; }
        public string FavoriteFood { get; set; }




    }
}
