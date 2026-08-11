using CustomerSales.Data.Entities.Db;
using CustomerSales.Data.Interfaces;
using CustomerSales.Data.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CustomerSales.Data.Persistence.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly CustomerSalesContext _dbContext;

        public SaleRepository(CustomerSalesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            var sales = new List<Sale>();

            using (var connection = new SqlConnection(_dbContext.Database.GetConnectionString()))
            {
                await connection.OpenAsync();

                var query = "SELECT SaleId, CustomerId, ProductId, StoreId, PaymentId, SaleDate, Quantity, TotalAmount FROM Sales";

                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var sale = new Sale
                        {
                            SaleId = reader.GetInt32(0),
                            CustomerId = reader.GetInt32(1),
                            ProductId = reader.GetInt32(2),
                            StoreId = reader.GetInt32(3),
                            PaymentId = reader.GetInt32(4),
                            SaleDate = reader.GetDateTime(5),
                            Quantity = reader.GetInt32(6),
                            TotalAmount = reader.GetDecimal(7)
                        };

                        sales.Add(sale);
                    }
                }
            }

            return sales;
        }
    }
}
