using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvcc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvcc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvccContext _context;

        public DepartmentService(SalesWebMvccContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()//assincronas estudar
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync(); // Metood ordeyBy pra trazer por ordens os nomes
        }

        


    }
}
