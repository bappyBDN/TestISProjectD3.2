using HomeChefHub.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeChefHub.Data
{
    public class MyDatabaseContext : DbContext 
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options) {

        }

        public DbSet<Admin> Admins { get; set; }  // Register Admin Model
        public DbSet<User> Users { get; set; } //Register User Model
        public DbSet<Chef> Chefs { get; set; }  //Register Chef Model


    }
}
