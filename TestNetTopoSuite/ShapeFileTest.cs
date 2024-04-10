using System;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.IO;
/*
Add Lib as follows
NetTopologySuite (main library)
NetTopologySuite.IO.ShapeFile (shapefile support)
System.Text.Encoding.CodePages package
 */
namespace TestNetTopoSuite
{
    public class ShapeFileTest
    {
        public static void Main1(string[] agrs)
        {
            // Create a new feature set
            FeatureCollection features = new FeatureCollection();

            GeometryFactory geometryFactory = new GeometryFactory();

            // Create a point geometry
            Coordinate pointCoordinate = new Coordinate(0, 0);
            Point point = geometryFactory.CreatePoint(pointCoordinate);

            // Create a line geometry
            Coordinate[] lineCoordinates = new Coordinate[]
            {
                new Coordinate(0, 0),
                new Coordinate(1, 1),
                new Coordinate(2, 0)
            };
            LineString line = geometryFactory.CreateLineString(lineCoordinates);

            // Create a polygon geometry
            Coordinate[] polygonCoordinates = new Coordinate[]
            {
                new Coordinate(0, 0),
                new Coordinate(0, 1),
                new Coordinate(1, 1),
                new Coordinate(1, 0),
                new Coordinate(0, 0)
            };
            LinearRing shell = geometryFactory.CreateLinearRing(polygonCoordinates);
            Polygon polygon = geometryFactory.CreatePolygon(shell);


            // Create features for each geometry
            Feature pointFeature = new Feature(point, new AttributesTable());
            Feature lineFeature = new Feature(line.Centroid, new AttributesTable());
            Feature polygonFeature = new Feature(polygon.Centroid, new AttributesTable());

            pointFeature.Attributes.Add("Name", "Point");
            lineFeature.Attributes.Add("Name", "Line");
            polygonFeature.Attributes.Add("Name", "Polygon");

            // Add features to the collection
            features.Add(pointFeature);
            features.Add(lineFeature);
            features.Add(polygonFeature);

            string shapefilePath = "/home/shatam-25/Downloads/WaterViewCII_Project/JSONBackupForTest/ShapeTest/Sample2.shp";

            // Create a ShapefileDataWriter and write the features to the shapefile
            ShapefileDataWriter writer = new ShapefileDataWriter(shapefilePath, geometryFactory);
            writer.Header = ShapefileDataWriter.GetHeader(features[0], features.Count);
            writer.Write(features);



            // Specify the projection file (prj)
           // string projectionFilePath = "path/to/projection_file.prj";
            //string projectionContents = "PROJCS[...your projection definition...]";
            //File.WriteAllText(projectionFilePath, projectionContents);
        }
    }
}
