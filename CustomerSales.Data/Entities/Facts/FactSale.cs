using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSales.Data.Entities.Dwh
{
    public class FactSale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int PaymentId { get; set; }

        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DimCustomer? Customer { get; set; }
        public DimProduct? Product { get; set; }
        public DimStore? Store { get; set; }
        public DimPaymentMethod? PaymentMethod { get; set; }
    }
}
