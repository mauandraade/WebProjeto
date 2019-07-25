using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvcc.Models;
using SalesWebMvcc.Models.Enums;
using System.Globalization;
namespace SalesWebMvcc.Data
{
    public class SeendingService
    {
        private SalesWebMvccContext _context;

        public SeendingService(SalesWebMvccContext context) 
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return;//DB HAS BEEN SEEDED
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Gray", "alex@gmail.com", new DateTime(1988, 1, 15), 3000.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 2200.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9),4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SallesRecord r1 = new SallesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SallesRecord r2 = new SallesRecord(2, new DateTime(2018, 10, 10), 10000.0, SaleStatus.Pending, s3);
            SallesRecord r3 = new SallesRecord(3, new DateTime(2018, 10, 11), 40000.0, SaleStatus.Pending, s4);
            SallesRecord r4 = new SallesRecord(4, new DateTime(2018, 10, 12), 70000.0, SaleStatus.Pending, s2);
            SallesRecord r5 = new SallesRecord(5, new DateTime(2018, 10, 13), 20000.0, SaleStatus.Billed, s6);
            SallesRecord r6 = new SallesRecord(6, new DateTime(2018, 10, 14), 90000.0, SaleStatus.Billed, s5);
            SallesRecord r7 = new SallesRecord(7, new DateTime(2018, 10, 15), 30000.0, SaleStatus.Canceled, s1);
            SallesRecord r8 = new SallesRecord(8, new DateTime(2018, 10, 16), 50000.0, SaleStatus.Canceled, s2);
            SallesRecord r9 = new SallesRecord(9, new DateTime(2018, 10, 17), 12000.0, SaleStatus.Pending, s3);
            SallesRecord r10 = new SallesRecord(10, new DateTime(2018, 10, 18), 13000.0, SaleStatus.Billed, s4);
            SallesRecord r11 = new SallesRecord(11, new DateTime(2018, 10, 19), 14000.0, SaleStatus.Billed, s5);
            SallesRecord r12 = new SallesRecord(12, new DateTime(2018, 10, 20), 15000.0, SaleStatus.Canceled, s6);
            SallesRecord r13 = new SallesRecord(13, new DateTime(2018, 10, 21), 16000.0, SaleStatus.Canceled, s2);
            SallesRecord r14 = new SallesRecord(14, new DateTime(2018, 10, 22), 17000.0, SaleStatus.Pending, s6);
            SallesRecord r15 = new SallesRecord(15, new DateTime(2018, 10, 23), 18000.0, SaleStatus.Billed, s3);
            SallesRecord r16 = new SallesRecord(16, new DateTime(2018, 10, 24), 19000.0, SaleStatus.Billed, s4);
            SallesRecord r17 = new SallesRecord(17, new DateTime(2018, 10, 25), 20000.0, SaleStatus.Pending, s1);
            SallesRecord r18 = new SallesRecord(18, new DateTime(2018, 10, 26), 21000.0, SaleStatus.Canceled, s1);
            SallesRecord r19 = new SallesRecord(19, new DateTime(2018, 10, 27), 22000.0, SaleStatus.Billed, s2);
            SallesRecord r20 = new SallesRecord(20, new DateTime(2018, 10, 28), 23000.0, SaleStatus.Canceled, s3);
            SallesRecord r21 = new SallesRecord(21, new DateTime(2018, 10, 29), 24000.0, SaleStatus.Pending, s4);
            SallesRecord r22 = new SallesRecord(22, new DateTime(2018, 10, 30), 25000.0, SaleStatus.Pending, s5);
            SallesRecord r23 = new SallesRecord(23, new DateTime(2018, 10, 31), 26000.0, SaleStatus.Billed, s6);


            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23); // add range serve para mandar um grupo de argumentos
            _context.SaveChanges(); // save changes pra salvar no banco de dados
        }
    }
}
