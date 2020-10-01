using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Models
{
  public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Client1> Clients1 {get; set;}
        public DbSet<Client2> Clients2 {get; set;}
        public DbSet<Client3> Clients3 {get; set;}
        public DbSet<Client4> Clients4 {get; set;}
        public DbSet<Client5> Clients5 {get; set;}
        public DbSet<Client6> Clients6 {get; set;}
        public DbSet<Product> Products { get; set; }      
    }   
}