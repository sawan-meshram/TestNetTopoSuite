using System;
using System.IO;

using NetTopologySuite.Geometries;
//using NetTopologySuite.Geometries.Implementation;

using NetTopologySuite.IO;

//using NetTopologySuite.Data;
using NetTopologySuite.Features;

using System.Collections;

namespace TestNetTopoSuite
{
    public class ProjectionIdentity
    {
        public static void Main(string[] agrs)
        {
            string file = "/home/shatam-25/Downloads/WaterViewCII_Project/CA_County/Riverside/Riverside_County_Address_Points/Address_Points.shp";
            using (var shapeFileDataReader = new ShapefileDataReader(file, GeometryFactory.Default))
            {


                displayShapeType(shapeFileDataReader);
                displayShapeInfo(shapeFileDataReader);


                //Display the min and max bounds of the shapefile

                Envelope bounds = shapeFileDataReader.ShapeHeader.Bounds;

                Console.WriteLine(string.Format("Min bounds: ({0},{1})", bounds.MinX, bounds.MinY));

                Console.WriteLine(string.Format("Max bounds: ({0},{1})", bounds.MaxX, bounds.MaxY));
                //readingAllRecords(shapeFileDataReader);

                //Reset the pointer to the start of the shapefile, just in case
                //shapeFileDataReader.Reset();
            }

            createShapeFiles();

        }

        static void createShapeFiles()
        {

            var geomFactory = new GeometryFactory(new PrecisionModel(), 4326);
            var wktReader = new WKTReader(geomFactory);

            string wkt = "Point(1 1)";
            var geometry = wktReader.Read(wkt);

            var featureCollection = new FeatureCollection();
            var attributeTable = new AttributesTable();
//            attributeTable.Add("Name", typeof(string));
//            attributeTable.Add("Population", typeof(int));



            //var geometryFactory = new GeometryFactory();
            var feature = new Feature(geometry, attributeTable);
            feature.Attributes.Add("Name", "City 1");
            feature.Attributes.Add("Population", 100000);
            featureCollection.Add(feature);


            // Create the directory where we will save the shapefile
            var shapeFilePath = Path.Combine("/home/shatam-25/Downloads/WaterViewCII_Project/JSONBackupForTest/ShapeTest", "Sample2");
            if (!Directory.Exists(shapeFilePath))
                Directory.CreateDirectory(shapeFilePath);

            var name = "test";
            // Construct the shapefile name. Don't add the .shp extension or the ShapefileDataWriter will 
            // produce an unwanted shapefile
            var shapeFileName = Path.Combine(shapeFilePath, name);
            var shapeFilePrjName = Path.Combine(shapeFilePath, $"{name}.prj");


            //var shapefilePath = "path/to/your/shapefile.shp";
            var writer = new ShapefileDataWriter(shapeFileName, geomFactory); //shapefilePath
            writer.Header = ShapefileDataWriter.GetHeader(feature, featureCollection.Count);
            writer.Write(featureCollection);

            // Define the desired CRS using a known EPSG code or a WKT string
            string crsWkt = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]]";

            // Create the projection file
            using (var streamWriter = new StreamWriter(shapeFilePrjName))
            {
                streamWriter.Write(crsWkt);
            }
        }


        static void readingAllRecords(ShapefileDataReader reader)
        {
            //Read through all records of the shapefile (geometry and attributes) into a feature collection 

            ArrayList features = new ArrayList();
            DbaseFileHeader header = reader.DbaseHeader;


            while (reader.Read())

            {

                Feature feature = new Feature();

                AttributesTable attributesTable = new AttributesTable();

                string[] keys = new string[header.NumFields];

                Geometry geometry = (Geometry)reader.Geometry;

                for (int i = 0; i < header.NumFields; i++)

                {

                    DbaseFieldDescriptor fldDescriptor = header.Fields[i];

                    keys[i] = fldDescriptor.Name;

                    attributesTable.Add(fldDescriptor.Name, reader.GetValue(i));

                }

                feature.Geometry = geometry;

                feature.Attributes = attributesTable;

                features.Add(feature);

            }
            Console.WriteLine("Total records ::" + features.Count);
        }

        //Display the shapefile type
        static void displayShapeType(ShapefileDataReader reader)
        {
            ShapefileHeader shpHeader = reader.ShapeHeader;

            Console.WriteLine(string.Format("Shape type: {0}", shpHeader.ShapeType));  //Polygon or POINT
        }

        //Display summary information about the Dbase file
        static void displayShapeInfo(ShapefileDataReader reader)
        {


            DbaseFileHeader header = reader.DbaseHeader;

            Console.WriteLine("Dbase info");

            Console.WriteLine(string.Format("{0} Columns, {1} Records", header.Fields.Length, header.NumRecords));

            for (int i = 0; i < header.NumFields; i++)
            {
                DbaseFieldDescriptor fldDescriptor = header.Fields[i];

                Console.WriteLine(string.Format("   {0} {1}", fldDescriptor.Name, fldDescriptor.DbaseType));
                Console.WriteLine(fldDescriptor.Type.Name);
            }
        }

        /*
        public string GetShapefileProjection(string shapefilePath)
        {
            // Create a shapefile reader
            ShapefileDataReader reader = new ShapefileDataReader(shapefilePath, GeometryFactory.Default);
            //ShapefileDataReader reader = new ShapefileDataReader(shapefilePath, new GeometryFactory(new PrecisionModel(), 4326));

            // Get the coordinate system
            var geometryFactory = reader.GeometryFactory;
            var coordinateSystem = geometryFactory.CoordinateReferenceSystem;

            // Get the WKT representation of the coordinate system
            string projection = coordinateSystem.ToString();

            // Clean up resources
            reader.Dispose();

            return projection;
        }
        */
    }
}
