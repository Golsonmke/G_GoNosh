using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Nosh.Models
{
    public class FoodProfile
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CuisineType { get; set; }
        public int rating { get; set; }
        public  int Price_level { get; set; }
    }
}
