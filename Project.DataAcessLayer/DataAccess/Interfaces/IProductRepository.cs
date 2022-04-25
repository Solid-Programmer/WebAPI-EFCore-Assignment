using Project.DataAcessLayer.Contracts;
using Project.DataAcessLayer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.DataAcessLayer.DataAccess.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<ProductsByStatus> GetProductsByStatus(string status = null);
        bool SellMyProduct(int productId);
        bool UpdateProductStatus(ProductDTO product);
    }
}
