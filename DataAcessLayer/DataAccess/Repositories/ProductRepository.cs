using DataAcessLayer.Contracts;
using DataAcessLayer.DataAccess.Entities;
using DataAcessLayer.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAcessLayer.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product, SQLDbAppContext>, IProductRepository
    {
        private readonly SQLDbAppContext _context;

        public ProductRepository(SQLDbAppContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ProductsByStatus> GetProductsByStatus(string status = null)
        {
            try
            {
                IEnumerable<Product> products = GetAll();

                IEnumerable<ProductsByStatus> result = products.GroupBy(x => x.Status).Select(x => new ProductsByStatus
                {
                    Status = x.Key,
                    Count = x.Count(),
                });

                if (!string.IsNullOrEmpty(status))
                {
                    var resultByStatus = result.Where(x => x.Status.ToLower() == status.ToLower());

                    return resultByStatus;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public bool UpdateProductStatus(ProductDTO productDto)
        {
            var result = FindBy(x => x.ProductID == productDto.ProductID).SingleOrDefault();

            if (result == null)
            {
                return false;
            }
            else
            {
                var item = new Product
                {
                    ProductID = result.ProductID,
                    BarCode = result.BarCode,
                    Description = result.Description,
                    Weight = result.Weight,
                    Status = productDto.Status,
                    CreatedDate = result.CreatedDate,
                    CreatedBy = result.CreatedBy
                };

                Edit(item);
                return true;
            }
        }

        public bool SellMyProduct(int productId)
        {
            try
            {
                var product = FindBy(x => x.ProductID == productId).SingleOrDefault();

                if (product == null)
                {
                    return false;
                }
                else
                {
                    product.Status = Status.Sold.ToString();
                    Edit(product);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
