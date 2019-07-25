using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvcc.Models;

namespace SalesWebMvcc.Models
{
    public class SalesWebMvccContext : DbContext
    {
        public SalesWebMvccContext (DbContextOptions<SalesWebMvccContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SallesRecord> SalesRecord { get; set; }
    }
}
