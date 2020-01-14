using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Globalization;

namespace AIPcoord
{
    [Serializable()]
    public class Coordinate : ICloneable, IXmlSerializable, IFormattable
    {
        #region Private fields   // Internal storage
        private double latitude;  // Expressed in seconds of degree, positive values for north
        private double longitude; // Expressed in seconds of degree, positive values for east
        #endregion

        #region Constructors
        public Coordinate()
        {
            Latitude = Longitude = 0.0f;
        }
        public Coordinate(double lat, double lon)  // Values expressed in degrees, for user convenience
        {
            Latitude = lat;
            Longitude = lon;
        }
        #endregion

        #region Properties
        public double Latitude
        {
            set
            {
                latitude = value * 3600.0f;
            }
            get
            {
                return latitude / 3600.0f;  // return degrees 
            }
        }
        public double Longitude
        {
            set
            {
                longitude = value * 3600.0f;
            }
            get
            {
                return longitude / 3600.0f;  // return degrees
            }
        }
        #endregion

        #region Public methods
        // Multi-argument setters
        public void SetD(double latDeg, double lonDeg)
        {
            latitude = latDeg * 3600;  // Convert to seconds
            longitude = lonDeg * 3600; // Convert to seconds
        }
        public void SetDM(double latDeg, double latMin, bool north, double lonDeg, double lonMin, bool east)
        {
            latitude = (latDeg * 3600 + latMin * 60) * (north ? 1 : -1);
            longitude = (lonDeg * 3600 + lonMin * 60) * (east ? 1 : -1);
        }
        public void SetDMS(double latDeg, double latMin, double latSec, bool north, double lonDeg, double lonMin, double lonSec, bool east)
        {
            latitude = (latDeg * 3600 + latMin * 60 + latSec) * (north ? 1 : -1);
            longitude = (lonDeg * 3600 + lonMin * 60 + lonSec) * (east ? 1 : -1);
        }

        // Multi-argument getters
        public void GetD(out double latDeg, out double lonDeg)
        {
            latDeg = this.latitude / 3600.0f;
            lonDeg = this.longitude / 3600.0f;
        }
        public void GetDM(out double latDeg, out double latMin, out bool north, out double lonDeg, out double lonMin, out bool east)
        {
            north = this.latitude >= 0;
            double a = Math.Abs(this.latitude);
            latDeg = (double)Math.Truncate(a / 3600.0);
            latMin = (double)(a - latDeg * 3600.0) / 60.0f;

            east = this.longitude >= 0;
            double b = Math.Abs(this.longitude);
            lonDeg = (double)Math.Truncate(b / 3600.0);
            lonMin = (double)(b - lonDeg * 3600.0) / 60.0f;
        }
        public void GetDMS(out double latDeg, out double latMin, out double latSec, out bool north, out double lonDeg, out double lonMin, out double lonSec, out bool east)
        {
            north = this.latitude >= 0;
            double a = Math.Abs(this.latitude);
            latDeg = (double)Math.Truncate(a / 3600.0);
            a -= latDeg * 3600.0;
            latMin = (double)Math.Truncate(a / 60.0);
            latSec = (double)(a - latMin * 60.0);

            east = this.longitude >= 0;
            double b = Math.Abs(this.longitude);
            lonDeg = (double)Math.Truncate(b / 3600.0);
            b -= lonDeg * 3600.0;
            lonMin = (double)Math.Truncate(b / 60.0);
            lonSec = (double)(b - lonMin * 60.0);
        }

