using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Data;
using MVCCRUD.Models;
using MVCCRUD.Models.Data;
using System.Linq;

namespace MVCCRUD.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbcontext appDbcontext;

        public ProductsController(AppDbcontext appDbcontext)
        {
            this.appDbcontext = appDbcontext;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var products= await appDbcontext.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product addProductRequest)
        {

                var product = new Product()
                {
                    Name = addProductRequest.Name,
                    Description = addProductRequest.Description,
                    Color = addProductRequest.Color,
                    Price = addProductRequest.Price,
                    Image = addProductRequest.Image,
                    CategoryId = addProductRequest.CategoryId,

                };

                appDbcontext.Products.Add(product);
                appDbcontext.SaveChanges();
                return RedirectToAction("Index");
                
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var product= appDbcontext.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {

                var viewmodel = new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Color = product.Color,
                    Price = product.Price,
                    Image = product.Image,
                    CategoryId = product.CategoryId,

                };
                return View(viewmodel);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult View(UpdateProduct model)
        {
            var product = appDbcontext.Products.Find(model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;    
                product.Color = model.Color;
                product.Price = model.Price;
                product.Image = model.Image;
                product.CategoryId = model.CategoryId;

                appDbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Delete(UpdateProduct model)
        {
            var product = appDbcontext.Products.Find(model.Id);
            
            if(product != null)
            {
                appDbcontext.Products.Remove(product);
                appDbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

 
        }





    }

}


