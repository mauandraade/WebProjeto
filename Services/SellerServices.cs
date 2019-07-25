﻿using SalesWebMvcc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public void Insert(Seller a)
        {
           // obj.Department = _context.Department.First(); // ta pegando o primeiro departamento pra nao dar erro (porem nao precisa mais)
            _context.Add(a);
            _context.SaveChanges();
        }

        public Seller FindById(int id) // retornando o vendedor
        {
            return _context.Seller.Include(a => a.Department).FirstOrDefault(a => a.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id); // puxando na lista o vendedor
            _context.Seller.Remove(obj); // removendo o vendendor
            _context.SaveChanges(); // confirmando a remoção
;        }
    }
}
