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

        }
    }
}
