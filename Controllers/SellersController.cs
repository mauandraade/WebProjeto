using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvcc.Models;
using SalesWebMvcc.Services;
using SalesWebMvcc.Models.ViewModels;

namespace SalesWebMvcc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerServices _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerServices sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); // vai retornar uma lista de seller
            return View(list);
        }
        public IActionResult Create()
        {

            var departments = _departmentService.FindAll(); //puxando todos departamentos
            var viewModel = new SellerFormViewModel { Departments = departments }; // iniciando com a lista que acabamos de buscar
            return View(viewModel); // passando o objeto view model pra view
            
        }

        [HttpPost] // falando que o metodo post  e nao get
        [ValidateAntiForgeryToken]//previnindo ataque com sessao ativa e mandam coisa virus


        public IActionResult Create(Seller seller)
        {

            _sellerService.Insert(seller); // inserindo um vendendor

            return RedirectToAction(nameof(Index)); 
        }
    }
}