using System.Collections.Generic;
using System.Linq;
using OnlineBookstoreApp.Models;

namespace OnlineBookstoreApp.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static readonly List<Order> _orders = new List<Order>();

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public Order? GetById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order order)
        {
            order.Id = _orders.Any() ? _orders.Max(o => o.Id) + 1 : 1;
            _orders.Add(order);
        }
    }
}
