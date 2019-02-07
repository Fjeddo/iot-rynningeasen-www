using iot_rynningeasen_www.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace iot_rynningeasen_www.DataAccess
{
    public class SiteDataContext : DbContext
    {
        public DbSet<Sensors> Sensors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sitedata.db");
        }
    }
}
