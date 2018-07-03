using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


namespace HotelPriceChecker
{
    class HotelPriceCheckerAPIEngine
    {
        private static DatabaseAPIConnectorDataContext dc = new DatabaseAPIConnectorDataContext();
        public static double margin = 0.12;


        public HotelPriceCheckerAPIEngine()
        {
            
        }

        public static string CreateURLSuffixForHotelAvailability(string location, DateTime checkin, DateTime checkout, int room_qty, int adults_qty, int child_qty, string id)
        {
            return "?location=" + location + "&check_in=" + ConcatenateStrings(checkin) + "&check_out=" + ConcatenateStrings(checkout) + "&room_qty=" + room_qty.ToString() + "&adult_qty[0]=" + adults_qty.ToString() + "&child_qty[0]=" + child_qty.ToString() + "&id[]=" + id;
        }

        public static string CreateURLSuffixForHotelAvailability(string location, DateTime checkin, DateTime checkout, int room_qty, int adults_qty, int child_qty, string[] id)
        {
            string ret = "?location=" + location + "&check_in=" + ConcatenateStrings(checkin) + "&check_out=" + ConcatenateStrings(checkout) + "&room_qty=" + room_qty.ToString();

            int i = 0;
            foreach (string str in id)
            {
                ret += "&adult_qty[" +i+ "]=" + adults_qty.ToString() + "&child_qty["+i+"]=" + child_qty.ToString() + "&id[]=" + id;

                i += 1;
            }

            return ret;
        }


        public static string CreateURLSuffixForHotelAvailability(DateTime checkin, DateTime checkout, int room_qty, int[] adults_qty, int?[] child_qty, int?[][] child_ages, string[] hotelids)
        {
            string ret = "?check_in=" + ConcatenateStrings(checkin) + "&check_out=" + ConcatenateStrings(checkout) + "&room_qty=" + room_qty.ToString();

            for(int i = 0; i < room_qty; i++)
            {
                ret += "&adult_qty[" + i + "]=" + adults_qty[i].ToString() + "&child_qty[" + i + "]=" + child_qty[i].ToString();

                for(int j = 0; j < child_ages[i].Length; j++)
                {
                    if (child_qty[i] > 0) {
                        ret += "&child_age[" + i + "][]=" + child_ages[i][j].ToString();
                    }
                }

            }

            int k = 0;
            foreach(string hotelid in hotelids)
            {
                ret += "&id[" + k + "]=" + hotelid; 
                k = k + 1; 
            }

            return ret;
        }

        public static string CreateURLSuffixForHotelAvailability(string api_version, string[] hotels, DateTime start_date, DateTime end_date, int room_adults_1, int num_rooms, string lang, string rate_model, string currency)
        {
            return "?api_version=" + api_version + "&hotels=[" + ConcatenateStrings(hotels) + "]&start_date=" + ConcatenateStrings(start_date) + "&end_date=" + ConcatenateStrings(end_date) + "&room_adults_1=" + room_adults_1.ToString() + "&num_rooms=" + num_rooms.ToString() + "&lang=" + lang + "&rate_model=" + rate_model + "&currency=" + currency;
        }

        public static string ConcatenateStrings(string[] strs)
        {
            string result = strs[0];

            if (strs.Length > 1)
            {
                foreach (string str in strs)
                {
                    result += ",";
                    result += str;
                }
            }
            return result;
        }

        public static string ConcatenateStrings(List<string> strs)
        {
            string result = strs[0];

            if (strs.Count > 1)
            {
                foreach (string str in strs)
                {
                    result += ",";
                    result += str;
                }
            }
            return result;
        }

        public static string ConcatenateStrings(DateTime date)
        {
            return date.ToString("dd+MMM+yyyy");
            // date.Day.ToString() + "+" + date.Month.ToString("MMM") + "+" + date.Year.ToString();
        }

