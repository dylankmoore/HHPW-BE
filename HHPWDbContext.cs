using Microsoft.EntityFrameworkCore;
using HHPW.Models;
using System.Runtime.CompilerServices;

public class HHPWDbContext : DbContext
{

    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public HHPWDbContext(DbContextOptions<HHPWDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seeding Items
        modelBuilder.Entity<Item>().HasData(new Item[]
        {
        new Item {ItemId = 1, Name = "Pepperoni Pizza", Price = 20},
        new Item {ItemId = 2, Name = "Cheese Pizza", Price = 18},
        new Item {ItemId = 3, Name = "Veggie Supreme Pizza", Price = 22},
        new Item {ItemId = 4, Name = "8pc Hot Wings", Price = 16},
        new Item {ItemId = 5, Name = "Ranch", Price = 2},
        new Item {ItemId = 6, Name = "Hot Sauce", Price = 3},
        new Item {ItemId = 7, Name = "Garlic Bread", Price = 14},
        new Item {ItemId = 8, Name = "Spicy Marg Pizza", Price = 19}
        });

        // Seeding Users
        modelBuilder.Entity<User>().HasData(new User[]
        {
        new User { UserId = 1, FirebaseKey = "BcS4IidUlKN6C5itScUEufIaQAG3", Name = "Lilith Sternin"},
        new User { UserId = 2, FirebaseKey = "firebaseKey2", Name = "Niles Crane"},
        });

        // Seeding Orders
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
        new Order { 
            OrderId = 1, 
            IsOpen = true, 
            CustomerName = "Roz Doyle", 
            CustomerPhone = "(615)123-4567", 
            Email = "roz@kacl.org", 
            IsPhone = true, 
            UserId = 1, 
            OrderTime = new DateTime(2024, 4, 1, 10, 0, 0),
            RevTotal = 100, 
            Tip = 50, 
            PaymentType = "Credit" },
        new Order {
            OrderId = 2,
            IsOpen = true,
            CustomerName = "Frasier Crane",
            CustomerPhone = "(615)111-2222",
            Email = "frasier@kacl.org",
            IsPhone = false,
            UserId = 2,
            OrderTime = new DateTime(2024, 4, 3, 12, 0, 0),
            RevTotal = 40,
            Tip = 20,
            PaymentType = "Cash" },
        new Order {
            OrderId = 3,
            IsOpen = false,
            CustomerName = "Daphne Moon",
            CustomerPhone = "(615)222-4567",
            Email = "daphnemoon@hotmail.com",
            IsPhone = true,
            UserId = 1,
            OrderTime = new DateTime(2024, 4, 3, 5, 0, 0),
            CloseTime = new DateTime(2024, 4, 3, 6, 0, 0),
            RevTotal = 70,
            Tip = 30,
            PaymentType = "Debit" },
        });

        modelBuilder.Entity<OrderItem>().HasData(new OrderItem[]
        {
        new OrderItem { OrderItemId = 1, OrderId = 1, ItemId = 1},
        new OrderItem { OrderItemId = 2, OrderId = 1, ItemId = 1},
        new OrderItem { OrderItemId = 3, OrderId = 2, ItemId = 3}
});
    }
}