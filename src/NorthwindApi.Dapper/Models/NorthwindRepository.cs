using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;

namespace NorthwindApi.Dapper.Models
{
    public class NorthwindRepository : INorthwindRepository
    {
        public NorthwindRepository(IOptions<AppSettings> appSettings)
        {
            ConnectionString = appSettings.Value.ConnectionString;
        }

        public string ConnectionString { get; }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = new StringBuilder();

                query.Append("select ");
                query.Append("[ProductID], ");
                query.Append("[ProductName], ");
                query.Append("[SupplierID], ");
                query.Append("[CategoryID], ");
                query.Append("[QuantityPerUnit], ");
                query.Append("[UnitPrice], ");
                query.Append("[UnitsInStock], ");
                query.Append("[UnitsOnOrder], ");
                query.Append("[ReorderLevel], ");
                query.Append("[Discontinued] ");
                query.Append("from ");
                query.Append("[Products] ");

                return await connection.QueryAsync<Product>(query.ToString());
            }
        }

        public async Task<Product> GetProductAsync(Product entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = new StringBuilder();

                query.Append("select ");
                query.Append("[ProductID], ");
                query.Append("[ProductName], ");
                query.Append("[SupplierID], ");
                query.Append("[CategoryID], ");
                query.Append("[QuantityPerUnit], ");
                query.Append("[UnitPrice], ");
                query.Append("[UnitsInStock], ");
                query.Append("[UnitsOnOrder], ");
                query.Append("[ReorderLevel], ");
                query.Append("[Discontinued] ");
                query.Append("from ");
                query.Append("[Products] ");
                query.Append("where ");
                query.Append("[Products].[ProductID] = @productID ");

                return await connection.QueryFirstOrDefaultAsync<Product>(query.ToString(), new { productID = entity.ProductID });
            }
        }
    }
}
