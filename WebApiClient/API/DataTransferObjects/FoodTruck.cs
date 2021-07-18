using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace WebApiClient.API.DataTransferObjects
{
    public class FoodTruck
    {
        public int? dayOrder { get; set; }
        public string dayOfWeekStr { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string permit { get; set; }
        public string permitLocation { get; set; }
        public string locationdesc { get; set; }
        public string optionaltext { get; set; }
        public int locationid { get; set; }
        public int? scheduleid { get; set; }
        public string start24 { get; set; }
        public string end24 { get; set; }
        public int cnn { get; set; }
        public DateTime? addr_Date_Create { get; set; }
        public DateTime? addr_Date_Modified { get; set; }
        public string block { get; set; }
        public string lot { get; set; }
        public string coldTruck { get; set; }
        public string applicant { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public string location { get; set; }
    }
}