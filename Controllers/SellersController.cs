using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}