using BasarSoftTask2_API.Entities;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
namespace BasarSoftTask2_API.Context
{
    public class MapContext:DbContext
    {
        public DbSet<LocAndUsers> LocsAndUsers { get; set; }

        private readonly IConfiguration _configuration;

        public MapContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreDbConnectionString"));
        }
    }
}
