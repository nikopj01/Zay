using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zay.ApplicationCore.Entities;

namespace Zay.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders(string email);
        void SaveOrder(Order order);
    }
}
