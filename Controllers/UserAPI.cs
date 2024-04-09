using HHPW.Models;
using Microsoft.EntityFrameworkCore;
namespace HHPW_BE.Controllers
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            //get users by uid
            app.MapGet("/checkuser/{uid}", (HHPWDbContext db, string uid) =>
            {
                var user =  db.Users.FirstOrDefault(u => u.Uid == uid);

                if (user == null)
                {
                    return Results.NotFound("User not found.");
                }

                return Results.Ok(new { user.UserId, user.Name, user.Uid });
            });
        }
    }
}
