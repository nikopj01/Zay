using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zay.ApplicationCore.Entities;
using Zay.ApplicationCore.Interfaces;

namespace Zay.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly IMongoCollection<Cart> _cart;

        public CartService(IMongoDbFactory mongoDbFactory)
        {
            _cart = mongoDbFactory.GetCollection<Cart>("Zay", "Cart");
        }

        public Cart GetProductsInCart(string email)
        {
            return _cart.Find(x => x.Email == email).FirstOrDefault();
        }
    }
}
