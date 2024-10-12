using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Models;
using apiRestFul.DTOs;
using apiRestFul.Models;

namespace apiRestFul.Repositories
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetAll();
        public Task<Order> GetId(int id);
        public Task AddOrder(Order order);
        public Task<int> AddCustomer(Customer Customer);
        public Task<Order> Update(int id, OrderDTO order);
        public Task<bool> Delete(int id);
    }
}