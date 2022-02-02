using System;
using System.Globalization;

namespace LinqProjectIpi.Utils
{
    public class Misc
    {
        public static DateTime parseRFC1123Date(string date){
            date = date.Replace("UTC", "");
            DateTime result = DateTime.Parse(date);
            return result;
        }
        
    }
}