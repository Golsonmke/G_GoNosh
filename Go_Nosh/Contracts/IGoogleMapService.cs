using Go_Nosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Nosh.Contracts
{
    public interface IGoogleMapService
    {
        Task<FoodTruckAPI> GetFoodTruck();
        
    }
}
