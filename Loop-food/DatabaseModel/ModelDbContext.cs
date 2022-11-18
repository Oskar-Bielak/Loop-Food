using Loop_food.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loop_food.DatabaseModel
{
    public class ModelDbContext : DbContext
    {
        private string _connectionString =
            "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Loop_food;Integrated Security=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ListAdminModel> ListAdmins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Dodatkowa konfiguracja 
        {
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.name_restaurant)
                .IsRequired()
                .HasMaxLength(25);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Połączenie do bazy danych i jak ma ono wygladać
        {
            optionsBuilder.UseSqlServer(_connectionString);

        }
    }
