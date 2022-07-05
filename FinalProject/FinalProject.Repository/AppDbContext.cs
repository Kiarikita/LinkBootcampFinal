using FinalProject.Core.Commercial;
using FinalProject.Core.Customers;
using FinalProject.Core.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CommercialActivity> CommercialActivities { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
