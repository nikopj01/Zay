﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zay.ApplicationCore.Entities;
using Zay.ApplicationCore.Interfaces;

namespace Zay.Infrastructure.Services
{
    internal class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _product;

        public ProductService(IMongoDbFactory mongoDbFactory)
        {
            _product = mongoDbFactory.GetCollection<Product>("Zay", "Products");
        }

        public IEnumerable<Product> GetProducts(string keyWord)
        {
            return _product.Find(x => x.Name.Contains(keyWord)).ToList();
        }

        public Product GetProductDetails(string id)
        {
            return _product.Find(x => x._id == id).FirstOrDefault();
        }
    }
}
