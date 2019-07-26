using SalesWebMvcc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvcc.Services.Exceptions;

namespace SalesWebMvcc.Services
{
    public class SellerServices
    {
        private readonly SalesWebMvccContext _context;

        public SellerServices (SalesWebMvccContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync(); // ele vai rodar o acesso ao banco de dados e retornar uma lista
        }
        public async Task InsertAsync(Seller obj)
        {
           // obj.Department = _context.Department.First(); // ta pegando o primeiro departamento pra nao dar erro (porem nao precisa mais)

            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id) // retornando o vendedor
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await  _context.Seller.FindAsync(id); // puxando na lista o vendedor
            _context.Seller.Remove(obj); // removendo o vendendor
            await _context.SaveChangesAsync(); // confirmando a remoção
;        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await  _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)// verifica se ja existe --> o Any() serve para vericar se existe no bd a condicao que voce pos
            {
                throw new NotFoundException("Id not found");
            }

            try { 
            _context.Update(obj);
           await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
