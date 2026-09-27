namespace MallManagementSystem.Models
{
    public class DashboardViewModel
    {
        public int TotalProductsInStock { get; set; }
        public int TotalSalesToday { get; set; }
        public decimal TotalRevenueToday { get; set; }
        public List<Product> LowStockProducts { get; set; } = new List<Product>();
    }
}
