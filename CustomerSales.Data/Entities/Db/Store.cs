using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSales.Data.Entities.Db
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StoreId { get; set; } 
        public string StoreName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
