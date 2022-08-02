using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Exercise
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string productname, double priceOfProduct, int productID, int CategoryID);

        public void UpdateProductName(string name, int productID);
    }
}
