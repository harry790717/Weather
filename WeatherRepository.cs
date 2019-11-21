using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherAPI.Models.Request;
using WeatherAPI.Models.Response;
using WeatherAPI.DLL;
using System.Data;

namespace WeatherAPI.Models.Repository
{
    public class WeatherRepository
    {
        private WeatherResult weather = new WeatherResult();
        private List<WeatherResultList> weatherlist = new List<WeatherResultList>();
        public WeatherResult Check(WeatherRequest requests)
        {
            List<WeatherResult> results = new List<WeatherResult>();
            string ErrStr = "";
            string ResultStr = "";

            if (string.IsNullOrEmpty(requests.CityNo))
            {
                ErrStr = "CityNo為必填欄位";
            }
            if (string.IsNullOrEmpty(requests.StartTime))
            {
                ErrStr = "StartTime為必填欄位";
            }
            if (string.IsNullOrEmpty(requests.EndTime))
            {
                ErrStr = "EndTime為必填欄位";
            }

            if (ErrStr == "")
            {
                WeatherDAO TransferCheck = new WeatherDAO();
                DataTable dt = TransferCheck.Search(requests);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Add(new WeatherResultList
                        {
                            Result = dt.Rows[i]["Result"].ToString()
                        });
                    }
                    weather.ResultList = weatherlist;

                }
                else
                {
                    ResultStr = "該區間查無資料";
                }
            }
            else
            {
                ResultStr = ErrStr;
            }
            weather.StatusCode = 1;
            weather.ResultStr = ErrStr;

            return weather;
        }
        public WeatherResultList Add(WeatherResultList item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            weatherlist.Add(item);
            return item;
        }
    }
}
