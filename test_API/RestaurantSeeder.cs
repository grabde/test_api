using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_API.Entities;

namespace test_API
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "Testowy opis",
                    ContactEmail = "denisgrabiszewski98@gmail.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Klops",
                            Price = 10.99M,
                        },
                        new Dish()
                        {
                            Name = "Kebs",
                            Price = 13.99M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Poznań",
                        Street = "No",
                        PostalCode = "62-093",
                    }
                },
                new Restaurant()
                {
                    Name = "MC",
                    Category = "Fast Food",
                    Description = "Testowy opis",
                    ContactEmail = "denisgrabiszewski98@gmail.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "McWrap",
                            Price = 10.99M,
                        },
                        new Dish()
                        {
                            Name = "Cola",
                            Price = 13.99M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Poznań",
                        Street = "MC",
                        PostalCode = "62-093",
                    }
                }
            };
            return restaurants;
        }
    }
}
