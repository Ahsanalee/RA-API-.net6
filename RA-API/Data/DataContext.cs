using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RA_API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<RA_Tech> RAs { get; set; } 
    }
}
