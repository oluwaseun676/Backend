using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Core.Models.User;
using Core.Models;
using Microsoft.Extensions.Configuration;

namespace Persistence.Data
{
    public class OnlineReservationContext : DbContext
    {
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<RestaurantTable> RestaurantTables => Set<RestaurantTable>();
        public DbSet<RestaurantOpeningTime> RestaurantOpeningTimes => Set<RestaurantOpeningTime>();
        public DbSet<ZipCode> Zipcodes => Set<ZipCode>();
        public DbSet<Reservation> Reservations => Set<Reservation>();

        public OnlineReservationContext(DbContextOptions<OnlineReservationContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZipCode>().HasData(
                new ZipCode() { Id=1,ZipCodeNr = "4470", Location = "Enns", District = "Linz-Land" },
                new ZipCode() { Id=2,ZipCodeNr = "4020", Location = "Linz", District = "Linz" });
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id=1,Name= "Amerikanisch" },
                new Category() { Id=2, Name="Arabisch"});
        }
    }
}