        public static bool IsBreakfastIncluded(List<RoomTypeAmenities> amenities)
        {
            foreach (RoomTypeAmenities amenity in amenities)
            {
                if (amenity.amenities.IndexOf("BREAKFAST", StringComparison.OrdinalIgnoreCase) > -1) return true;
                if (amenity.amenities.IndexOf("BOARD", StringComparison.OrdinalIgnoreCase) > -1) return true;
            }
            return false;
        }

        public static int CountChildren(int[] child_qty)
        {
            int ret = 0;
            foreach(int childage in child_qty)
            {
                if(childage > 0) 
                    ret++;
            }
            return ret;
        }

        public static int CountChildren(int?[] child_qty)
        {
            try
            {
                int ret = 0;
                foreach (int? childage in child_qty)
                {
                    if (childage > 0)
                        ret++;
                }
                return ret;
            } catch(NullReferenceException exp)
            {
                return 0;
            }
        }

        protected string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string[] ConvertStringToArray(string str)
        {
            //int startsub = 0;

            try
            {
                string result;

                result = str.Replace("[", "");
                result = result.Replace("]", "");
                
                List<string> hotelIDs = result.Replace("\"", "").Split(',').ToList<string>();

                return hotelIDs.ToArray();
            }
            catch (Exception exp)
            {
                throw new IndexOutOfRangeException("Error Message occurred as the string provided is not of string[] structure. Error is: " +exp.ToString());
            }
        }

        public static int?[] ConvertStringToChildrenRoomArray(string str)
        {
            if (str == null) return new int?[] { 0 };

            try
            {
                string result;

                result = str.Replace("[", "");
                result = result.Replace("]", "");

                List<string> childages = result.Replace("\"", "").Split(',').ToList<string>();

                int[] tempRet = childages.ToArray().Select(int.Parse).ToArray();

                int?[] ret = new int?[tempRet.Length];

                for (int i = 0; i < ret.Length; i++) {  ret[i] = tempRet[i];  }

                return ret;

            }
            catch (Exception exp)
            {
                throw new IndexOutOfRangeException("Error Message occurred as the string provided is not of string[] structure. Error is: " + exp.ToString());
            }
        }

        public static HotelSearchResultsRoot GetEmptyResult(int api_version, string currency, DateTime start_date, DateTime end_date, int room_adults_1, int num_rooms, string lang, string rate_model, string[] stringOfHotels)
        {
            return new HotelSearchResultsRoot(new HotelSearchResults(api_version, currency, start_date, end_date, room_adults_1, num_rooms, lang, rate_model, stringOfHotels.ToList<string>(), new List<HotelSearchResponse>()));
        }

        private static bool IsDateToday(DateTime date)
        {
            if (date.Day == DateTime.Now.Day && date.Month == DateTime.Now.Month && date.Year == DateTime.Now.Year) return true;
            else return false;
        }

        public static bool GetAPIStatus()
        {
            return true;
            //if (GetSpecialsDayStatus()) return true;
            //if (GetAPIActivationStatus()) return true;
            //return false;
        }

        private static bool GetAPIActivationStatus()
        {
            var result = from a in dc.APIActivations
                             where a.TimeToSwitch < DateTime.Now
                             orderby a.TimeToSwitch descending
                             select a;

            if (result.Count<APIActivation>() == 0) return true;

            return result.First<APIActivation>().SwitchTo;
        }

        private static bool GetSpecialsDayStatus()
        {
            foreach (SpecialDay sd in dc.SpecialDays)
            {
                if (sd.Date < DateTime.Now)
                {
                    dc.SpecialDays.DeleteOnSubmit(sd);
                }
                dc.SubmitChanges();
            }
                
            var result = from a in dc.SpecialDays
                         where a.Date > DateTime.Now
                         orderby a.Date ascending
                         select a;

            if (result.Count<SpecialDay>() == 0) return true;

            if (IsDateToday(result.First<SpecialDay>().Date))
                return result.First<SpecialDay>().Status;

            return false;

        }


    }


}