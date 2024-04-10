using System;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
namespace TestNetTopoSuite
{
    class MainClass
    {
        static Func<int, int, int> f = (i, j) => i + j;

        static Geometry caBoundary = ShatamGeometry.ToGeometry(ShatamGeometry.CreateEnvelope(-124.409591, 32.534156, -114.131211, 42.009518));

        public static void Main3(string[] args)
        {




            Test(new Point(-114.131211, 42.009518)); //california
            Test(new Point(-124.409591, 32.534156)); //california
            Test(new Point(-116.2495132186607, 41.420533957779625));

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject("Success"));

        }

        static void Test(Point point)
        {
            if (caBoundary.Intersects(point))
            {
                Console.WriteLine("In California");
            }else
                Console.WriteLine("Not in California");
        }
        public static void Main2(string[] args)
        {
            Console.WriteLine("Test");
            WKTReader reader = new WKTReader();
            Geometry point = reader.Read("POINT (-117.7161599866112 34.06395501063417)");

            Geometry searchPoint = reader.Read("POINT (-117.7159560015895 34.064655584445674)"); //78.85m //True

            searchPoint = reader.Read("POINT (-117.71726277153903 34.06394938600928)");  //100.59 m (330.03 ft) //False

            searchPoint = reader.Read("POINT (-117.71694707945687 34.06395872613042)");  //71.51 m (234.62 ft) //True

            searchPoint = reader.Read("POINT (-117.71708613430256 34.064431957588866)");  //99.50 m (326.43 ft) //False

            searchPoint = reader.Read("POINT (-117.71662762913563 34.06436035036683)");  //60.23 m (197.59 ft) //True

            searchPoint = reader.Read("POINT (-117.71551143213087 34.06395249938311)");  //60.39 m (198.13 ft) //False



            //searchPoint = reader.Read("POINT (-117.717173724432 34.06394899883763)"); //101.30 m //True

            //searchPoint = reader.Read("POINT (-117.65282445202179 34.18370590092451)"); //14.55km //True

            //searchPoint = reader.Read("POINT (-119.36442863810765 34.6146402741978)"); //162.48 km (100.96 mi) //True



            Console.WriteLine(point.EqualsExact(searchPoint, 0.001));
        }

        public static void Main1(string[] args)
        {
            int result = f(5, 6);

            Console.WriteLine("Hello World! ::" + result);
            Student s1 = new Student() { Id = 1, Name = "Sawan Meshram" };
            Type type = s1.GetType();
            Console.WriteLine(type);
            Console.WriteLine(type.GetMember("Name"));
            Console.WriteLine(type.GetProperty("Name"));
            Console.WriteLine(type.GetProperty("Name").GetValue(s1, null));
            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                Console.WriteLine(property.Name);
            }

            TestJsonConvert.ConvertJsonToDictionary();
            Console.ReadLine();
            //            CreateEnvelopeToPolygon.Create();
        }
    }
}
