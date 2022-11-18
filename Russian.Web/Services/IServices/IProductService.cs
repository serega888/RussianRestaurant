using Russian.Web.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Russian.Web.Services.IServices
{
	public interface IProductService: IBaseService
	{
		Task<T> GetProductsAsync<T>();
		Task<T> GetProductAsync<T>(int id);
		Task<T> CreateProductAsync<T>(ProductDto productDto);
		Task<T> UpdateProductAsync<T>(ProductDto productDto);
		Task<T> DeleteProductAsync<T>(int id);
	}
}
