using Core.Contracts;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.ContentModel;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit.Sdk;

namespace Tischreservierung.Tests.RestaurantTest.Repository
{
    public class GenericRepositoryTest
    {
        private readonly OnlineReservationContext _context;

        public GenericRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<OnlineReservationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new OnlineReservationContext(optionsBuilder.Options);
           }

        [Fact]
        public async void GetById()
        {
            int id = 10;
            Restaurant restaurant = new() { Id = id };

            _context.Add(restaurant);
            _context.SaveChanges();

            var repository = new GenericRepository<Restaurant>(_context);
            var result = await repository.GetById(id);

            Assert.NotNull(result);
            Assert.Equal(restaurant, result);
        }

        [Fact]
        public async void GetAll()
        {
            List<Restaurant> restaurants = new()
            {
                new Restaurant() { Id = 10 },
                new Restaurant() { Id = 11 },
                new Restaurant() { Id = 12 },
                new Restaurant() { Id = 13 }
            };

            _context.AddRange(restaurants);
            _context.SaveChanges();

            var repository = new GenericRepository<Restaurant>(_context);
            var result = await repository.GetAll();

            Assert.NotNull(result);
            Assert.Equal(restaurants.Count, result.Count());
        }

        [Fact]
        public void Insert()
        {
            Restaurant restaurant = new();

            var repository = new GenericRepository<Restaurant>(_context);
            repository.Insert(restaurant);
            _context.SaveChanges();

            Assert.Single(_context.Restaurants);
        }

        [Fact]
        public async void Update()
        {
            int id = 10;
            Restaurant restaurant = new() { Id = id };

            _context.Add(restaurant);
            _context.SaveChanges();

            restaurant.Name = "Restaurant";

            var repository = new GenericRepository<Restaurant>(_context);
            repository.Update(restaurant);
            _context.SaveChanges();

            var result = await repository.GetById(id);

            Assert.NotNull(result);
            Assert.Equal(restaurant, result);
        }

        [Fact]
        public void Delete()
        {
            int id = 10;
            Restaurant restaurant = new() { Id = id };

            _context.Add(restaurant);
            _context.SaveChanges();

            var repository = new GenericRepository<Restaurant>(_context);
            repository.Delete(restaurant);
            _context.SaveChanges();

            Assert.Empty(_context.Restaurants);
        }
    }
}
