using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;
using MVC_Project.ViewModel;

namespace MVC_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var productsViewModel = context.Products.Include(p => p.Category).AsNoTracking()
                .Select(p => new ProductsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Rate = p.Rate,
                    CategoryName = p.Category.Name
                })
                .ToList();
            return View(productsViewModel);
            //var productsViewModel = new List<ProductsViewModel>();
            //foreach (var product in products)
            //{
            //    productsViewModel.Add(new ProductsViewModel
            //    {
            //        Id = product.Id,
            //        Name = product.Name,
            //        Price = product.Price,
            //        Rate = product.Rate,
            //        Quantity = product.Quantity,
            //        CategoryName = product.Category.Name
            //    });
            //}
           
        }

        public IActionResult Create()
        {
            ViewBag.Categories = context.Categories.AsNoTracking().ToList();
            return View();
        }

        public IActionResult Store(CreateProductViewModel request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Rate = request.Rate,
                Quantity = request.Quantity,
                CategoryId = request.CategoryId
            };

            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
            ViewBag.Categories = context.Categories.AsNoTracking().ToList();
            return View(product);
        }

        public IActionResult Update(Product request, int id)
        {
            request.Id = id;
            context.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            //return Content($"{id}");
            var product = context.Products.Find(id);
            context.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
