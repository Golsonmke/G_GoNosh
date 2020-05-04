using Go_Nosh.Contracts;
using Go_Nosh.Data;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Go_Nosh.Models;
using System.Collections.Generic;
using System.Linq;

namespace Go_Nosh.Services
{
    public class GoogleMapService : IGoogleMapService
    {

        ApplicationDbContext _context;


        public GoogleMapService(ApplicationDbContext context)
        {
            _context = context;
           
        }
     
        public async Task<FoodTruckAPI> GetFoodTrucks()
        {
            string url = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query=Foodtrucks+in+Milwaukee&key={API_KEY.googleMapsApiKey}";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                FoodTruckAPI foodTruckAPI = JsonConvert.DeserializeObject<FoodTruckAPI>(json);

                

                return foodTruckAPI;
                
            }
            else
            {
                return null;
            }
           
        }
        private void MapGoogleResultsToFoodTruckModel(FoodTruckAPI foodTruckAPI)
        {
           
           var foodTrucks = foodTruckAPI;

            foreach (Result res in foodTrucks.results)
            {
                //Turn each one of these messy arrays of info into an actual FoodTruck Object for your DB
                FoodTruck ft = new FoodTruck
                {
                    FoodTruckName = res.name,
                    FoodTruckPhone = res.plus_code.compound_code,
                    Lat = res.geometry.location.lat,
                    Lng = res.geometry.location.lng,
                    Address = res.formatted_address,
                    FoodType = res.types.ToString(),
                    Price_level = res.price_level,
                    Rating = res.rating,
                    Place_Id = res.place_id
                };
                //add all the properties one at a time.
                _context.FoodTrucks.Add(ft);
                
            }
             _context.SaveChanges();
        }
           


        private string TimeOfDayFoodType()
        {
            DateTime now = DateTime.Now;
            string breakfast, lunch, dinner;
            breakfast = "breakfast";
            lunch = "lunch";
            dinner = "dinner";




            var breakFastStart = "05:00:00";
            var breakFastEnd = "11:00:00";
            var lunchStart = "11:00:00";
            var lunchEnd = "16:00:00";
            var dinnerStart = "16:00:00";
            var dinnerEnd = "20:00:00";

            if ((DateTime.Parse(now.ToString("HH:mm:ss")) >= DateTime.Parse(breakFastStart)) && (DateTime.Parse(now.ToString("HH:mm:ss")) < DateTime.Parse(breakFastEnd)))//08:00:00
            {
                //make a breakfast query based on the criteria passsed in
                return breakfast;
            }
            else if ((DateTime.Parse(now.ToString("HH:mm:ss")) >= DateTime.Parse(lunchStart)) && (DateTime.Parse(now.ToString("HH:mm:ss")) < DateTime.Parse(lunchEnd)))//12:00:00
            {
                //make a lunch query based on the criteria passsed in
                return lunch;
            }
            else if ((DateTime.Parse(now.ToString("HH:mm:ss")) >= DateTime.Parse(dinnerStart)) && (DateTime.Parse(now.ToString("HH:mm:ss")) < DateTime.Parse(dinnerEnd))) //20:12:59
            {
                //make a dinner query based on the criteria passsed in
                return dinner;
            }
            else
            {
                return dinner;
            }
        }
       
        public List<FoodTruck> Recommendation(FoodTruck foodTruck, Customer customer)
        {
            List<FoodTruck> foodTrucks = new List<FoodTruck>();
            
            if ( foodTruck.FoodType == customer.FavoriteFood && foodTruck.Rating >= 4)
            {

                return foodTrucks.ToList(); 
            }
            else
            {
                return null;
            }
            
        }

      


    }



}
   

   