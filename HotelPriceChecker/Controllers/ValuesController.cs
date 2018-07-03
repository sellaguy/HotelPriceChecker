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
using Newtonsoft.Json.Schema;

namespace HotelPriceChecker.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public JObject Get()
        {
            DatabaseAPIConnectorDataContext dc = new DatabaseAPIConnectorDataContext();

            List<string> listOfHotelIDs = new List<string>();

            var q = from a in dc.Hotels
                    where a.IsActive.Equals(true)
                    select a.HotelKey;
                    

            List<HotelDetails> hotels = new List<HotelDetails>();

            foreach (string str in q)
            {
                HttpWebRequest request;
                try
                {
                    request = (HttpWebRequest)WebRequest.Create("https://supertraveldiscount.com/api/hotel/detail/" + str);
                } catch (Exception exp) { throw exp;  }
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

        public JObject Get(string id)
        {
            HttpWebRequest request;

            try
            {
                request = (HttpWebRequest)WebRequest.Create("https://supertraveldiscount.com/api/hotel/detail/" + id);
            } catch (Exception exp) { throw exp; }
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


        }

        #region Notes
        /*
        // Post api/values/5
        public JObject Post(string location, DateTime check_in, DateTime check_out, int room_qty, int adult_qty, int child_qty, string id)
        {
            string suffix = HotelPriceCheckerAPIEngine.CreateURLSuffixForHotelAvailability(location, check_in, check_out, room_qty, adult_qty, child_qty, id);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://supertraveldiscount.com/api/hotel/price" +suffix);

            request.Method = "GET";
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            SuperTravelDiscountHotelSearchResults tmp = (SuperTravelDiscountHotelSearchResults)JsonConvert.DeserializeObject(responseFromServer, typeof(SuperTravelDiscountHotelSearchResults));

            List<string> hotelids = new List<string>();

            hotelids.Add(id);

            List<RoomTypeAmenities> roomAmenities;
            RoomTypeResponse room_types;

            List<RoomTypeResponse> room_types_list = new List<RoomTypeResponse>();

            for (int i = 0; i < tmp.options.Count; i++)
            {
                room_types = new RoomTypeResponse();
                roomAmenities = new List<RoomTypeAmenities>();

                foreach (var roomamenity in tmp.options[i].freeIncludedItems)
                {
                    roomAmenities.Add(new RoomTypeAmenities(roomamenity.name.ToUpper()));
                }

                #region Room Type Properties
                room_types.booking_fee = 0;
                room_types.breakfast_included = HotelPriceCheckerAPIEngine.IsBreakfastIncluded(roomAmenities) ? true : false;
                room_types.breakfast_price = 0;
                room_types.currency = "GBP";
                room_types.final_rate = tmp.options[i].selling_price;
                room_types.free_cancellation = tmp.options[i].policyRules[0].refundable == 1 ? true : false; 
                room_types.hotel_fee = 0;
                room_types.local_tax = 0;
                room_types.meal_code = HotelPriceCheckerAPIEngine.IsBreakfastIncluded(roomAmenities)? "BB" : "RO";
                room_types.net_rate = tmp.options[i].selling_price;
                room_types.payment_type = "NET";
                room_types.resort_fee = 0.0;
                room_types.room_amenities = roomAmenities;
                room_types.room_code = tmp.servicecode;
                room_types.service_charge = 0;
                room_types.url = "";
                room_types.vat = 0.0;

                #endregion

                room_types_list.Add(room_types);
            }


            List<HotelSearchResponse> hotels = new List<HotelSearchResponse>();

            hotels.Add(new HotelSearchResponse(id, room_types_list));
            
            HotelSearchResultsRoot root = new HotelSearchResultsRoot(new HotelSearchResults(4, "GBP", check_in, check_out, adult_qty, room_qty, "en_GB", "NET", hotelids, hotels));

            return JObject.Parse(JsonConvert.SerializeObject(root , Formatting.Indented));
        }
        */
        #endregion 

        // Post api/values/5
        public JObject Post(int api_version, string hotels, DateTime start_date, DateTime end_date, int room_adults_1, int room_adults_2, int room_adults_3, int?[] room_childs_1, int?[] room_childs_2, int?[] room_childs_3, int num_rooms, string lang, string rate_model, string currency)
        {
            string[] stringOfHotels = HotelPriceCheckerAPIEngine.ConvertStringToArray(hotels);

            List<HotelSearchResponse> listOfHotels = new List<HotelSearchResponse>();

            List<string> hotelids = new List<string>();

            //Return empty response if evening and weekends is active
            //if(!HotelPriceCheckerAPIEngine.GetAPIStatus())
            //    return JObject.Parse(JsonConvert.SerializeObject(HotelPriceCheckerAPIEngine.GetEmptyResult(api_version, currency, start_date, end_date, room_adults_1, num_rooms, lang, rate_model, stringOfHotels), Formatting.Indented));


            foreach (string hotelid in stringOfHotels)
            {
                hotelids.Add(hotelid);
            }

            //This IF statement returns empty availability response if the DB status is set to false.
            //DB status determines if the API needs to return results or not.
            if (!HotelPriceCheckerAPIEngine.GetAPIStatus())
                return JObject.Parse(JsonConvert.SerializeObject(
                    new HotelSearchResultsRoot(
                        new HotelSearchResults(start_date, end_date, room_adults_1, num_rooms, hotelids))
                                                , Formatting.Indented));


            //foreach (string uniqueHotelID in stringOfHotels)             {

                DateTime checkin = start_date;
                DateTime checkout = end_date;
                int room_qty = num_rooms;
                int[] adults_qty = new int[] { room_adults_1, room_adults_2, room_adults_3 };
                int?[] child_qty = new int?[3] { null, null, null };
                child_qty[0] = HotelPriceCheckerAPIEngine.CountChildren(room_childs_1);
                child_qty[1] = HotelPriceCheckerAPIEngine.CountChildren(room_childs_2);
                child_qty[2] = HotelPriceCheckerAPIEngine.CountChildren(room_childs_3);
                int?[][] child_ages = new int?[3][] { room_childs_1, room_childs_2, room_childs_3 };
                for(int ind = 0; ind < child_ages.Length; ind++)
                {
                    if (child_ages[ind] == null) { child_ages[ind] = new int?[1] { 0 }; }
                }

            //string id = uniqueHotelID;

            string suffix = HotelPriceCheckerAPIEngine.CreateURLSuffixForHotelAvailability(checkin, checkout, room_qty, adults_qty, child_qty, child_ages, stringOfHotels);


                HttpWebRequest request;

                try
                {
                    request = (HttpWebRequest)WebRequest.Create("https://supertraveldiscount.com/api/hotel/price" + suffix);
                } catch (Exception exp)
                {
                    throw exp;
                }

                request.Method = "GET";
                request.ContentType = "application/json";

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);



                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();


                string jsonresult = JsonConvert.SerializeObject(responseFromServer);

                JArray a = new JArray(jsonresult);

                SuperTravelDiscountHotelSearchArray tmpArray = new SuperTravelDiscountHotelSearchArray();

                //return a;

                try
                {
                    //tmpArray = (SuperTravelDiscountHotelSearchArray)JsonConvert.DeserializeObject(responseFromServer, typeof(SuperTravelDiscountHotelSearchArray));
                    a =  (JArray)JsonConvert.DeserializeObject(responseFromServer);
                }
                catch (Exception exp)
                {
                    return new JObject(exp.ToString());
                }
                List<RoomTypeAmenities> roomAmenities;
                RoomTypeResponse room_types;

                foreach(JToken token in a)
                {
                    tmpArray.array.Add(token.ToObject<SuperTravelDiscountHotelSearchResults>());
                }

                //List<SuperTravelDiscountHotelSearchResults> tmpList = (List<SuperTravelDiscountHotelSearchResults>)tmpArray;
                
                //ListOfRoomTypes room_types_list = new ListOfRoomTypes();
                foreach (SuperTravelDiscountHotelSearchResults tmp in tmpArray.array)
                {

                    List<Dictionary<string, RoomTypeResponse>[]> dic = new List<Dictionary<string, RoomTypeResponse>[]>(tmp.options.Count);

                    for (int i = 0; i < tmp.options.Count; i++)
                    {
                        room_types = new RoomTypeResponse();
                        roomAmenities = new List<RoomTypeAmenities>();


                        foreach (var roomamenity in tmp.options[i].freeIncludedItems)
                        {
                            if (!roomamenity.name.ToUpper().Contains("ROOM ONLY"))
                            {
                                //roomAmenities.Add(new RoomTypeAmenities(roomamenity.name.ToUpper()));
                            }
                        }

                    double numOfNights = (checkout - checkin).TotalDays;
                        #region Room Type Properties

                        room_types.booking_fee = 0;
                        room_types.breakfast_included = HotelPriceCheckerAPIEngine.IsBreakfastIncluded(roomAmenities) ? true : false;
                        room_types.breakfast_price = 0;
                        room_types.currency = currency;
                        room_types.final_rate = (1+HotelPriceCheckerAPIEngine.margin)*tmp.options[i].selling_price / numOfNights;
                        try
                        {
                            room_types.free_cancellation = tmp.options[i].policyRules[0].refundable == 1 ? true : false;
                            } catch(ArgumentOutOfRangeException exp)
                        {
                            room_types.free_cancellation = false;
                        }
                        room_types.hotel_fee = 0;
                        room_types.local_tax = 0;
                        room_types.meal_code = HotelPriceCheckerAPIEngine.IsBreakfastIncluded(roomAmenities) ? "BB" : "RO";
                        room_types.net_rate = (1+HotelPriceCheckerAPIEngine.margin)*tmp.options[i].selling_price / numOfNights;
                        room_types.payment_type = "prepaid"; //In TTG it is always Pre-pay
                        room_types.resort_fee = 0.0;
                        room_types.room_amenities = roomAmenities;
                        room_types.room_code = tmp.options[i].name.ToUpper();
                        room_types.service_charge = 0;
                        room_types.url = tmp.url;
                        room_types.vat = 0.0;
                        #endregion

                        dic.Add(new Dictionary<string, RoomTypeResponse>[1]);

                        dic[i][0] = new Dictionary<string, RoomTypeResponse>();

                        if (!dic[i][0].ContainsKey(room_types.room_code))
                            dic[i][0].Add(room_types.room_code, room_types);
                        else
                    {
                        dic[i][0].Add(room_types.room_code + " #" + (i + 1).ToString(), room_types);
                    }


                }

                listOfHotels.Add(new HotelSearchResponse(tmp.hotel_id, dic));

                //List<Dictionary<string,RoomTypeResponse>[]> list = new List<Dictionary<string, RoomTypeResponse>[]>();

                //list.Add(dic);

                //foreach (string uniqueHotelID in stringOfHotels)
                //{

                //}
            }
                
            //}

            HotelSearchResultsRoot root = new HotelSearchResultsRoot(new HotelSearchResults(api_version, currency, start_date, end_date, room_adults_1, room_adults_2, room_adults_3, room_childs_1, room_childs_2, room_childs_3, num_rooms, lang, rate_model, stringOfHotels.ToList<string>(), listOfHotels));

            HotelSearchResultsRootArray rootArray = new HotelSearchResultsRootArray(root);

            return JObject.Parse(JsonConvert.SerializeObject(root,Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }));

            //return JObject.Parse(JsonConvert.SerializeObject(root, Formatting.Indented));
        }

        // Post api/values/
        [System.Web.Mvc.HttpPost]
        public JObject Post([FromBody] PostBodyString body)
        {

            PostBodyString pbs = body;

            pbs.TrimHotels();

            return Post(pbs.api_version, pbs.hotels, pbs.start_date, pbs.end_date, pbs.room_adults_1, pbs.room_adults_2, pbs.room_adults_3, HotelPriceCheckerAPIEngine.ConvertStringToChildrenRoomArray(pbs.room_childs_1), HotelPriceCheckerAPIEngine.ConvertStringToChildrenRoomArray(pbs.room_childs_2), HotelPriceCheckerAPIEngine.ConvertStringToChildrenRoomArray(pbs.room_childs_3), pbs.num_rooms, pbs.lang, pbs.rate_model, pbs.currency);
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
