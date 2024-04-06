using Microsoft.EntityFrameworkCore;

namespace HHPW.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirebaseKey { get; set; }
        public string Name {  get; set; }
    }
}
