using Microsoft.EntityFrameworkCore;
using ScreeningTest.Entities;

namespace ScreeningTest
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
