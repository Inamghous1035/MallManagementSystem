using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.ServerSentEvents;

namespace MallManagementSystem.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        // Ek Sale mein multiple SaleItems ho sakte hain
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}