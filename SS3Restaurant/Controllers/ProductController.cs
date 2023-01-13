using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS3Restaurant.Models;

namespace SS3Restaurant.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        public ProductController(AppDbContext context,
            IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }
        // GET: Product
        public async Task<ActionResult> Index()
        {
           
            return View(await _context.Product.Include("Category").ToListAsync());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                var prod = new Product
                {
                    CategoryId=product.CategoryId,
                    ProductName=product.ProductName,
                    Qty=product.Qty,
                    Price=product.Price,
                    IsStock=product.IsStock,
                    Image=UploadImage(product),
                    ProductId=product.ProductId
                };
                _context.Product.Add(prod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName",product.CategoryId);
            return View();
        }
        private string UploadImage(ProductDTO product)
        {
            var imagePath = "";
            if(product.Image != null)
            {
                imagePath = Guid.NewGuid().ToString() +"_"+ product.Image.FileName;
                var fullPath = Path.Combine(_webHost.WebRootPath, "Uploads/", imagePath);
                using(var stream=new FileStream(fullPath, FileMode.Create))
                {
                    product.Image.CopyTo(stream);
                }
            }
            return imagePath;
        }
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}