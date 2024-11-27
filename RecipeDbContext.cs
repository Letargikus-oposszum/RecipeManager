using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace RecipeManager
{
    public class RecipeDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingridient> Ingridients { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        public string DbPath { get; }

        public RecipeDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=RecipeManager;Integrated Security=true");
    }
}
