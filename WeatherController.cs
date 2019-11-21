using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherAPI.Models.Request;
using WeatherAPI.Models.Response;
using WeatherAPI.Models.Repository;
using WeatherAPI.DLL;
using Newtonsoft.Json;

namespace WeatherAPI.Controllers
{
    public class WeatherController : ApiController
    {
        // POST api/transfernumberapi
        public string Post([FromBody]string requestStr)
        {
            try
            {
                
                WeatherRequest requests = JsonConvert.DeserializeObject<WeatherRequest>(requestStr);
                string output = "";
                
                WeatherRepository repository = new WeatherRepository();
                WeatherResult results = repository.Check(requests);
                output = JsonConvert.SerializeObject(results);

                return output;
            }
            catch (Exception ex)
            {
                //發生錯誤時，傳回HTTP 500及錯誤訊息
                var resp = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "Web API Error"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
