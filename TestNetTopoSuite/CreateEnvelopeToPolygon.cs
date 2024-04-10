using System;
using NetTopologySuite.Geometries;
namespace TestNetTopoSuite
{
    public class CreateEnvelopeToPolygon
    {
        public CreateEnvelopeToPolygon()
        {
        }

        public static void Create()
        {
/*            CoordinateList list = new CoordinateList();
            list.Add(new Coordinate(-117.67200490892463, 34.09814467781694), true);
            list.Add(new Coordinate(-117.72436162889534, 34.06615508912267), true);
*/
            GeometryFactory factory = new GeometryFactory();
            Console.WriteLine(">>>>"+factory.CreatePoint(new Coordinate(-117.67200490892463, 34.09814467781694)));
            Console.WriteLine(">>>>" + new Point(new Coordinate(-117.67200490892463, 34.09814467781694)));
/*
            Coordinate[] coordinates = new Coordinate[2];
            coordinates[0] = new Coordinate(-117.67200490892463, 34.09814467781694);
            coordinates[1] = new Coordinate(-117.72436162889534, 34.06615508912267);


            LineString ring = factory.CreateLineString(coordinates);

            Console.WriteLine("geom ::" + ring);
            //Polygon polygon = new Polygon(new LinearRing(coordinates));
            //Console.WriteLine("geom ::"+polygon);
*/


            string bound = "34.09814467781694,-117.67200490892463,34.06615508912267,-117.72436162889534";
            string[] mapBound = bound.Split(',');
            foreach(string x in mapBound)
            {
                Console.WriteLine(x+"<<");
            }
            Envelope env = CreateEnvelope(mapBound[1], mapBound[0], mapBound[3], mapBound[2]);
            Console.WriteLine("env :" + env.ToString());
            Geometry geom = factory.ToGeometry(env);
            Console.WriteLine("geom :"+geom);
        }

        public static Envelope CreateEnvelope(string x1, string y1, string x2, string y2)
        {
            return CreateEnvelope(Convert.ToDouble(x1), Convert.ToDouble(y1), Convert.ToDouble(x2), Convert.ToDouble(y2));
        }

        public static Envelope CreateEnvelope(double x1, double y1, double x2, double y2)
        {
            return new Envelope(new Coordinate(x1, y1), new Coordinate(x2, y2));
        }
    }
}
