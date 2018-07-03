using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace HotelPriceChecker
{
    [JsonObject]
    public class HotelIDsStructure
    {
        public List<string> hotelids;

        public HotelIDsStructure()
        {
            this.hotelids = new List<string>();
        }

        public HotelIDsStructure(string hotelid)
        {
            this.hotelids = new List<string>();
            hotelids.Add(hotelid);
        }

        public HotelIDsStructure(List<string> hotelids)
        {
            this.hotelids = hotelids;
        }
    }

    [JsonObject]
    public class HotelSearchResponse
    {
        public string hotel_id;
        public List<Dictionary<string,RoomTypeResponse>[]> room_types;

        public HotelSearchResponse() { }

        public HotelSearchResponse(string hotelid, List<Dictionary<string, RoomTypeResponse>[]> rtresponselist)
        {
            this.hotel_id = hotelid;
            this.room_types = rtresponselist;
        }

        public HotelSearchResponse(string hotelid, Dictionary<string, RoomTypeResponse>[] rtresponselist)
        {
            this.hotel_id = hotelid;
            this.room_types = new List<Dictionary<string, RoomTypeResponse>[]>();
            this.room_types.Add(rtresponselist);
        }

            //public HotelSearchResponse(string hotelid, List<Dictionary<string,RoomTypeResponse>> rtresponselist)
            //{
            //    this.hotel_id = hotelid;
            //    this.room_types = new List<List<Dictionary<string,RoomTypeResponse>>>();
            //    this.room_types.Add(rtresponselist);
            //}

            //public HotelSearchResponse(string hotelid, Dictionary<string, RoomTypeResponse> rtresponselist)
            //{
            //    this.hotel_id = hotelid;
            //    this.room_types = new List<List<Dictionary<string, RoomTypeResponse>>>();
            //    this.room_types.Add(new List<Dictionary<string, RoomTypeResponse>>());
            //    this.room_types[0].Add(rtresponselist);
        
}

    [JsonObject]
    public class ListOfRoomTypes
    {
        public List<Dictionary<string,RoomTypeResponse>> room_types { get; set; }
        
        public ListOfRoomTypes()
        {
            this.room_types = new List<Dictionary<string, RoomTypeResponse>>();
        }

        public ListOfRoomTypes(List<Dictionary<string,RoomTypeResponse>> list)
        {
            this.room_types = list;
        }

        public ListOfRoomTypes(RoomTypeResponse roomTypeResponse, int num_rooms)
        {
            this.room_types = new List<Dictionary<string,RoomTypeResponse>>();

            Dictionary<string, RoomTypeResponse> dic = new Dictionary<string, RoomTypeResponse>();

            for(int j = 0; j < num_rooms; j++)
            {
                dic.Add(roomTypeResponse.room_code, roomTypeResponse);
            }

            this.room_types.Add(dic);
        }

        public void Add(string str, RoomTypeResponse rtresponse)
        {
            Dictionary<string, RoomTypeResponse> dic = new Dictionary<string, RoomTypeResponse>();

            dic.Add(str, rtresponse);

            this.room_types.Add(dic);
        }

        public void Add(string str, RoomTypeResponse rtresponse, int num_rooms)
        {
            Dictionary<string, RoomTypeResponse> dic = new Dictionary<string, RoomTypeResponse>();

        
            for (int j = 0; j < num_rooms; j++)
            {
                dic.Add(str, rtresponse);
            }

            this.room_types.Add(dic);
        }

        public void Add(Dictionary<string,RoomTypeResponse> dic)
        {
            this.room_types.Add(dic);
        }
    }

    [JsonObject]
    public class RoomTypeResponse
    {
        public int booking_fee { get; set; }
        public bool breakfast_included { get; set; }
        public double breakfast_price { get; set; }
        public string currency { get; set; }
        public double final_rate { get; set; }
        public bool free_cancellation { get; set; }
        public int hotel_fee { get; set; }
        public double local_tax { get; set; }
        public string meal_code { get; set; }
        public double net_rate { get; set; }
        public string payment_type { get; set; } //Acceptable Values: Prepaid, Postpaid, Installments
        public double resort_fee { get; set; }
        public List<RoomTypeAmenities> room_amenities { get; set; }
        public string room_code { get; set; }
        public int rooms_left { get; set; }
        public double service_charge { get; set; }
        public string url { get; set; }
        public double vat { get; set; }

        public RoomTypeResponse()
        { 
            this.payment_type = "Prepaid"; //This is always Pre-paid in Super Travel Discounts
            this.meal_code = "RO";
        }

        public RoomTypeResponse(int booking_fee, bool breakfast_included, double breakfast_price, string currency, double final_rate,
            bool free_cancellation, int hotel_fee, double local_tax, string meal_code, double net_rate, string payment_type,
            double resort_fee, List<RoomTypeAmenities> room_amenities, string room_code, int rooms_left, double service_charge,
            string url, double vat)
        {
            this.booking_fee = booking_fee;
            this.breakfast_included = breakfast_included;
            this.breakfast_price = breakfast_price;
            this.currency = currency;
            this.final_rate = final_rate;
            this.free_cancellation = free_cancellation;
            this.hotel_fee = hotel_fee;
            this.local_tax = local_tax;
            this.meal_code = meal_code;
            this.net_rate = net_rate;
            this.payment_type = payment_type;
            this.resort_fee = resort_fee;
            this.room_amenities = room_amenities;
            this.room_code = room_code;
            this.rooms_left = rooms_left;
            this.service_charge = service_charge;
            this.url = url;
            this.vat = vat;
        }
    }

    [JsonObject]
    public class RoomTypeAmenities
    {
        public string amenities;

        public RoomTypeAmenities()
        {
            this.amenities = "";
        }

        public RoomTypeAmenities(string amenity)
        {
            this.amenities = amenity;
        }
    }

    [JsonObject]
    public class HotelSearchResults
    {
        public int api_version;
        public string currency;
        public string start_date;
        public string end_date;
        public string lang;
        public string rate_model;
        public int room_adults_1;
        public int? room_adults_2;
        public int? room_adults_3;
        public int?[] room_childs_1;
        public int?[] room_childs_2;
        public int?[] room_childs_3;
        public int num_rooms;
        public List<string> hotel_ids;
        public List<HotelSearchResponse> hotels;

        public HotelSearchResults()
        {

        }

        public HotelSearchResults(DateTime checkin, DateTime checkout, int room_adults, int num_rooms, List<string> hotelids)
        {
            this.api_version = 4;
            this.currency = "GBP";
            this.start_date = checkin.ToString("yyyy-MM-dd");
            this.end_date = checkout.ToString("yyyy-MM-dd");
            this.lang = "en_GB";
            this.rate_model = "NET";
            this.room_adults_1 = room_adults;
            this.num_rooms = num_rooms;
            this.hotel_ids = hotelids;
            this.hotels = new List<HotelSearchResponse>();
        }

        public HotelSearchResults(int api_version, string currency, DateTime checkin, DateTime checkout, int room_adults, int num_rooms, string lang, string rate_model, List<string> hotelids, List<HotelSearchResponse> hotels)
        {
            this.api_version = api_version;
            this.currency = currency;
            this.start_date = checkin.ToString("yyyy-MM-dd");
            this.end_date = checkout.ToString("yyyy-MM-dd");
            this.lang = lang;
            this.rate_model = rate_model;
            this.room_adults_1 = room_adults;
            this.num_rooms = num_rooms;
            this.hotel_ids = hotelids;
            this.hotels = hotels;
        }

        public HotelSearchResults(int api_version, string currency, DateTime checkin, DateTime checkout, int room_adults_1, int room_adults_2, int room_adults_3, int?[] room_childs_1, int?[] room_childs_2, int?[] room_childs_3, int num_rooms, string lang, string rate_model, List<string> hotelids, List<HotelSearchResponse> hotels)
        {
            this.api_version = api_version;
            this.currency = currency;
            this.start_date = checkin.ToString("yyyy-MM-dd");
            this.end_date = checkout.ToString("yyyy-MM-dd");
            this.lang = lang;
            this.rate_model = rate_model;
            this.room_adults_1 = room_adults_1;
            if (room_adults_2 == 0) { this.room_adults_2 = null; } else this.room_adults_2 = room_adults_2;
            if (room_adults_3 == 0) { this.room_adults_3 = null; } else this.room_adults_3 = room_adults_3;
            if (HotelPriceCheckerAPIEngine.CountChildren(room_childs_1) == 0) { this.room_childs_1 = null; } else this.room_childs_1 = room_childs_1;
            if (HotelPriceCheckerAPIEngine.CountChildren(room_childs_2) == 0) { this.room_childs_2 = null; } else this.room_childs_2 = room_childs_2;
            if (HotelPriceCheckerAPIEngine.CountChildren(room_childs_3) == 0) { this.room_childs_3 = null; } else this.room_childs_3 = room_childs_3;
            this.num_rooms = num_rooms;
            this.hotel_ids = hotelids;
            this.hotels = hotels;
        }

    }

    //This object represents the full response of Hotel availability to Trivago's FAST CONNECT.
    [JsonObject]
    public class HotelSearchResultsRoot
    {
        //List as a parameter
        public HotelSearchResults root;

        //Initilize new empty HotelSearchResultsRoot
        public HotelSearchResultsRoot()
        {
            this.root = new HotelSearchResults();
        }

        //Initialize new HotelSearchResultsRoot, with a given one-record list
        public HotelSearchResultsRoot(HotelSearchResults results)
        {
            this.root = results; 
        }
    }

    [JsonObject]
    public class HotelSearchResultsRootArray
    {
        public List<HotelSearchResultsRoot> rootArray;

        public HotelSearchResultsRootArray()
        {
            this.rootArray = new List<HotelSearchResultsRoot>();
        }

        public HotelSearchResultsRootArray(HotelSearchResultsRoot root)
        {
            this.rootArray = new List<HotelSearchResultsRoot>();
            this.rootArray.Add(root);

        }

        public HotelSearchResultsRootArray(List<HotelSearchResultsRoot> rootArray)
        {
            this.rootArray = rootArray;
        }
    }

    [JsonObject]
    public class PostBodyString
    {
        public int api_version { get; set; }
        public string hotels { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int room_adults_1 { get; set; }
        public int room_adults_2 { get; set; }
        public int room_adults_3 { get; set; }
        public string room_childs_1 { get; set; }
        public string room_childs_2 { get; set; }
        public string room_childs_3 { get; set; }
        public int num_rooms { get; set; }
        public string lang { get; set; }
        public string rate_model { get; set; }
        public string currency { get; set; }

        public PostBodyString()
        {

        }

        public void TrimHotels()
        {
            hotels = hotels.Replace("\n", string.Empty);
            hotels = hotels.Replace("\r", string.Empty);
            hotels = hotels.Replace("\"","");
            hotels = hotels.Replace(@"\\", string.Empty);
            hotels = hotels.Replace(@"\\\", string.Empty);
            //hotels = hotels.Replace("[\\", "[");

            lang = lang.Replace("\n", "");
            lang = lang.Replace("\r", "");

            currency = currency.Replace("\n", "");
            currency = currency.Replace("\r", "");

            rate_model = rate_model.Replace("\n", "");
            rate_model = rate_model.Replace("\r", "");
        }

        private static string TokenizeFirstString(string str)
        {
            return str.Substring(0, str.IndexOf("&") - 1);
        }

        private static string TokenizeSecondString(string str)
        {
            return str.Substring(str.IndexOf("&")+1,str.Length -1);
        }

        private static string getParameterValue(string str)
        {
            return str.Substring(str.IndexOf("=")+1, str.Length - 1);
        }
    }

}