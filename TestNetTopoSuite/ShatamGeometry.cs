using System;
using NetTopologySuite.Geometries;

namespace TestNetTopoSuite
{
    public class ShatamGeometry
    {
        private ShatamGeometry()
        {
        }

        private static NetTopologySuite.IO.WKTReader wktReader = new NetTopologySuite.IO.WKTReader();
        private static GeometryFactory geometryFactory = new GeometryFactory();

        /// <summary>
        /// Converts a Well-known Text representation to a <c>Geometry</c>.
        /// </summary>
        /// <param name="wellKnownText">
        /// one or more Geometry Tagged Text strings (see the OpenGIS
        /// Simple Features Specification) separated by whitespace.
        /// </param>
        /// <returns>
        /// A <c>Geometry</c> specified by <c>wellKnownText</c>
        /// </returns>
        public static Geometry Read(string wellKnownText)
        {
            return wktReader.Read(wellKnownText);
        }

        /// <summary>
        /// Creates the coordinate. Where, X is typically longitude and Y is typically latitude.
        /// </summary>
        /// <returns>Initializes a new instance of the Coordinate class.</returns>
        /// <param name="x">X is typically longitude. X-coordinates are between -180 and +180 degrees.</param>
        /// <param name="y">Y is typically latitude. Y-coordinates are range between -90 and +90 degrees.</param>
        public static Coordinate CreateCoordinate(string x, string y)
        {
            return CreateCoordinate(Convert.ToDouble(x), Convert.ToDouble(y));
        }

        /// <summary>
        /// Creates the coordinate. Where, X is typically longitude and Y is typically latitude.
        /// </summary>
        /// <returns>Initializes a new instance of the Coordinate class.</returns>
        /// <param name="x">X is typically longitude. X-coordinates are between -180 and +180 degrees.</param>
        /// <param name="y">Y is typically latitude. Y-coordinates are range between -90 and +90 degrees.</param>
        public static Coordinate CreateCoordinate(double x, double y)
        {
            return new Coordinate(x, y);
        }

        /// <summary>
        /// Creates the point.
        /// </summary>
        /// <returns>Initializes a new instance of the Point class.</returns>
        /// <param name="coordinate">The coordinate used for create this Point.</param>
        public static Point CreatePoint(Coordinate coordinate)
        {
            return new Point(coordinate);
        }

        /// <summary>
        /// Creates the point. Where, X is typically longitude and Y is typically latitude.
        /// </summary>
        /// <returns>Initializes a new instance of the Point class.</returns>
        /// <param name="x">X is typically longitude. X-coordinates are between -180 and +180 degrees.</param>
        /// <param name="y">Y is typically latitude. Y-coordinates are range between -90 and +90 degrees.</param>
        public static Point CreatePoint(string x, string y)
        {
            return CreatePoint(Convert.ToDouble(x), Convert.ToDouble(y));
        }

        /// <summary>
        /// Creates the point. Where, X is typically longitude and Y is typically latitude.
        /// </summary>
        /// <returns>Initializes a new instance of the Point class.</returns>
        /// <param name="x">X is typically longitude. X-coordinates are between -180 and +180 degrees.</param>
        /// <param name="y">Y is typically latitude. Y-coordinates are range between -90 and +90 degrees.</param>
        public static Point CreatePoint(double x, double y)
        {
            return new Point(x, y);
        }

