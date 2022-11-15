using Microsoft.EntityFrameworkCore;
using Russian.Services.ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Russian.Services.ProductAPI.DbContexts
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }

	}
}
