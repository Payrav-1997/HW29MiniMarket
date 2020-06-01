using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW27_MiniMarket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HW27_MiniMarket.Controllers
{
    public class ClientProductController : Controller
    {
        public DataContext _context;
        public ClientProductController(DataContext context)
        {
            this._context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToList();
            var li = _context.Products.OrderByDescending(p => p).Include(p => p.ProductCategory).ToList();
            return View(li);
        }

        public async Task<IActionResult> AddCart(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);



            _context.Carts.Add(new Cart { ProductId = product.Id });
            await _context.SaveChangesAsync();

            return RedirectToAction("CartList");
        }

        public async Task<IActionResult> CartList()
        {
            var cartList = await _context.Carts.ToListAsync();
            foreach (var cartProduct in cartList)
            {
                cartProduct.Products = await _context.Products.Where(p=>p.Id == cartProduct.ProductId).ToListAsync();
            }
            return View(cartList);
        }

        


    }
}
