using SalesWebMvcc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvcc.Services
{
    public class SellerServices
    {
        private readonly SalesWebMvccContext _context;

        public SellerServices (SalesWebMvccContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList(); // ele vai rodar o acesso ao banco de dados e retornar uma lista
        }
        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First(); // ta pegando o primeiro departamento pra nao dar erro
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
