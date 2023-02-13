using contact.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace contact.Data
{
    
        public class ContactDbContext : DbContext
        {
            public ContactDbContext(DbContextOptions options) : base(options)
            { }

            public DbSet<Contact> Contacts { get; set; }
        
    }
    }

