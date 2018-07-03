using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelPriceChecker
{
    public class HotelDetails
    {
        public string HotelKey;

        public string HotelName;

        public string HotelAddress;

        public string HotelAddress2;

        public string PostCode;

        public string City;

        public string State;

        public string Country;

        public double Latitude;

        public double Longitude;

        public string Currency;

        public HotelDetails()
        {
            
        }

        public HotelDetails(string hotelKey, string hotelName, string hotelAddress, string postCode, string city, string country)
        {
            this.HotelKey = hotelKey;
            this.HotelName = hotelName;
            this.HotelAddress = hotelAddress;
            this.HotelAddress2 = "";
            this.PostCode = postCode;
            this.City = city;
            this.State = "";
            this.Country = country;
            this.Latitude = 0.0;
            this.Longitude = 0.0;
            this.Currency = "GBP";
        }

        public HotelDetails(string hotelKey, string hotelName, string hotelAddress, string postCode, string city, string country, double lat, double lon)
        {
            this.HotelKey = hotelKey;
            this.HotelName = hotelName;
            this.HotelAddress = hotelAddress;
            this.HotelAddress2 = "";
            this.PostCode = postCode;
            this.City = city;
            this.State = "";
            this.Country = country;
            this.Latitude = lat;
            this.Longitude = lon;
            this.Currency = "GBP";
        }

        public HotelDetails(string hotelKey, string hotelName, string hotelAddress, string postCode, string city, string country, double lat, double lon, string currency)
        {
            this.HotelKey = hotelKey;
            this.HotelName = hotelName;
            this.HotelAddress = hotelAddress;
            this.HotelAddress2 = "";
            this.PostCode = postCode;
            this.City = city;
            this.Country = country;
            this.Latitude = lat;
            this.Longitude = lon;
            this.Currency = currency;
        }

    }

    public class SuperTravelDiscountHotelDetails
    {
        public string id;
        public string name;
        public double longitude;
        public double latitude;
        public string postCode;
        public string address;
        public string address2;
        public string city;
        public string state;
        public string country;


        public SuperTravelDiscountHotelDetails()
        {
            this.id = "0";
            this.name = "HOTEL";
            this.latitude = 0.0;
            this.longitude = 0.0;
            this.postCode = "POSTCODE";
            this.address = "";
            this.address2 = "";
            this.city = "CITY";
            this.state = "STATE";
            this.country = "COUNTRY";
        }


        public SuperTravelDiscountHotelDetails(string id, string name, double latitude, double longitude, string postcode, string address, string address2, string city, string country)
        {
            this.id = id;
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
            this.postCode = postcode;
            this.address = address;
            this.address2 = address2;
            this.city = city;
            this.state = "";
            this.country = country;

        }
    }

    public class TrivagoHotelDetails
    {
        public int api_version;
        public string lang;
        public List<HotelDetails> hotels;
        //private HotelDetails[] hotels;

        public TrivagoHotelDetails()
        {
            this.api_version = 4;
            this.lang = "en_GB";
            this.hotels = new List<HotelDetails>();
        }

        public TrivagoHotelDetails(HotelDetails[] hotels)
        {
            this.api_version = 4;
            this.lang = "en_GB";
            this.hotels = new List<HotelDetails>();
            this.hotels.Add(hotels[0]);
        }

        public TrivagoHotelDetails(List<HotelDetails> list)
        {
            this.api_version = 4;
            this.lang = "en_GB";
            this.hotels = list;
        }

        public TrivagoHotelDetails ChangeHotelDetails(HotelDetails hotelDetails)
        {
            hotels.Add(hotelDetails);
            return this;
        }
    }
}