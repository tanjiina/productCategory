using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using productCateg.Models;
using Microsoft.EntityFrameworkCore;

namespace productCateg.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
     
        public HomeController(MyContext context){
            dbContext = context;
        }




        [HttpGet("")]
        public IActionResult Index(){
            List<Product> AllProducts = dbContext.Products.ToList();
            ViewBag.All = AllProducts;
            return View();
        }

        [HttpPost("/newproduct")]
        public IActionResult NewProduct(Product product){
           if(ModelState.IsValid){
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            return Redirect("/");
           }
            List<Product> AllProducts = dbContext.Products.ToList();
            ViewBag.All = AllProducts;
            return View("Index");
        }



        [HttpGet("Categories")]
        public IActionResult Categories(){
            List<Category> AllCategories = dbContext.Categories.ToList();
            ViewBag.All = AllCategories;
            return View();
        }
        [HttpPost("/newcategory")]
        public IActionResult NewCategory(Category category){
           if(ModelState.IsValid){
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
            return Redirect("Categories");
           }
            List<Product> AllProducts = dbContext.Products.ToList();
            ViewBag.All = AllProducts;
            return View("Categories");
        }



        
        [HttpGet("Category/{CategoryId}")]
        public IActionResult Category(int categoryid){
            List<Product> AllProducts = dbContext.Products.ToList();
            ViewBag.All = AllProducts;

            Category retrievedCategory = dbContext.Categories
            .Include(d => d.AllProducts)
            .ThenInclude(d => d.Product)
            .SingleOrDefault(d => d.CategoryId == categoryid);
            ViewBag.retrieved = retrievedCategory;

            List<Product> unrelatedProducts = dbContext.Products
                .Include(c => c.AllCategories)
                .Where(c => c.AllCategories.All(a => a.CategoryId != categoryid)).ToList();
            ViewBag.unrelated = unrelatedProducts; 

            return View();
        }




        [HttpGet("Product/{ProductId}")]
        public IActionResult Product(int productid){
            List<Category> AllCategories = dbContext.Categories.ToList();
            ViewBag.All = AllCategories;

            Product retrievedProduct = dbContext.Products
            .Include(d => d.AllCategories)
            .ThenInclude(d => d.Category)
            .SingleOrDefault(d => d.ProductId == productid);
            ViewBag.retrieved = retrievedProduct;

            List<Category> unrelatedCategories = dbContext.Categories
                .Include(c => c.AllProducts)
                .Where(c => c.AllProducts.All(a => a.ProductId != productid))
                .ToList();
            ViewBag.unrelated = unrelatedCategories;  
            return View();
        }



        [HttpPost("/productAssociation")]
        public IActionResult AssociateProduct(Association newAssociation){
            dbContext.Associations.Add(newAssociation);
            dbContext.SaveChanges();
            return Redirect($"/Product/{newAssociation.ProductId}");
        }




        [HttpPost("/categoryAssociation")]
        public IActionResult AssociateCategory(Association newAssociation){
            dbContext.Associations.Add(newAssociation);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
