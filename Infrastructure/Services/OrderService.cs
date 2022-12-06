using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zay.ApplicationCore.Entities;
using Zay.ApplicationCore.Interfaces;

namespace Zay.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Order> _cart;

        public OrderService(IMongoDbFactory mongoDbFactory)
        {
            _order = mongoDbFactory.GetCollection<Order>("Zay", "Orders");
            _cart = mongoDbFactory.GetCollection<Order>("Zay", "Carts");
        }

        public IEnumerable<Order> GetOrders(string email)
        {
            return _order.Find(x => x.Email == email).ToList();
        }

        public void SaveOrder(Order order)
        {
            _order.InsertOne(order);
            //_cart.FindOneAndDelete(x => x.Email == order.Email);
        }
    }
}
