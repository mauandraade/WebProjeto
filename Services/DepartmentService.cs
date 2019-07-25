using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvcc.Models;

namespace SalesWebMvcc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvccContext _context;

        public DepartmentService(SalesWebMvccContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList(); // Metood ordeyBy pra trazer por ordens os nomes
        }
    }
}
