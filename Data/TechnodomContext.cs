using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Technodom.Models;

namespace Technodom.Data
{
    public class TechnodomContext : DbContext
    {
        public TechnodomContext (DbContextOptions<TechnodomContext> options)
            : base(options)
        {
        }

        public DbSet<Technodom.Models.Phones>? Phones { get; set; }

        public DbSet<Technodom.Models.Laptops>? Laptops { get; set; }

        public DbSet<Technodom.Models.Televisors>? Televisors { get; set; }
    }
}
