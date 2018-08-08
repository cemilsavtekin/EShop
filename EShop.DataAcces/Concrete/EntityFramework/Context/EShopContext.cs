using EShop.Entities.Concrete;
using EShop.Entities.Concrete.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataAcces.Concrete.EntityFramework.Context
{
    public class EShopContext:DbContext
    {
        public EShopContext():base("EShop")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AddressDetail> AddressDetails { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Resim> Resimler { get; set; }

    }
}