        // Distance in meters
        public double Distance(Coordinate other)
        {
            const double rad = Math.PI / 180;

            // Use the Harversine Formula (Great circle), have a look to:
            // http://en.wikipedia.org/wiki/Great-circle_distance
            // http://williams.best.vwh.net/avform.htm (Aviation Formulary)
            double lon1 = rad * -Longitude;
            double lat1 = rad * Latitude;
            double lon2 = rad * -other.Longitude;
            double lat2 = rad * other.Latitude;

            //	d=2*asin(sqrt((sin((lat1-lat2)/2))^2 + cos(lat1)*cos(lat2)*(sin((lon1-lon2)/2))^2))
            double d = 2 * Math.Asin(Math.Sqrt(
                Math.Pow(Math.Sin((lat1 - lat2) / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin((lon1 - lon2) / 2), 2)
            ));
            return (double)(1852 * 60 * d / rad);
        }
        // Parsing method
        public void ParseIsoString(string isoStr)
        {
            // Parse coordinate in the following ISO 6709 formats:
            // Latitude and Longitude in Degrees:
            // 켆D.DDDD켆DD.DDDD/         (eg +12.345-098.765/)
            // Latitude and Longitude in Degrees and Minutes:
            // 켆DMM.MMMM켆DDMM.MMMM/     (eg +1234.56-09854.321/)
            // Latitude and Longitude in Degrees, Minutes and Seconds:
            // 켆DMMSS.SSSS켆DDMMSS.SSSS/ (eg +123456.7-0985432.1/)
            // Latitude, Longitude (in Degrees) and Altitude:
            // 켆D.DDDD켆DD.DDDD켂AA.AAA/         (eg +12.345-098.765+15.9/)
            // Latitude, Longitude (in Degrees and Minutes) and Altitude:
            // 켆DMM.MMMM켆DDMM.MMMM켂AA.AAA/     (eg +1234.56-09854.321+15.9/)
            // Latitude, Longitude (in Degrees, Minutes and Seconds) and Altitude:
            // 켆DMMSS.SSSS켆DDMMSS.SSSS켂AA.AAA/ (eg +123456.7-0985432.1+15.9/)

            if (isoStr.Length < 18)  // Check for minimum length
                isoStr = null;

            if (!isoStr.EndsWith("/"))  // Check for trailing slash
                isoStr = null;
            isoStr = isoStr.Remove(isoStr.Length - 1); // Remove trailing slash

            string[] parts = isoStr.Split(new char[] { '+', '-' }, StringSplitOptions.None);
            if (parts.Length < 3 || parts.Length > 4)  // Check for parts count
                parts = null;
            if (parts[0].Length != 0)  // Check if first part is empty
                parts = null;

            int point = parts[1].IndexOf('.');
            if (point != 2 && point != 4 && point != 6) // Check for valid lenght for lat/lon
                parts = null;
            if (point != parts[2].IndexOf('.') - 1) // Check for lat/lon decimal positions
                parts = null;

            NumberFormatInfo fi = NumberFormatInfo.InvariantInfo;

            // Parse latitude and longitude values, according to format
            if (point == 2)
            {
                latitude = double.Parse(parts[1], fi) * 3600;
                longitude = double.Parse(parts[2], fi) * 3600;
            }
            else if (point == 4)
            {
                latitude = double.Parse(parts[1].Substring(0, 2), fi) * 3600 + double.Parse(parts[1].Substring(2), fi) * 60;
                longitude = double.Parse(parts[2].Substring(0, 3), fi) * 3600 + double.Parse(parts[2].Substring(3), fi) * 60;
            }
            else  // point==8
            {
                latitude = double.Parse(parts[1].Substring(0, 2), fi) * 3600 + double.Parse(parts[1].Substring(2, 2), fi) * 60 + double.Parse(parts[1].Substring(4), fi);
                longitude = double.Parse(parts[2].Substring(0, 3), fi) * 3600 + double.Parse(parts[2].Substring(3, 2), fi) * 60 + double.Parse(parts[2].Substring(5), fi);
            }
            // Parse altitude, just to check if it is valid
            if (parts.Length == 4)
                double.Parse(parts[3], fi);

            // Add proper sign to lat/lon
            if (isoStr[0] == '-')
                latitude = -latitude;
            if (isoStr[parts[1].Length + 1] == '-')
                longitude = -longitude;
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return this.ToString(null);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;

            Coordinate other = (Coordinate)obj;
            return (this.latitude == other.latitude) && (this.longitude == other.longitude);
        }
        public override int GetHashCode()
        {
            return (latitude + longitude).GetHashCode();
        }
        #endregion

        #region IFormattable Members
        // Not really IFormattable member
        public string ToString(string format)
        {
            return this.ToString(format, null);
        }
        // ToString version with formatting
        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder sb = new StringBuilder();
            double latDeg, latMin, latSec, lonDeg, lonMin, lonSec;
            bool north, east;

            if (format == null)
                format = "DMS";

            NumberFormatInfo fi = NumberFormatInfo.InvariantInfo;

            switch (format.ToUpper())
            {
                case "":
                case "DMS":
                    this.GetDMS(out latDeg, out latMin, out latSec, out north, out lonDeg, out lonMin, out lonSec, out east);
                    sb.AppendFormat(fi, "{0:0#}�{1:0#}'{2:0#.0}\"{3} ", latDeg, latMin, latSec, (north ? "N" : "S"));
                    sb.AppendFormat(fi, "{0:0##}�{1:0#}'{2:0#.0}\"{3}", lonDeg, lonMin, lonSec, (east ? "E" : "W"));
                    break;

                case "IVAC1":
                    this.GetDMS(out latDeg, out latMin, out latSec, out north, out lonDeg, out lonMin, out lonSec, out east);
                    int latSecInt = (int)latSec;
                    int latSecDec = (int)((latSec - latSecInt) * 1000);
                    int lonSecInt = (int)lonSec;
                    int lonSecDec = (int)((lonSec - lonSecInt) * 1000);

                    sb.AppendFormat(fi, "{4}{0:000}.{1:00}.{2:00}.{3:000} {9}{5:000}.{6:00}.{7:00}.{8:000}", latDeg, latMin, latSecInt, latSecDec, (north ? "N" : "S"), lonDeg, lonMin, lonSecInt, lonSecDec, (east ? "E" : "W"));
                    break;

                case "IVAC2_LAT":
                    this.GetDMS(out latDeg, out latMin, out latSec, out north, out lonDeg, out lonMin, out lonSec, out east);
                    latSecInt = (int)latSec;
                    latSecDec = (int)((latSec - latSecInt) * 1000);

                    sb.AppendFormat(fi, "{4}{0:000}{1:00}{2:00}{3:000}", latDeg, latMin, latSecInt, latSecDec, (north ? "N" : "S"));
                    break;

                case "IVAC2_LON":
                    this.GetDMS(out latDeg, out latMin, out latSec, out north, out lonDeg, out lonMin, out lonSec, out east);
                    lonSecInt = (int)lonSec;
                    lonSecDec = (int)((lonSec - lonSecInt) * 1000);

                    sb.AppendFormat(fi, "{4}{0:000}{1:00}{2:00}{3:000}", lonDeg, lonMin, lonSecInt, lonSecDec, (east ? "E" : "W"));
                    break;

                case "WEBEYE":
                    sb.AppendFormat(fi, "{0}:{1}", Math.Round(Latitude, 6), Math.Round(Longitude, 6));
                    break;

                case "AURORA_DMS14":
                    this.GetDMS(out latDeg, out latMin, out latSec, out north, out lonDeg, out lonMin, out lonSec, out east);
                    latSecInt = (int)latSec;
                    latSecDec = (int)((latSec - latSecInt) * 1000);
                    lonSecInt = (int)lonSec;
                    lonSecDec = (int)((lonSec - lonSecInt) * 1000);

                    sb.AppendFormat(fi, "{4}{0:000}.{1:00}.{2:00}.{3:000};{9}{5:000}.{6:00}.{7:00}.{8:000};", latDeg, latMin, latSecInt, latSecDec, (north ? "N" : "S"), lonDeg, lonMin, lonSecInt, lonSecDec, (east ? "E" : "W"));
                    break;

                case "AURORA_DMS11":
                    this.GetDMS(out latDeg, out latMin, out latSec, out north, out lonDeg, out lonMin, out lonSec, out east);
                    latSecInt = (int)latSec;
                    latSecDec = (int)((latSec - latSecInt) * 1000);
                    lonSecInt = (int)lonSec;
                    lonSecDec = (int)((lonSec - lonSecInt) * 1000);

                    sb.AppendFormat(fi, "{4}{0:000}{1:00}{2:00}{3:000};{9}{5:000}{6:00}{7:00}{8:000};", latDeg, latMin, latSecInt, latSecDec, (north ? "N" : "S"), lonDeg, lonMin, lonSecInt, lonSecDec, (east ? "E" : "W"));
                    break;

                case "AURORA_DEC":
                    sb.AppendFormat(fi, "{0};{1};", Math.Round(Latitude, 8), Math.Round(Longitude, 8));
                    break;

                case "D":
                    sb.AppendFormat(fi, "{0:0#.0000}�{1} ", Math.Abs(Latitude), (latitude > 0 ? "N" : "S"));
                    sb.AppendFormat(fi, "{0:0##.0000}�{1}", Math.Abs(Longitude), (longitude > 0 ? "E" : "W"));
                    break;
                case "DM":
                    this.GetDM(out latDeg, out latMin, out north, out lonDeg, out lonMin, out east);
                    sb.AppendFormat(fi, "{0:0#}�{1:0#.00}'{2} ", latDeg, latMin, (north ? "N" : "S"));
                    sb.AppendFormat(fi, "{0:0##}�{1:0#.00}'{2}", lonDeg, lonMin, (east ? "E" : "W"));
                    break;
                case "ISO":
                    // Write coordinate according with ISO 6709
                    // Latitude and Longitude in Degrees, Minutes and Seconds:
                    // 켆DMMSS.SSSS켆DDMMSS.SSSS/ (eg +123456.7-0985432.1/)

                    this.GetDMS(out latDeg, out latMin, out latSec, out north, out lonDeg, out lonMin, out lonSec, out east);
                    sb.AppendFormat(fi, "{0}{1:0#}{2:0#}{3:0#.0#}", (north ? "+" : "-"), latDeg, latMin, latSec);
                    sb.AppendFormat(fi, "{0}{1:0##}{2:0#}{3:0#.0#}/", (east ? "+" : "-"), lonDeg, lonMin, lonSec);
                    break;
                default:
                    throw new Exception("Coordinate.ToString(): Invalid formatting string.");
            }
            return sb.ToString();
        }
        #endregion

