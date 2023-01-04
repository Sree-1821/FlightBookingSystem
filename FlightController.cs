using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web_MVC.Models;
using Web_MVC.Repository;

namespace Web_MVC.Controllers
{
    public class FlightController : Controller
    {
        public async Task<ActionResult> FlightDetails()
        {
            List<FlightViewModel> flights = new List<FlightViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("api/flights/GetAllflights"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    flights = JsonConvert.DeserializeObject <List<FlightViewModel>>(apiResponse);
                }
            }
            return View(flights);
        }

        public async Task<ActionResult> Delete(int Id)
        {
            FlightViewModel flights = new FlightViewModel();
            var service = new ServiceRepository();
            {
                using (var response = service.DeleteResponse("api/Flights" + "/" + Id))

                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    flights = JsonConvert.DeserializeObject<FlightViewModel>(apiResponse);
                }
            }
            return View(flights);
        }

    }
}