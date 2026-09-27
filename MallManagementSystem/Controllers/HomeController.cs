using MallManagementSystem.Data;
using MallManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MallManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard view after login
        public async Task<IActionResult> Index()
        {
            var today = DateTime.Today;

            // Total products in stock
            var totalProductsInStock = await _context.Products
                .SumAsync(p => p.Quantity);

            // Total sales made today
            var totalSalesToday = await _context.Sales
                .Where(s => s.SaleDate.Date == today)
                .CountAsync();

            // Total revenue today
            var totalRevenueToday = await _context.Sales
                .Where(s => s.SaleDate.Date == today)
                .SumAsync(s => s.TotalAmount);

            // Products with low stock (quantity < 10)
            var lowStockProducts = await _context.Products
                .Where(p => p.Quantity < 10)
                .OrderBy(p => p.Quantity)
                .ToListAsync();

            var viewModel = new DashboardViewModel
            {
                TotalProductsInStock = totalProductsInStock,
                TotalSalesToday = totalSalesToday,
                TotalRevenueToday = totalRevenueToday,
                LowStockProducts = lowStockProducts
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
