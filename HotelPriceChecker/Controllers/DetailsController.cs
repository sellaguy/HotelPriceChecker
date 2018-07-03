using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;
using Newtonsoft.Json.Linq;


namespace HotelPriceChecker.Controllers
{
    public class DetailsController : ApiController
    {
        // GET api/values
        public JObject Get()
        {
            try
            {
                DatabaseAPIConnectorDataContext dc = new DatabaseAPIConnectorDataContext();

                List<string> listOfHotelIDs = new List<string>();

                var q = from a in dc.Hotels
                        where a.IsActive.Equals(true)
                        select a.HotelKey;


                List<HotelDetails> hotels = new List<HotelDetails>();

                foreach (string str in q)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://supertraveldiscount.com/api/hotel/detail/" + str);
                    request.Method = "GET";
                    request.ContentType = "application/json";

                    WebResponse response = request.GetResponse();

                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);


                    string responseFromServer = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    SuperTravelDiscountHotelDetails tmp = JsonConvert.DeserializeObject<SuperTravelDiscountHotelDetails>(responseFromServer);

                    hotels.Add(new HotelDetails(tmp.id, tmp.name, tmp.address, tmp.postCode, tmp.city, tmp.country));
                }

                return JObject.Parse(JsonConvert.SerializeObject(new TrivagoHotelDetails(hotels), Formatting.Indented));
            }
            catch(Exception exp)
            {
                return new JObject(exp);
            }
        }

        public JObject Get(string id)
        {
            try
            {
                HttpWebRequest request;

                try
                {
                    request = (HttpWebRequest)WebRequest.Create("https://supertraveldiscount.com/api/hotel/detail/" + id);
                } catch(Exception exp) { throw exp;  }
                request.Method = "GET";
                request.ContentType = "application/json";

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);


                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();

                SuperTravelDiscountHotelDetails tmp = JsonConvert.DeserializeObject<SuperTravelDiscountHotelDetails>(responseFromServer);

                List<HotelDetails> hotels = new List<HotelDetails>();

                hotels.Add(new HotelDetails(tmp.id, tmp.name, tmp.address, tmp.postCode, tmp.city, tmp.country));

                return JObject.Parse(JsonConvert.SerializeObject(new TrivagoHotelDetails(hotels), Formatting.Indented));
            } catch(Exception exp)
            {
                return new JObject(exp);
            }

        }

    }
}