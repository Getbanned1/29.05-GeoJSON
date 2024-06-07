using GeoJSON;

class Program
{
    static void Main(string[] args)
    {
        var path = Path.GetFullPath(@"testdata.json");
        var path2 = Path.GetFullPath(@"secondDot.json");
        var a = Class1.LoadGeoJSON(path);
        var b = Class1.LoadGeoJSON(path2);
        
        Class1.GetCoordinates(a);
        Class1.GetCoordinates(b);
        Console.WriteLine($"Геометрия:{Class1.GetGeometryType(a)}");
        var coord = Class1.GetCoordinates(a);
        var coord2 = Class1.GetCoordinates(b);
        Console.WriteLine($"Координаты:{coord[0]} : {coord[1]}");
        Console.WriteLine($"Координаты:{coord2[0]} : {coord2[1]}");
        var result = Class1.CalculateDistance(a, b);
        Console.WriteLine($"Расстояние между точками:{result.ToString("0.00")}км");
        Class1.SaveGeoJSON(@"trytocreate.json", a);
    }
}