        #region ICloneable Members
        object ICloneable.Clone()
        {
            return new Coordinate(this.Latitude, this.Longitude);
        }
        #endregion

        #region IXmlSerializable Members
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            try
            {
                string str = reader.ReadElementContentAsString().Trim();
                this.ParseIsoString(str);
            }
            catch
            {
                throw new Exception("Coordinate.ReadXml: Error parsing coordinate");
            }
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteString(this.ToString("ISO"));
        }
        #endregion
    }

    [Serializable()]
    public class CoordinateList : List<Coordinate>, IXmlSerializable
    {
        #region Constructors
        public CoordinateList()
        {
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Coordinate coord in this)
            {
                sb.Append(coord.ToString("ISO"));
            }
            return sb.ToString();
        }
        #endregion

        #region Public methods
        // Parsing method
        public void ParseIsoString(string isoStr)
        {
            string[] coords = isoStr.Split('/');

            this.Clear();   // Clear previous list
            for (int i = 1; i < coords.Length; i++)
            {
                Coordinate coord = new Coordinate();
                coord.ParseIsoString(coords[i - 1] + "/");
                this.Add(coord);
            }
        }
        #endregion

        #region IXmlSerializable Members
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            try
            {
                string str = reader.ReadElementContentAsString().Trim();
                this.ParseIsoString(str);
            }
            catch
            {
                throw new Exception("CoordinateList.ReadXml: Error parsing coordinate list");
            }
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteString(this.ToString());
        }
        #endregion
    }
}
