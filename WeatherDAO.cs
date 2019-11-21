using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using WeatherAPI.Models.Request;
using WeatherAPI.Models.Response;
using System.Data.SqlClient;

namespace WeatherAPI.DLL
{
    public class WeatherDAO
    {
        // POST api/transfernumberapi
        public DataTable Search(WeatherRequest requests)
        {
            List<WeatherResult> result = new List<WeatherResult>();
            string sqlStatement = @"";
            DataTable dt = new DataTable();

            string connectionString = @"server=harrydbservice.database.windows.net;uid=HarryAdmin;pwd=;database=HArryDB";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                sqlStatement = @"Select Result = CityNo+AddDatetime + ':' + Wx+ '降雨機率:' + PoP + '溫度' + MinT+'~' +MaxT+CI from Weather where CityNo = '" + requests.CityNo + "' and Cast(AddDatetime as Datetime) between '" + requests.StartTime + "' and '" + requests.EndTime + "' ";
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, cn);               
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
