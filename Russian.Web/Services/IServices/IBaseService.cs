using Russian.Web.Models;
using Russian.Web.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Russian.Web.Services.IServices
{
	public interface IBaseService: IDisposable
	{
		ResponseDto responseModel { get; set; }
		Task<T> SendAsync<T>(ApiRequestToMicroservice apiRequestToMicroservice);
	}
}
