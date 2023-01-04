using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_MVC.Models
{
    public class FlightViewModel
    {

        public int FlightNo { get; set; }
        public string FlightId { get; set; }
        public string Name { get; set; }
        public string Start { get; set; }
        public string Destination { get; set; }
        public System.DateTime Arrival { get; set; }
        public System.DateTime Departure { get; set; }

        //public Nullable<int> TotalSeats { get; set; }
        public Nullable<double> Fare { get; set; }
        //public Nullable<bool> IsActive { get; set; }
        //public Nullable<bool> Cancelled { get; set; }
    }
}