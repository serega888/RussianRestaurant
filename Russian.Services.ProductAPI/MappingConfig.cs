using AutoMapper;
using Russian.Services.ProductAPI.Models;
using Russian.Services.ProductAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Russian.Services.ProductAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mapperConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<Product, ProductDto>().ReverseMap();
			});

			return mapperConfig;
		}
	}
}
