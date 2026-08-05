using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSales.Data.Entities.Db
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int PaymentId { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        //nav property
        public Customer? Customer { get; set; }
        public Product? Product { get; set; }
        public Store? Store { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}
