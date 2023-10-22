using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterLogin.Data;
using RegisterLogin.Models;
using System.Threading.Tasks;

namespace RegisterLogin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var allProducts = await _context.Products.ToListAsync();
            return View(allProducts);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,ImageURL,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                var newMovie = new Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageURL = product.ImageURL,
                };

                _context.Products.Add(newMovie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }



        //GET: Products/Details/1
        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _context.Products.FirstOrDefaultAsync(n => n.Id == id);

            if (productDetails == null)
            {
                return NotFound(); 
            }

            return View(productDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _context.Products.FirstOrDefaultAsync(n => n.Id == id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }

        [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageURL,Description,Price")] Product product)
        {
            
            if (ModelState.IsValid)
            {
                
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        //Get: Products/Delete/1  
        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _context.Products.FirstOrDefaultAsync(n => n.Id == id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _context.Products.FirstOrDefaultAsync(n => n.Id == id);
            if (productDetails == null) return View("NotFound");

            _context.Products.Remove(productDetails); 
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}