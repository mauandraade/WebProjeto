using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvcc.Models
{
    public class Seller //vendedor
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Birth Date")] // e assim que voce customiza oque vai aparecer no display
        [DataType(DataType.Date)] // traformando o  campo so com data 
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")] // Mudando o formato da data
        public DateTime BirthDate { get; set; }


        [Display(Name ="Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // COLOCANDO DUAS CASA DECIMAIS
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SallesRecord> Sales { get; set; } = new List<SallesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SallesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SallesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount); // calcular o total de vendas em um intervalo de datas
        }


    }
}
