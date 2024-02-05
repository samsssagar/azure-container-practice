using Microsoft.FeatureManagement;
using ProductService.Models;
using System.Data.SqlClient;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection("Server=tcp:dbserver-practice.database.windows.net,1433;Initial Catalog=db-practice;Persist Security Info=False;User ID=sqladmin;Password=admin@2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public List<ProductModel> GetProducts()
        {
            SqlConnection conn = GetConnection();
            var products = new List<ProductModel>();
            string statement = "SELECT * FROM dbo.Products";
            conn.Open();
            SqlCommand sql = new(statement, conn);
            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                ProductModel model = new()
                {
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Quantity = reader.GetInt32(2),
                };
                products.Add(model);
            }
            conn.Close();
            return products;
        }
    }
}
