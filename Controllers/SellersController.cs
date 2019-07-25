using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvcc.Models;
using SalesWebMvcc.Services;
using SalesWebMvcc.Models.ViewModels;
using SalesWebMvcc.Services.Exceptions;

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
        public IActionResult Delete(int? id) // int? ---> significa que é opcional receber o id
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value); // pegando o valor do id
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {

            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if(id != seller.Id)
            {
                return BadRequest();
            }
            try { 
            _sellerService.Update(seller);
            return RedirectToAction(nameof(Index));

            }
            catch (NotFoundExcepetion)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
        
    }
}