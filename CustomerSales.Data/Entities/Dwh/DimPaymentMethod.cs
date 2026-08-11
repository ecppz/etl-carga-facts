using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSales.Data.Entities.Dwh
{
    public class DimPaymentMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentId { get; set; }
        public string MethodName { get; set; } = string.Empty;
    }
}
