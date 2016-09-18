using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SalesManagement.Model;
using SalesManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Data
{
    public class SalesManagementContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleCommission> SaleCommissions { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }

        public SalesManagementContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            #region Customer
            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Customer>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Customer>()
                .Property(s => s.IdentityCard)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(s => s.RegistrationDate)
                .HasDefaultValue(DateTime.Now);

            //modelBuilder.Entity<Customer>()
            //    .HasMany(s => s.Purchases).WithOne(r => r.Customer).HasForeignKey(r => r.CustomerId);
            #endregion

            #region PaymentType
            modelBuilder.Entity<PaymentType>()
                .ToTable("PaymentType");

            modelBuilder.Entity<PaymentType>()
                .Property(s => s.RegistrationDate)
                .IsRequired();

            modelBuilder.Entity<PaymentType>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
            #endregion

            #region Price
            modelBuilder.Entity<Price>()
                .ToTable("Price");

            //modelBuilder.Entity<Price>()
            //    .Property(s => s.Product)
            //    .IsRequired();

            modelBuilder.Entity<Price>()
                .Property(s => s.RegistrationDate)
                .IsRequired();

            modelBuilder.Entity<Price>()
                .Property(s => s.Value)
                .IsRequired();

            modelBuilder.Entity<Price>()
                .HasOne(a => a.Product)
                .WithMany(u => u.Prices)
                .HasForeignKey(a => a.ProductId);
            #endregion

            #region Product
            modelBuilder.Entity<Product>()
                .ToTable("Product");

            modelBuilder.Entity<Product>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Product>()
                .Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(2000);

            modelBuilder.Entity<Product>()
                .Property(s => s.RegistrationDate)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(m => m.ProductTypeId)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne(a => a.ProductType)
                .WithMany(u => u.Products)
                .HasForeignKey(a => a.ProductTypeId);
            #endregion

            #region ProductType
            modelBuilder.Entity<ProductType>()
                .ToTable("ProductType");

            modelBuilder.Entity<ProductType>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<ProductType>()
                .Property(s => s.RegistrationDate)
                .IsRequired();
            
            #endregion

            #region Role
            modelBuilder.Entity<Role>()
                .ToTable("Role");
            
            modelBuilder.Entity<Role>()
                .Property(ur => ur.Name)
                .IsRequired()
                .HasMaxLength(50);
            #endregion

            #region User
            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);
            
            modelBuilder.Entity<User>()
                .Property(u => u.HashedPassword)
                .IsRequired()
                .HasMaxLength(200);
            
            modelBuilder.Entity<User>()
                .Property(u => u.IsLocked)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.DateCreated);
            
            #endregion

            #region UserRole
            modelBuilder.Entity<UserRole>()
                .ToTable("UserRole");

            modelBuilder.Entity<UserRole>()
                .Property(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<UserRole>()
                .Property(ur => ur.RoleId)
                .IsRequired();
                        
            #endregion

            #region Sale
            modelBuilder.Entity<Sale>()
                .ToTable("Sale");

            modelBuilder.Entity<Sale>()
                .Property(s => s.Status)
                .HasDefaultValue(SaleStatus.Opened);
                        
            modelBuilder.Entity<Sale>()
                .HasOne(a => a.Cashier)
                .WithMany(u => u.SalesAsCashier)
                .HasForeignKey(a => a.CashierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sale>()
                .HasOne(a => a.Seller)
                .WithMany(u => u.SalesAsSeller)
                .HasForeignKey(a => a.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sale>()
                .HasOne(a => a.Customer)
                .WithMany(u => u.Purchases)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Sale>()
                .HasMany(m => m.SaleProducts)
                .WithOne(n => n.Sale)
                .IsRequired()
                .HasForeignKey(s => s.SaleId);
            #endregion

            #region SaleCommission
            modelBuilder.Entity<SaleCommission>()
                .ToTable("SaleCommission");

            modelBuilder.Entity<SaleCommission>()
               .Property(u => u.PaymentDate)
               .IsRequired();

            modelBuilder.Entity<SaleCommission>()
               .Property(u => u.RegistrationDate)
               .IsRequired();

            modelBuilder.Entity<SaleCommission>()
               .Property(u => u.SaleId)
               .IsRequired();

            modelBuilder.Entity<SaleCommission>()
               .Property(u => u.SellerId)
               .IsRequired();
            
            modelBuilder.Entity<SaleCommission>()
               .Property(u => u.Value)
               .IsRequired();

            modelBuilder.Entity<SaleCommission>()
                .HasOne(a => a.Sale)
                .WithMany(u => u.SaleCommissions)
                .HasForeignKey(a => a.SaleId);

            modelBuilder.Entity<SaleCommission>()
                .HasOne(a => a.Seller)
                .WithMany(u => u.SaleCommissions)
                .HasForeignKey(a => a.SellerId);

            #endregion
            
            #region SaleProduct
            modelBuilder.Entity<SaleProduct>()
                .ToTable("SaleProduct");

            modelBuilder.Entity<SaleProduct>()
               .Property(u => u.ProductId)
               .IsRequired();

            modelBuilder.Entity<SaleProduct>()
               .Property(u => u.SaleId)
               .IsRequired();

            modelBuilder.Entity<SaleProduct>()
               .Property(u => u.Quantity)
               .IsRequired();
            
            modelBuilder.Entity<SaleProduct>()
                .HasOne(a => a.Sale)
                .WithMany(u => u.SaleProducts)
                .HasForeignKey(a => a.SaleId);

            modelBuilder.Entity<SaleProduct>()
                .HasOne(a => a.Product)
                .WithMany(u => u.SaleProducts)
                .HasForeignKey(a => a.ProductId);

            #endregion
            
            //modelBuilder.Entity<Customer>()
            //    .HasOne(s => s.Creator)
            //    .WithMany(c => c.SchedulesCreated);


        }
    }
}
