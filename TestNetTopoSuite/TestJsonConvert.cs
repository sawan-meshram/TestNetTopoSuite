using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace TestNetTopoSuite
{
    public class TestJsonConvert
    {
        public TestJsonConvert()
        {
        }

        public static void ConvertJsonToDictionary()
        {

            string json = @"{""LANDSCAPE_AREA_POOLS"":""rgb(103,147,222)"",""LANDSCAPE_AREA_IRRIGABLE_NOT_IRRIGATED"":""1"",""LANDSCAPE_AREA_IRRIGABLE_NOT_IRRIGATED_TURF"":""1"",""LANDSCAPE_AREA_IRRIGABLE_NOT_IRRIGATED_CANOPY"":""1"",""LANDSCAPE_AREA_IRRIGATED"":""1"",""LANDSCAPE_AREA_BUILDINGS"":""1"",""LANDSCAPE_AREA_IMPREVIOUS"":""1"",""Current_Percent_Allocation"":""1"",""Premises"":""2"",""WD_Boundaries"":""4"",""LANDSCAPE_AREA_IRRIGATED_GRASS"":""1"",""LANDSCAPE_AREA_IRRIGATED_CANOPY"":""1"",""LANDSCAPE_AREA_NOT_IRRIGATED"":""1"",""LANDSCAPE_AREA_ARTIFICIAL_TURF"":""1""}";

            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            Console.WriteLine("Total Dictionary Count :" + dictionary.Count);
            foreach(var entry in dictionary)
            {
                Console.WriteLine(entry.Key + "<>" + entry.Value);
            }
        }
    }
}
