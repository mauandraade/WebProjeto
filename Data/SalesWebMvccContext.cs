using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvcc.Models
{
    public class SalesWebMvccContext : DbContext
    {
        public SalesWebMvccContext (DbContextOptions<SalesWebMvccContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMvcc.Models.Department> Department { get; set; }
    }
}
