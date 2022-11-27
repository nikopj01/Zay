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
        public IEnumerable<Product> GetProducts(string keyWord)
        {
            throw new NotImplementedException();
        }
    }
}
