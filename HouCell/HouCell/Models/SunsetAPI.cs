using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Globalization;

namespace HouCell.Models
{
    public class SunsetAPI
    {
        public SunsetAPI()
        {

        }       
   
        public DateTime Sunrise  { get; set; }
        public DateTime Sunset  { get; set; }
        
        public static SunsetAPI getTime(float lat, float lng)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.sunrise-sunset.org/json?lat={0}&lng={1}", lat, lng));
            WebReq.Method = "GET";

            HttpWebResponse webResponse = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();

            }

            JObject sunsetGet = JObject.Parse(jsonString);
            return JsonConvert.DeserializeObject<SunsetAPI>(sunsetGet["results"].ToString());
        }


    }


}
