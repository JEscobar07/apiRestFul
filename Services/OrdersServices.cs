using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apirestful.Data;
using apirestful.Models;
using apiRestFul.DTOs;
using apiRestFul.Models;
using apiRestFul.Repositories;
using Microsoft.EntityFrameworkCore;

namespace apiRestFul.Services
{
    public class OrdersServices: IOrderRepository
    {
        private readonly AppDbContext context;

        public OrdersServices(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddOrder(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var orderFound = await GetId(id);
            if (orderFound == null)
            {
                return false;
            }
            else
            {
                orderFound.IdCustomer = null;
                context.Orders.Remove(orderFound);
                context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order> GetId(int id)
        {
            return await context.Orders.Include(r => r.Customer).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Order> Update(int id, OrderDTO order)
        {
            var orderFound = await GetId(id);
            if (orderFound == null)
            {
                return orderFound;
            }
            else
            {
                orderFound.Date = order.Date;
                orderFound.Customer.Name = order.Name;
                orderFound.Customer.Address = order.Address;
                orderFound.Customer.NumberContact = order.NumberContact;
                await context.SaveChangesAsync();
                return orderFound;
            }
        }
    }
}