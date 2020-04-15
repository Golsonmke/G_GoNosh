using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Nosh.Models
{
    public class FoodTruck
    {
        private readonly string _key;

        public FoodTruck()
        {
            _key = Guid.NewGuid().ToString();
        }
        [Key]
        public string FoodTruckPrimaryKey { get; set; }

        public string FoodTruckName { get; set; }
        public string FoodTruckPhone { get; set; } // formatted phone
        public string Address{ get; set; }
        public int PriceRangeIndex { get; set; } // a value from 0-4
        public string WebsiteUrl { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public bool Open_now { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string MenuPic { get; set; }
        public string  FoodType { get; set; }
        public int Price_level { get; set; }
        public float Rating { get; set; }
        public string Place_Id { get; set; }
      
    }
}
