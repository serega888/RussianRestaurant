using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Russian.Web.Models.Dtos;
using Russian.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Russian.Web.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService productService;

		public ProductController(IProductService productService)
		{
			this.productService = productService;
		}

		public async Task<IActionResult> ProductIndex()
		{
			List<ProductDto> listProduct = new List<ProductDto>();
			var response = await this.productService.GetProductsAsync<ResponseDto>();
			if(response != null && response.IsSuccess)
			{
				listProduct = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
			}
			return View(listProduct);
		}

		public async Task<IActionResult> ProductCreate()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ProductCreate(ProductDto model)
		{
			if (ModelState.IsValid)
			{
				var response = await this.productService.CreateProductAsync<ResponseDto>(model);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(ProductIndex));
				}
			}
			return View(model);
		}

		public async Task<IActionResult> ProductEdit(int productId)
		{
			var response = await this.productService.GetProductAsync<ResponseDto>(productId);
			if (response != null && response.IsSuccess)
			{
				ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> ProductEdit(ProductDto model)
		{
			if (ModelState.IsValid)
			{
				var response = await this.productService.UpdateProductAsync<ResponseDto>(model);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(ProductIndex));
				}
			}
			return View(model);
		}

		public async Task<IActionResult> ProductDelete(int productId)
		{
			var response = await this.productService.GetProductAsync<ResponseDto>(productId);
			if (response != null && response.IsSuccess)
			{
				ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> ProductDelete(ProductDto model)
		{
			if (ModelState.IsValid)
			{
				var response = await this.productService.DeleteProductAsync<ResponseDto>(model.ProductId);
				if (response.IsSuccess)
				{
					return RedirectToAction(nameof(ProductIndex));
				}
			}
			return View(model);
		}
	}
}
