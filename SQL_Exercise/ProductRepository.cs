using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Exercise
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS");
        }

        public void CreateProduct(string productName, double priceOfProduct, int productID, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, ProductID, categoryID) VALUES (@name, @price, @productid, @categoryid);",
                new {name = productName, price = priceOfProduct, productid = productID, categoryid = categoryID});
        }

        public void UpdateProductName(string name, int productID)
        {
            // UPDATE PRODUCTS SET name = @newName WHERE productID = @productID

            _connection.Execute("UPDATE PRODUCTS SET name = @newName WHERE productID = @productid;",
               new { newName = name, productid = productID}); 
        }
    }
}
