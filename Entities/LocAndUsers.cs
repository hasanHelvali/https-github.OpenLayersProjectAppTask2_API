using NetTopologySuite;
using NetTopologySuite.Geometries;
namespace BasarSoftTask2_API.Entities
{
    public class LocAndUsers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
    }
}
