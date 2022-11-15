using Russian.Services.ProductAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Russian.Services.ProductAPI.Repository
{
	interface IProductRepository
	{
		Task<IEnumerable<ProductDto>> GetProducts();
		Task<ProductDto> GetProduct(int productId);
		Task<ProductDto> CreateOrUpdateProduct(ProductDto productDto);
		Task<bool> DeleteProduct(int productId);
	}
}
