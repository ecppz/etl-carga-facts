using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSales.Data.Entities.Db
{
    public class PaymentMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentId { get; set; } 
        public string MethodName { get; set; } = string.Empty;
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
