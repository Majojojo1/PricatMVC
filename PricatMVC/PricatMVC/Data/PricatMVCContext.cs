using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PricatMVC.Models;

namespace PricatMVC.Data
{
    public class PricatMVCContext : DbContext
    {
        public PricatMVCContext (DbContextOptions<PricatMVCContext> options)
            : base(options)
        {
        }

        public DbSet<PricatMVC.Models.Category> Category { get; set; } = default!;
    }
}
