using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JacHomePage.Models;
using Microsoft.EntityFrameworkCore;

namespace JacHomePage.Persistence
{
    public class JackDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Offer> Offers { get; set; }

        public JackDbContext(DbContextOptions<JackDbContext> options) : base(options)
        {
            
        }
    }
}
