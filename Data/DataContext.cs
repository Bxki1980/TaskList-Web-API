using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using Todolist.Models;

namespace Todolist.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TaskModels> Todolist { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:sqldatabase-test1.database.windows.net,1433;Initial Catalog=ToDoListDB;Persist Security Info=False;User ID=sqladmin;Password=MeowMeow123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", Option => 
            {
                Option.EnableRetryOnFailure();
            });
        }
    }
}
