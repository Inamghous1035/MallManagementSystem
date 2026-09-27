using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MallManagementSystem.Models
{
    public class SaleItem
    {
        [Key]
        public int SaleItemId { get; set; }

        public int SaleId { get; set; }
        [ForeignKey("SaleId")]
        public Sale? Sale { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
    }
}