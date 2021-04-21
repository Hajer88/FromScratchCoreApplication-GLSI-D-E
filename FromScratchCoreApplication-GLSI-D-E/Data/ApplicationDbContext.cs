using System;
using System.Collections.Generic;
using System.Text;
using FromScratchCoreApplication_GLSI_D_E.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FromScratchCoreApplication_GLSI_D_E.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> categories { get; set; }
    }
}
