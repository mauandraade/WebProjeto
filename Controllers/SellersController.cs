using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvcc.Models;
using SalesWebMvcc.Services;
using SalesWebMvcc.Models.ViewModels;
using SalesWebMvcc.Services.Exceptions;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync(); // vai retornar uma lista de seller
            return View(list);
        }
        public async Task<IActionResult> Create()
        {

            var departments = await _departmentService.FindAllAsync(); //puxando todos departamentos
            var viewModel = new SellerFormViewModel { Departments = departments }; // iniciando com a lista que acabamos de buscar
            return View(viewModel); // passando o objeto view model pra view
            
        }

        [HttpPost] // falando que o metodo post  e nao get
        [ValidateAntiForgeryToken]//previnindo ataque com sessao ativa e mandam coisa virus


        public async Task<IActionResult> Create(Seller seller)
        {
            //validação
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }

            await _sellerService.InsertAsync(seller); // inserindo um vendendor

            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> Delete(int? id) // int? ---> significa que é opcional receber o id
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value); // pegando o valor do id
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) {

            try { 
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message }); // redirecionando para  a pagina de erro 
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await  _sellerService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            
            return View(obj);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if(id == null)
            { 
                return RedirectToAction(nameof(Error), new { message = "Id not provided" }); ;
            }

            var obj =  await _sellerService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            //teste de validação , se n for valido vai retornar a mesma view
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" }); ;
            }
            try { 
            await _sellerService.UpdateAsync(seller);
            return RedirectToAction(nameof(Index));

            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
           
        }


        //ACAO DE ERRO
        public  IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier // Current?.Id ?? -----> Id opcional, ?? significa que se for nulo chamar a funcao HttpContext.TraceIdentifier // macete pra pegar o id interno da requisicao
            };

            return View(viewModel);
        }
        
    }
}