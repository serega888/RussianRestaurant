using Russian.Web.Models;
using Russian.Web.Models.Dtos;
using Russian.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Russian.Web.Services
{
	public class ProductService : BaseService, IProductService
	{
		private readonly IHttpClientFactory clientFactory;

		public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
		{
			this.clientFactory = clientFactory;
		}

		public async Task<T> CreateProductAsync<T>(ProductDto productDto)
		{
			return await this.SendAsync<T>(new ApiRequestToMicroservice()
			{
				ApiType = StaticVariable.ApiType.POST,
				Data = productDto,
				Url = StaticVariable.PRODUCTAPIBASE + "api/products",
				AccessToken = ""
			});
		}

		public async Task<T> DeleteProductAsync<T>(int id)
		{
			return await this.SendAsync<T>(new ApiRequestToMicroservice()
			{
				ApiType = StaticVariable.ApiType.DELETE,
				Url = StaticVariable.PRODUCTAPIBASE + "api/products/" + id,
				AccessToken = ""
			});
		}

		public async Task<T> GetProductAsync<T>(int id)
		{
			return await this.SendAsync<T>(new ApiRequestToMicroservice()
			{
				ApiType = StaticVariable.ApiType.GET,
				Url = StaticVariable.PRODUCTAPIBASE + "api/products/" + id,
				AccessToken = ""
			});
		}

		public async Task<T> GetProductsAsync<T>()
		{
			return await this.SendAsync<T>(new ApiRequestToMicroservice()
			{
				ApiType = StaticVariable.ApiType.GET,
				Url = StaticVariable.PRODUCTAPIBASE + "api/products",
				AccessToken = ""
			});
		}

		public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
		{
			return await this.SendAsync<T>(new ApiRequestToMicroservice()
			{
				ApiType = StaticVariable.ApiType.PUT,
				Data = productDto,
				Url = StaticVariable.PRODUCTAPIBASE + "api/products",
				AccessToken = ""
			});
		}
	}
}
