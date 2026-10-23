using JwtProject.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JwtProject.API.Context
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser,AppRole,int>(options)
    {
        public DbSet<Category> Categories { get; set; }
    }
}
