using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DataAcessLayer.Contracts;
using Project.DataAcessLayer.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _IProductRepository;
        public ProductsController(IProductRepository IProductRepository)
        {
            _IProductRepository = IProductRepository;
        }

        [Route("api/[controller]/GetProductsByStatus")]
        [HttpGet]
        public IActionResult GetProductsByStatus(string? status = null)
        {
            try
            {
                IEnumerable<ProductsByStatus> productsByStatus = _IProductRepository.GetProductsByStatus(status);

                if (!productsByStatus.Any())
                {
                    return NotFound("No Products found");
                }

                return Ok(productsByStatus);

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [Route("api/[controller]/ChangeProductStatus")]
        [HttpPost]
        public IActionResult ChangeProductStatus([FromBody] ProductDTO product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Please check the parameters");
                }

                bool result = _IProductRepository.UpdateProductStatus(product);

                if (result)
                    return Ok("Product has been updated");
                
                else
                    return BadRequest("Product doesn't exist. Please check Product details");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [Route("api/[controller]/SellProduct/{id}")]
        [HttpPut]
        public IActionResult SellProduct(int id)
        {
            try
            {
                bool result = _IProductRepository.SellMyProduct(id);

                if (result)
                    return Ok("Product has been sold");
                else
                    return BadRequest("Product doesn't exist. Please check Product Id");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
