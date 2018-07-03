using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace HotelPriceChecker
{
    [JsonArray]
    public class SuperTravelDiscountHotelSearchArray
    {
        public List<SuperTravelDiscountHotelSearchResults> array;

        public SuperTravelDiscountHotelSearchArray()
        {
            this.array = new List<SuperTravelDiscountHotelSearchResults>();
        }

        public SuperTravelDiscountHotelSearchArray(SuperTravelDiscountHotelSearchResults results)
        {
            this.array = new List<SuperTravelDiscountHotelSearchResults>();
            this.array.Add(results);
        }

        public SuperTravelDiscountHotelSearchArray(List<SuperTravelDiscountHotelSearchResults> results)
        {
            this.array = results;
        }

    }

    [JsonObject]
    public class SuperTravelDiscountHotelSearchResults
    {
        [JsonProperty("hotel_id")]
        public string hotel_id;
        [JsonProperty("name")]
        public string name;
        [JsonProperty("serviceid")]
        public string serviceid;
        [JsonProperty("servicecode")]
        public string servicecode;
        [JsonProperty("available")]
        public int available;
        [JsonProperty("options")]
        public List<SuperTravelDiscountListOfOptions> options;
        [JsonProperty("url")]
        public string url;

        public SuperTravelDiscountHotelSearchResults()
        {
            this.hotel_id = "";
            this.name = "";
            this.serviceid = "";
            this.servicecode = "";
            this.available = 0;
            this.options = new List<SuperTravelDiscountListOfOptions>();
            this.url = "http://www.supertraveldiscount.com";
        }

        public SuperTravelDiscountHotelSearchResults(string hotelid, string name, string serviceid, string servicecode, int available, List<SuperTravelDiscountListOfOptions> options, string url)
        {
            this.hotel_id = hotelid;
            this.name = name;
            this.serviceid = serviceid;
            this.servicecode = servicecode;
            this.available = available;
            this.options = options;
            this.url = url;
        }
    }

    [JsonObject]
    public class SuperTravelDiscountListOfOptions
    {
        [JsonProperty("bookingtypeid")]
        public int bookingtypeid;
        [JsonProperty("name")]
        public string name;
        [JsonProperty("quantity")]
        public int quantity;
        [JsonProperty("max_adult")]
        public int max_adult;
        [JsonProperty("max_child")]
        public int max_child;
        [JsonProperty("max_infants")]
        public int max_infants;
        [JsonProperty("nights")]
        public int nights;
        [JsonProperty("original_price")]
        public double original_price;
        [JsonProperty("margin")]
        public string margin;
        [JsonProperty("selling_price")]
        public double selling_price;
        [JsonProperty("available")]
        public int available;
        [JsonProperty("booking_token")]
        public string booking_token;
        [JsonProperty("optionid")]
        public string optionid;
        [JsonProperty("free_include_items")]
        public List<SuperTravelDiscountFreeIncludeItems> freeIncludedItems;
        [JsonProperty("policy_rule")]
        public List<SuperTravelDiscountPolicyRules> policyRules;


        public SuperTravelDiscountListOfOptions()
        {
            this.bookingtypeid = 0;
            this.name = "";
            this.quantity = 0;
            this.max_adult = 0;
            this.max_child = 0;
            this.max_infants = 0;
            this.nights = 0;
            this.original_price =0.0;
            this.margin = "10%";
            this.selling_price = 0.0;
            this.available = 1;
            this.booking_token = "";
            this.optionid = "optionID";
            this.freeIncludedItems = new List<SuperTravelDiscountFreeIncludeItems>();
            //this.extraInfo = new SuperTravelDiscountExtra_Info();
            this.policyRules = new List<SuperTravelDiscountPolicyRules>();
        }

        public SuperTravelDiscountListOfOptions(int bookingtypeid, string name, int quantity, int max_adult, int max_child, int max_infant, int nights, double original_price, string margin, double selling_price, int available, string booking_token, string optionid, List<SuperTravelDiscountFreeIncludeItems> freeIncludedItems, SuperTravelDiscountExtra_Info extraInfo, List<SuperTravelDiscountPolicyRules> policyRules)
        {
            this.bookingtypeid = bookingtypeid;
            this.name = name;
            this.quantity = quantity;
            this.max_adult = max_adult;
            this.max_child = max_child;
            this.max_infants = max_infant;
            this.nights = nights;
            this.original_price = original_price;
            this.margin = margin;
            this.selling_price = selling_price;
            this.available = available;
            this.booking_token = booking_token;
            this.optionid = optionid;
            this.freeIncludedItems = freeIncludedItems;
            //this.extraInfo = extraInfo;
            this.policyRules = policyRules;
        }
    }

    [JsonObject]
    public class SuperTravelDiscountFreeIncludeItems
    {
        [JsonProperty("id")]
        public string id;
        [JsonProperty("name")]
        public string name;
        [JsonProperty("type")]
        public string type;

        public SuperTravelDiscountFreeIncludeItems()
        {
            this.id = "0";
            this.name = "";
            this.type = "Unknown";
        }

        public SuperTravelDiscountFreeIncludeItems(string id, string name, string type)
        {
            this.id = id;
            this.name = name;
            this.type = type;
        }

    }

    [JsonObject]
    public class SuperTravelDiscountExtra_Info
    {
        [JsonProperty("subject")]
        public string subject { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }

        public SuperTravelDiscountExtra_Info()
        {
            this.subject = "";
            this.description = "";
        }

        public SuperTravelDiscountExtra_Info(string subject, string decription)
        {
            this.subject = subject;
            this.description = description;
        }

    }

    [JsonObject]
    public class SuperTravelDiscountPolicyRules
    {
        [JsonProperty("start_date")]
        public DateTime start_date;
        [JsonProperty("end_date")]
        public DateTime end_date;
        [JsonProperty("type")]
        public string type;
        [JsonProperty("refundable")]
        public int refundable;
        [JsonProperty("amount")]
        public double amount;
        [JsonProperty("msg")]
        public string msg;
        [JsonProperty("active")]
        public int active;

        public SuperTravelDiscountPolicyRules()
        {
            this.start_date = new DateTime();
            this.end_date = new DateTime();
            this.type = "";
            this.refundable = 0;
            this.amount = 0.0;
            this.msg = "";
            this.active = 0;
        }

        public SuperTravelDiscountPolicyRules(DateTime start_date, DateTime end_date, string type, int refundable, double amount, string msg, int active)
        {
            this.start_date = start_date;
            this.end_date = end_date;
            this.type = type;
            this.refundable = refundable;
            this.amount = amount;
            this.msg = msg;
            this.active = active;
        }

    }
}