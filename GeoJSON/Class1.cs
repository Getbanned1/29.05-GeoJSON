using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace GeoJSON
{
    public class Class1
    {
        public static GeoJSONData LoadGeoJSON(string filePath)
        {
            TextReader tr = File.OpenText(filePath);
            var read = new JsonTextReader(tr);
            JsonSerializer js = new JsonSerializer();

            var data = js.Deserialize<GeoJSONData>(read);
            return data;
        }
        public static void SaveGeoJSON(string filePath, GeoJSONData data)
        {
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }
        public static string GetGeometryType(GeoJSONData data)
        {
            return data.Geometry.Type;
        }

        public static List<double> GetCoordinates(GeoJSONData data)
        {
            return data.Geometry.Coordinates;
        }
        public static void CalculateArea(GeoJSONData data)
        {
            
        }
        public static double CalculateDistance(GeoJSONData data1, GeoJSONData data2)
        {
            var a = data1.Geometry.Coordinates;
            var b = data2.Geometry.Coordinates;
            return Math.Sqrt(Math.Pow(b[1] - a[1], 2) + Math.Pow(b[0] - a[0], 2)) * 111;
        }
    }

    public class GeoJSONData
    {
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Properties Properties { get; set; }




    }

    public class Properties
    {
        public string Name { get; set; }
    }

    public class Geometry
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
    }
}