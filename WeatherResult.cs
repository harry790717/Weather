using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAPI.Models.Response
{
    public class WeatherResult
    {
        public int StatusCode { get; set; }
        public string ResultStr { get; set; }

        public string CityNo { get; set; }

        public ICollection<WeatherResultList> ResultList { get; set; }
    }

    public class WeatherResultList
    {
        public string Result { get; set; }

    }
}