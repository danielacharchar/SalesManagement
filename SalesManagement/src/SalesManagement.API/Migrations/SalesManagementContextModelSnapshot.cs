using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SalesManagement.Data;

namespace SalesManagement.API.Migrations
{
    [DbContext(typeof(SalesManagementContext))]
    partial class SalesManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalesManagement.Model.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("IdentityCard")
                        .IsRequired();

                    b.Property<string>("Mobile");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 9, 17, 23, 9, 31, 327, DateTimeKind.Local));

                    b.Property<Guid>("UniqueKey");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("PaymentType");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int>("ProductTypeId");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("Unit");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CashierId");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("PaymentTypeId");

                    b.Property<int>("SellerId");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("CashierId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("SellerId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.SaleCommission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("PaymentDate");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<int>("SaleId");

                    b.Property<int>("SellerId");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.HasIndex("SellerId");

                    b.ToTable("SaleCommission");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.SaleProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.Property<double>("Quantity");

                    b.Property<int>("SaleId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleProduct");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CommissionValue");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<bool>("IsLocked");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.Price", b =>
                {
                    b.HasOne("SalesManagement.Model.Entities.Product", "Product")
                        .WithMany("Prices")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.Product", b =>
                {
                    b.HasOne("SalesManagement.Model.Entities.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.Sale", b =>
                {
                    b.HasOne("SalesManagement.Model.Entities.User", "Cashier")
                        .WithMany("SalesAsCashier")
                        .HasForeignKey("CashierId");

                    b.HasOne("SalesManagement.Model.Entities.Customer", "Customer")
                        .WithMany("Purchases")
                        .HasForeignKey("CustomerId");

                    b.HasOne("SalesManagement.Model.Entities.PaymentType")
                        .WithMany("Sales")
                        .HasForeignKey("PaymentTypeId");

                    b.HasOne("SalesManagement.Model.Entities.User", "Seller")
                        .WithMany("SalesAsSeller")
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.SaleCommission", b =>
                {
                    b.HasOne("SalesManagement.Model.Entities.Sale", "Sale")
                        .WithMany("SaleCommissions")
                        .HasForeignKey("SaleId");

                    b.HasOne("SalesManagement.Model.Entities.User", "Seller")
                        .WithMany("SaleCommissions")
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.SaleProduct", b =>
                {
                    b.HasOne("SalesManagement.Model.Entities.Product", "Product")
                        .WithMany("SaleProducts")
                        .HasForeignKey("ProductId");

                    b.HasOne("SalesManagement.Model.Entities.Sale", "Sale")
                        .WithMany("SaleProducts")
                        .HasForeignKey("SaleId");
                });

            modelBuilder.Entity("SalesManagement.Model.Entities.UserRole", b =>
                {
                    b.HasOne("SalesManagement.Model.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("SalesManagement.Model.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });
        }
    }
}
