using System.Collections.Generic;
using OnlineBookstoreApp.Models;

namespace OnlineBookstoreApp.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order? GetById(int id);
        void Add(Order order);
    }
}
