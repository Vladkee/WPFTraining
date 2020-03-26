using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Service
{
    public class ShopService
    {
        private StoreDbContext dbContext;
        public ShopService()
        {
            this.dbContext = new StoreDbContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return this.dbContext.Customers.Include(o => o.Orders);
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.dbContext.Products.Include(b => b.Brand).Include(c=>c.Category).Include(st=>st.Stocks);
        }
    }
}
