
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext>options)
        : base (options)
        {  
        }
        public DbSet<Product> Products { get; set; }
    }
}