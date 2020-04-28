using Go_Nosh.Contracts;
using Go_Nosh.Data;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Go_Nosh.Models;

namespace Go_Nosh.Services
{
    public class GoogleMapService : IGoogleMapService
    {

        ApplicationDbContext _context;


        public GoogleMapService(ApplicationDbContext context)
        {
            _context = context;
           
        }
     
        public async Task<FoodTruckAPI> GetFoodTruck()
        {
            string url = $"https://maps.googleapis.com/maps/api/place/textsearch/json?query=Foodtrucks+in+Milwaukee&key=AIzaSyDfA2AwwISWPRAOEWKNrotIyAjtOv-9-XU";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                FoodTruckAPI foodTruckAPI = JsonConvert.DeserializeObject<FoodTruckAPI>(json);
                MapGoogleResultsToFoodTruckModel(foodTruckAPI);
                return foodTruckAPI;
                
            }
            else
            {
                return null;
            }
          
        }
        private  void MapGoogleResultsToFoodTruckModel(FoodTruckAPI foodTruckAPI)
        {

            var foodTrucks = foodTruckAPI;

            foreach (Result res in foodTrucks.results)
            {
                //Turn each one of these messy arrays of info into an actual FoodTruck Object for your DB
                FoodTruck ft = new FoodTruck();
                ft.FoodTruckName = res.name;
                ft.FoodTruckPhone = res.plus_code.compound_code;
                ft.Lat = res.geometry.location.lat;
                ft.Lng = res.geometry.location.lng;
                ft.Address = res.formatted_address;
                ft.FoodType = res.types.ToString();
                ft.Price_level = res.price_level;
                ft.Rating = res.rating;
                ft.Place_Id = res.place_id;
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
    }

}
   

   