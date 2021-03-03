using ShoesShopWebApp.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.DAL
{
    public class Context : DbContext
    {

        public Context() { }

        public Context(DbContextOptions <Context> options) : base(options) { }

        public DbSet <Product> Product { get; set; }

        public DbSet <Category> Category { get; set; }

        public DbSet <Brand> Brand { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Cart> Cart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ShoesShopDB;Trusted_Connection=True;"); //Windows Authencation
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(sc => new { sc.OrderID, sc.ProductID });


            modelBuilder.Entity<OrderDetails>()
                .HasOne<Orders>(sc => sc.Orders)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(sc => sc.OrderID);


            modelBuilder.Entity<OrderDetails>()
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(sc => sc.ProductID);


            modelBuilder.Entity<Orders>()
                .HasOne(m => m.Customer)
                .WithMany(m => m.OrdersByCus)
                .HasForeignKey(m => m.CusId);


            modelBuilder.Entity<Orders>()
               .HasOne(m => m.Employee)
               .WithMany(m => m.OrdersByEmp)
               .HasForeignKey(m => m.EmpId);


            modelBuilder.Entity<Cart>().HasKey(sc => new { sc.Account, sc.ProductID });


            modelBuilder.Entity<Cart>()
                .HasOne<Customer>(sc => sc.Customer)
                .WithMany(s => s.Cart)
                .HasForeignKey(sc => sc.Account);

            modelBuilder.Entity<Cart>()
               .HasOne<Product>(sc => sc.Product)
               .WithMany(s => s.Cart)
               .HasForeignKey(sc => sc.ProductID);
        }
    }
}
