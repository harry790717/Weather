using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WeatherAPI.Models.Request
{
    public class WeatherRequest
    {
        public string CityNo { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
