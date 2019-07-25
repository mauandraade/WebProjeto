using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvcc.Models;
using SalesWebMvcc.Services;

namespace SalesWebMvcc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerServices _sellerService;

        public SellersController(SellerServices sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); // vai retornar uma lista de seller
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
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