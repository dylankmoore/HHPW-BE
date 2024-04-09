using HHPW.Models;
using HHPW_BE.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HHPW_BE.Controllers
{
    public class OrderAPI
    {
        public static void Map(WebApplication app)
        {
            //GET all orders
            app.MapGet("/orders", (HHPWDbContext db) =>
            {
                var orders = db.Orders
                               .Include(o => o.Items)
                               .ToList();

                return Results.Ok(orders);
            });

            //GET order by id
            app.MapGet("/orders/{id}", (HHPWDbContext db, int id) =>
            {
                var order = db.Orders
                    .Where(o => o.OrderId == id)
                    .Select(o => new
                    {
                        o.OrderId,
                        OrderStatus = o.IsOpen ? "open" : "closed",
                        o.CustomerName,
                        o.CustomerPhone,
                        o.Email,
                        OrderType = o.IsPhone ? "phone" : "in-person",
                        o.UserId,
                        o.OrderTime,
                        o.CloseTime,
                        o.RevTotal,
                        o.Tip,
                        o.PaymentType,
                        Items = o.Items.Select(oi => new
                        {
                            ItemName = oi.Item.Name,
                            oi.Item.Price
                        }).ToList()
                    })
                    .FirstOrDefault();

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                return Results.Ok(order);
            });

            //DELETE order
            app.MapDelete("/orders/{id}", (HHPWDbContext db, int id) =>
            {
                var order = db.Orders
                               .Include(o => o.Items)
                               .FirstOrDefault(o => o.OrderId == id);

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                db.OrderItems.RemoveRange(order.Items);
                db.Orders.Remove(order);

                db.SaveChanges();

                return Results.Ok($"Order {id} has been deleted.");
            });

            //DELETE an item from order
            app.MapDelete("/orders/{orderId}/items/{itemId}", (HHPWDbContext db, int orderId, int itemId) =>
            {
                var orderItem = db.OrderItems
                                  .Include(oi => oi.Item)
                                  .FirstOrDefault(oi => oi.OrderId == orderId && oi.ItemId == itemId);

                if (orderItem == null)
                {
                    return Results.NotFound("This item in the order is not found.");
                }
                var itemName = orderItem.Item.Name;
                db.OrderItems.Remove(orderItem);

                db.SaveChanges();

                return Results.Ok($"{itemName} has been removed from order {orderId}.");
            });

            //CREATE an order
            app.MapPost("/orders", (HHPWDbContext db, CreateOrderDTO orderDTO) =>
            {
                var newOrder = new Order
                {
                    CustomerName = orderDTO.CustomerName,
                    CustomerPhone = orderDTO.CustomerPhone,
                    Email = orderDTO.Email,
                    IsPhone = orderDTO.IsPhone,
                    OrderTime = DateTime.UtcNow,
                    IsOpen = true,
                    Tip = orderDTO.Tip,
                    PaymentType = orderDTO.PaymentType,
                    Items = new List<OrderItem>(),
                };

                db.Orders.Add(newOrder);
                db.SaveChanges();

                return Results.Created($"/orders/{newOrder.OrderId}", newOrder);
            });

            //ADD item to order
            app.MapPost("/orders/{orderId}/items/{itemId}", (HHPWDbContext db, int orderId, int itemId) =>
            {
                // check that order exists
                var order = db.Orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                // check that item exists
                var item = db.Items.FirstOrDefault(i => i.ItemId == itemId);
                if (item == null)
                {
                    return Results.NotFound("Item not found.");
                }

                // create a new orderitem & add to order
                var orderItem = new OrderItem
                {
                    OrderId = orderId,
                    ItemId = itemId
                };
                db.OrderItems.Add(orderItem);
                db.SaveChanges();

                var itemName = item.Name;

                return Results.Ok($"{itemName} has been added to order {orderId}.");
            });

            //UPDATE order
            app.MapPut("/orders/{orderId}", (HHPWDbContext db, int orderId, UpdateOrderDTO updateOrderDTO) =>
            {
                var order = db.Orders.FirstOrDefault(o => o.OrderId == orderId);

                if (order == null)
                {
                    return Results.NotFound($"Order with ID {orderId} not found.");
                }

                // update the order details
                order.CustomerName = updateOrderDTO.CustomerName;
                order.CustomerPhone = updateOrderDTO.CustomerPhone;
                order.Email = updateOrderDTO.Email;
                order.IsPhone = updateOrderDTO.IsPhone;
                order.Tip = updateOrderDTO.Tip.HasValue ? updateOrderDTO.Tip.Value : order.Tip;

                db.SaveChanges();

                return Results.Ok($"Order with ID {orderId} updated successfully!");
            });

            //CLOSE order & GET revenue
            app.MapPost("/orders/{orderId}/close", (HHPWDbContext db, int orderId, CreateRevenueDTO createRevenueDTO) =>
            {
                var order = db.Orders.FirstOrDefault(o => o.OrderId == orderId);

                if (order == null)
                {
                    return Results.NotFound($"Order with ID {orderId} not found.");
                }

                if (!order.IsOpen)
                {
                    return Results.BadRequest($"Order with ID {orderId} is already closed.");
                }

                // update the order details 
                order.CloseTime = DateTime.UtcNow;
                order.IsOpen = false;
                order.PaymentType = createRevenueDTO.PaymentType;
                order.Tip = createRevenueDTO.TipAmount;

                // update revenue total w tip
                order.RevTotal += createRevenueDTO.TipAmount;

                db.SaveChanges();

                return Results.Ok($"Order with ID {orderId} closed successfully!");
            });

        }
    }
}
