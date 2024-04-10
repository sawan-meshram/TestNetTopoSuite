using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace TestNetTopoSuite
{
    public class TestJSON
    {
        public static void Main1(string[] args)
        {

            JObject stud = new JObject();
            stud.Add("name", "Sawan");

            JArray courses = new JArray();
            courses.Add("Java");
            courses.Add("C#");

            stud.Add("courses", courses);

            Console.WriteLine(stud);

            Console.WriteLine(stud.Property("name").Value);

            String response = "{\"MonthsWiseData\":" + JsonConvert.SerializeObject(stud) + "}";
            Console.WriteLine(response);

            JObject month = new JObject();
            month.Add("MonthsWiseData", stud);


            Console.WriteLine(JsonConvert.SerializeObject(month));


            Dictionary<string, int> map = new Dictionary<string, int>();
            map["Sep 20"] = 10;
            map["Oct 20"] = 11;
            map["Nov 20"] = 23;
            map["Jan 21"] = 15;
            map["Feb 20"] = 50;
            map["Mar 20"] = 23;

            JObject month1 = new JObject();
            month1.Add("MonthsWiseData", new JValue(map));


            Console.WriteLine(JsonConvert.SerializeObject(month1));
        }
    }
}
