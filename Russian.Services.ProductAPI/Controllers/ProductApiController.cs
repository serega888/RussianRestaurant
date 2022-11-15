using Microsoft.AspNetCore.Mvc;
using Russian.Services.ProductAPI.Models.Dtos;
using Russian.Services.ProductAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Russian.Services.ProductAPI.Controllers
{
	[Route("api/products")]
	public class ProductApiController : ControllerBase
	{
		protected ResponseDto response;
		private IProductRepository productRepository;

		public ProductApiController(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
			this.response = new ResponseDto();
		}

		[HttpGet]
		public async Task<object> Get()
		{
			try
			{
				IEnumerable<ProductDto> productDtos = await this.productRepository.GetProducts();
				this.response.Result = productDtos;
			}
			catch(Exception e)
			{
				this.response.IsSuccess = false;
				this.response.ErrorMessages = new List<String>() { e.ToString() };
			}

			return this.response;
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<object> Get(int id)
		{
			try
			{
				ProductDto productDto = await this.productRepository.GetProduct(id);
				this.response.Result = productDto;
			}
			catch (Exception e)
			{
				this.response.IsSuccess = false;
				this.response.ErrorMessages = new List<String>() { e.ToString() };
			}

			return this.response;
		}

		[HttpPost]
		public async Task<object> Post([FromBody] ProductDto productDto)
		{
			try
			{
				ProductDto model = await this.productRepository.CreateOrUpdateProduct(productDto);
				this.response.Result = model;
			}
			catch (Exception e)
			{
				this.response.IsSuccess = false;
				this.response.ErrorMessages = new List<String>() { e.ToString() };
			}

			return this.response;
		}

		[HttpPut]
		public async Task<object> Put([FromBody] ProductDto productDto)
		{
			try
			{
				ProductDto model = await this.productRepository.CreateOrUpdateProduct(productDto);
				this.response.Result = model;
			}
			catch (Exception e)
			{
				this.response.IsSuccess = false;
				this.response.ErrorMessages = new List<String>() { e.ToString() };
			}

			return this.response;
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<object> Delete(int id)
		{
			try
			{
				bool isSuccess = await this.productRepository.DeleteProduct(id);
				this.response.Result = isSuccess;
			}
			catch (Exception e)
			{
				this.response.IsSuccess = false;
				this.response.ErrorMessages = new List<String>() { e.ToString() };
			}

			return this.response;
		}
	}
}