        /// <summary>
        /// Creates the envelope.
        /// </summary>
        /// <returns>The envelope.</returns>
        /// <param name="x1">x1 represent min x-value.</param>
        /// <param name="y1">y1 represent min y-value.</param>
        /// <param name="x2">x2 represent max x-value.</param>
        /// <param name="y2">y2 represent max y-value.</param>
        public static Envelope CreateEnvelope(string x1, string y1, string x2, string y2)
        {
            return CreateEnvelope(Convert.ToDouble(x1), Convert.ToDouble(y1), Convert.ToDouble(x2), Convert.ToDouble(y2));
        }
        /// <summary>
        /// Creates the envelope.
        /// </summary>
        /// <returns>The envelope.</returns>
        /// <param name="x1">x1 represent min x-value.</param>
        /// <param name="y1">y1 represent min y-value.</param>
        /// <param name="x2">x2 represent max x-value.</param>
        /// <param name="y2">y2 represent max y-value.</param>
        public static Envelope CreateEnvelope(double x1, double y1, double x2, double y2)
        {
            return new Envelope(new Coordinate(x1, y1), new Coordinate(x2, y2));
        }
        /// <summary>
        /// Creates the envelope.
        /// </summary>
        /// <returns>The envelope.</returns>
        /// <param name="p1">p1 coordinate represent min xy-value.</param>
        /// <param name="p2">p2 coordinate represent max xy-value.</param>
        public static Envelope CreateEnvelope(Coordinate p1, Coordinate p2)
        {
            return new Envelope(p1, p2);
        }

        /// <summary>
        /// Creates the geometry. Mostly, geometry type will be Polygon.
        /// </summary>
        /// <returns>The geometry.</returns>
        /// <param name="envelope">Envelope.</param>
        public static Geometry ToGeometry(Envelope envelope)
        {
            return geometryFactory.ToGeometry(envelope);
        }

        /// <summary>
        /// Tests whether this geometry contains the argument geometry.
        /// </summary>
        /// <returns><c>true</c>, if contains was ised, <c>false</c> otherwise.</returns>
        /// <param name="geometry">The geometry to verify contains.</param>
        /// <param name="g">Check geometry.</param>
        public static bool IsContains(Geometry geometry, Geometry g)
        {
            return geometry.Contains(g);
        }

        /// <summary>
        /// Tests whether this geometry covers the argument geometry
        /// </summary>
        /// <returns><c>true</c>, if covers was ised, <c>false</c> otherwise.</returns>
        /// <param name="geometry">The geometry to verify covers.</param>
        /// <param name="g">Check geometry.</param>
        public static bool IsCovers(Geometry geometry, Geometry g)
        {
            return geometry.Covers(g);
        }

        /// <summary>
        /// Tests whether this geometry crosses the specified geometry.
        /// </summary>
        /// <returns><c>true</c>, if crosses was ised, <c>false</c> otherwise.</returns>
        /// <param name="geometry">The geometry to verify cross.</param>
        /// <param name="g">Check geometry.</param>
        public static bool IsCrosses(Geometry geometry, Geometry g)
        {
            return geometry.Crosses(g);
        }

        /// <summary>
        /// Tests whether this geometry is covered by the specified geometry.
        /// </summary>
        /// <returns><c>true</c>, if covered by was ised, <c>false</c> otherwise.</returns>
        /// <param name="geometry">The geometry to verify covers.</param>
        /// <param name="g">Check geometry.</param>
        public static bool IsCoveredBy(Geometry geometry, Geometry g)
        {
            return geometry.CoveredBy(g);
        }

        /// <summary>
        /// Tests whether this geometry intersects the argument geometry.
        /// </summary>
        /// <returns><c>true</c>, if intersects was ised, <c>false</c> otherwise.</returns>
        /// <param name="geometry">The geometry to verify intersect.</param>
        /// <param name="g">Check geometry.</param>
        public static bool IsIntersects(Geometry geometry, Geometry g)
        {
            return geometry.Intersects(g);
        }

        /// <summary>
        /// Tests whether this geometry overlaps the specified geometry.
        /// </summary>
        /// <returns><c>true</c>, if overlaps was ised, <c>false</c> otherwise.</returns>
        /// <param name="geometry">The geometry to verify overlap.</param>
        /// <param name="g">Check geometry.</param>
        public static bool IsOverlaps(Geometry geometry, Geometry g)
        {
            return geometry.Overlaps(g);
        }

        /// <summary>
        /// Tests whether this geometry is within the specified geometry.
        /// </summary>
        /// <returns><c>true</c>, if within was ised, <c>false</c> otherwise.</returns>
        /// <param name="geometry">The geometry to verify within.</param>
        /// <param name="g">Check geometry.</param>
        public static bool IsWithin(Geometry geometry, Geometry g)
        {
            return geometry.Within(g);
        }
    }
}
