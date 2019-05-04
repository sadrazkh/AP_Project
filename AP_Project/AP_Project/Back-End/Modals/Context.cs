using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AP_Project.Back_End.Modals
{
    public class Context : DbContext
    {
        public DbSet<Persons.Person> Persons { get; set; }
        public DbSet<Products.Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=E:\GitHub\AP_Project\AP_Project\AP_Project\AP_Project_DB;Trusted_Connection=True;");
        }
    }
}
