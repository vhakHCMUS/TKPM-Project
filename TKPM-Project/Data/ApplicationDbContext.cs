using Microsoft.EntityFrameworkCore;
using TKPM_Project.Models;

namespace TKPM_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // Ví dụ bảng User
    }
}
