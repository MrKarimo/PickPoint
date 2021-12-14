using Microsoft.EntityFrameworkCore;
using PickPoint.Models.Entity;

namespace PickPoint.DataBase
{
    public class PickPointContext : DbContext
    {
        public PickPointContext(DbContextOptions<PickPointContext> options): base(options)
        { }

        public DbSet<Postamat> Postamats { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, ProductName = "Ноутбук" },
                new Product() { Id = 2, ProductName = "Телефон" },
                new Product() { Id = 3, ProductName = "Машина" });

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus() { Id = 1, Status = "Зарегистрирован" },
                new OrderStatus() { Id = 2, Status = "Принят на складе" },
                new OrderStatus() { Id = 3, Status = "Выдан курьеру" },
                new OrderStatus() { Id = 4, Status = "Доставлен в постамат" },
                new OrderStatus() { Id = 5, Status = "Доставлен получателю" },
                new OrderStatus() { Id = 6, Status = "Отменен" });

            modelBuilder.Entity<Postamat>().HasData(
                new Postamat() { PostamatNumber = "1111-111", Status = true, Address = "Дом 1" },
                new Postamat() { PostamatNumber = "2222-222", Status = false, Address = "Дом 2" },
                new Postamat() { PostamatNumber = "3333-333", Status = true, Address = "Дом 3" });

            modelBuilder.Entity<Order>().HasData(
                new Order() { Id = 1, OrderStatusId = 1, Check = 1000, PostamatId = "1111-111", PhoneNumber = "+79546511269", RecipientName = "Антон" },
                new Order() { Id = 2, OrderStatusId = 2, Check = 2000, PostamatId = "1111-111", PhoneNumber = "+79651651269", RecipientName = "Иван" },
                new Order() { Id = 3, OrderStatusId = 3, Check = 3000, PostamatId = "2222-222", PhoneNumber = "+79546516512", RecipientName = "Григорий" },
                new Order() { Id = 4, OrderStatusId = 4, Check = 4000, PostamatId = "3333-333", PhoneNumber = "+79500232695", RecipientName = "Степан" },
                new Order() { Id = 5, OrderStatusId = 5, Check = 5000, PostamatId = "1111-111", PhoneNumber = "+79598410324", RecipientName = "Игорь" },
                new Order() { Id = 6, OrderStatusId = 6, Check = 6000, PostamatId = "2222-222", PhoneNumber = "+76541980098", RecipientName = "Никита" });

            modelBuilder.Entity<Goods>().HasData(
                new Goods() { Id = 1, OrderId = 1, ProductId = 1 },
                new Goods() { Id = 2, OrderId = 1, ProductId = 2 },
                new Goods() { Id = 3, OrderId = 2, ProductId = 2 },
                new Goods() { Id = 4, OrderId = 3, ProductId = 1 },
                new Goods() { Id = 5, OrderId = 4, ProductId = 3 },
                new Goods() { Id = 6, OrderId = 4, ProductId = 2 },
                new Goods() { Id = 7, OrderId = 4, ProductId = 2 },
                new Goods() { Id = 8, OrderId = 5, ProductId = 1 },
                new Goods() { Id = 9, OrderId = 5, ProductId = 2 },
                new Goods() { Id = 10, OrderId = 5, ProductId = 3 },
                new Goods() { Id = 11, OrderId = 6, ProductId = 1 },
                new Goods() { Id = 12, OrderId = 6, ProductId = 3 },
                new Goods() { Id = 13, OrderId = 6, ProductId = 2 },
                new Goods() { Id = 14, OrderId = 6, ProductId = 3 });
        }
    }
}
