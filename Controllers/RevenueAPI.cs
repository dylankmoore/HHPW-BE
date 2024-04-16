using HHPW.Models;
using HHPW_BE.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HHPW_BE.Controllers
{
    public class RevenueAPI
    {
        public static void Map(WebApplication app)
        {
            //GET revenue total
            app.MapGet("/revenue/total", (HHPWDbContext db) =>
            {
                //calculate total rev from all orders
                var totalRevenue = db.Orders

                    .Sum(o => o.RevTotal + o.Tip); // total of all rev & tips

                return Results.Ok(new { TotalRevenue = totalRevenue });
            });

            //GET revenue details
            app.MapGet("/revenue", async (HHPWDbContext db) =>
            {
                var totalSales = await db.Orders.SumAsync(o => o.RevTotal);
                var totalTips = await db.Orders.SumAsync(o => o.Tip);
                var phoneOrdersCount = await db.Orders.CountAsync(o => o.IsPhone);
                var inPersonOrdersCount = await db.Orders.CountAsync(o => !o.IsPhone);
                var cashPaymentsCount = await db.Orders.CountAsync(o => o.PaymentType == "Cash");
                var mobilePaymentsCount = await db.Orders.CountAsync(o => o.PaymentType == "Mobile");
                var debitPaymentsCount = await db.Orders.CountAsync(o => o.PaymentType == "Debit");
                var creditPaymentsCount = await db.Orders.CountAsync(o => o.PaymentType == "Credit");

                var revenueDetails = new
                {
                    TotalSales = totalSales,
                    TotalTips = totalTips,
                    PhoneOrdersCount = phoneOrdersCount,
                    InPersonOrdersCount = inPersonOrdersCount,
                    CashPaymentsCount = cashPaymentsCount,
                    MobilePaymentsCount = mobilePaymentsCount,
                    DebitPaymentsCount = debitPaymentsCount,
                    CreditPaymentsCount = creditPaymentsCount
                };

                return Results.Ok(revenueDetails);
            });

        }

    }
}
