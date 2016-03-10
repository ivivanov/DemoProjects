using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTests
{
    public class BarsDbContext : DbContext
    {
        public BarsDbContext() : base("BarsConStr")
        {
            Database.SetInitializer<BarsDbContext>(new DropCreateDatabaseIfModelChanges<BarsDbContext>());
        }
        public DbSet<Bar> Bars { get; set; }
    }
}
