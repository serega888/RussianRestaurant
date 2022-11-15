using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Russian.Services.ProductAPI.DbContexts;
using Russian.Services.ProductAPI.Models;
using Russian.Services.ProductAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Russian.Services.ProductAPI.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext dbContext;
		private IMapper mapper;

		public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		public async Task<ProductDto> CreateOrUpdateProduct(ProductDto productDto)
		{
			Product product = mapper.Map<ProductDto, Product>(productDto);
			//if (product == null)
			//{
			//	return null;
			//}

			if(product.ProductId > 0)
			{
				this.dbContext.Products.Update(product);
			}
			else
			{
				this.dbContext.Products.Add(product);
			}

			await this.dbContext.SaveChangesAsync();
			return this.mapper.Map<Product, ProductDto>(product);
		}

		public async Task<bool> DeleteProduct(int productId)
		{
			try
			{
				Product product = await this.dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
				if (product == null)
				{
					return false;
				}

				this.dbContext.Products.Remove(product);
				await this.dbContext.SaveChangesAsync();
				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}

		public async Task<ProductDto> GetProduct(int productId)
		{
			Product product = await this.dbContext.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
			return this.mapper.Map<ProductDto>(product);
		}

		public async Task<IEnumerable<ProductDto>> GetProducts()
		{
			List<Product> products = await this.dbContext.Products.ToListAsync();
			return this.mapper.Map<List<ProductDto>>(products);
		}
	}
}
