using Newtonsoft.Json;
using Russian.Web.Models;
using Russian.Web.Models.Dtos;
using Russian.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Russian.Web.Services
{
	public class BaseService : IBaseService
	{
		public ResponseDto responseModel { get; set; }
		public IHttpClientFactory httpClientFactory { get; set; }
		public string ApplicationJson = "application/json";

		public BaseService(IHttpClientFactory httpClientFactory)
		{
			this.responseModel = new ResponseDto();
			this.httpClientFactory = httpClientFactory;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}

		public async Task<T> SendAsync<T>(ApiRequestToMicroservice apiRequestToMicroservice)
		{
			try
			{
				var client = httpClientFactory.CreateClient("RussianAPI");
				HttpRequestMessage message = new HttpRequestMessage();
				message.Headers.Add("Accept", ApplicationJson);
				message.RequestUri = new Uri(apiRequestToMicroservice.Url);
				client.DefaultRequestHeaders.Clear();
				if(apiRequestToMicroservice.Data != null)
				{
					message.Content = new StringContent(
						JsonConvert.SerializeObject(apiRequestToMicroservice.Data),
						Encoding.UTF8, ApplicationJson);
				}

				HttpResponseMessage apiResponseMessage = null;
				switch (apiRequestToMicroservice.ApiType)
				{
					case StaticVariable.ApiType.POST:
						message.Method = HttpMethod.Post;
						break;
					case StaticVariable.ApiType.PUT:
						message.Method = HttpMethod.Put;
						break;
					case StaticVariable.ApiType.DELETE:
						message.Method = HttpMethod.Delete;
						break;
					default:
						message.Method = HttpMethod.Get;
						break;
				}
				apiResponseMessage = await client.SendAsync(message);
				var apiContent = await apiResponseMessage.Content.ReadAsStringAsync();
				var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
				return apiResponseDto;
			}
			catch(Exception e)
			{
				var dto = new ResponseDto
				{
					DisplayMessage = "Error",
					ErrorMessages = new List<string> { Convert.ToString(e.Message) },
					IsSuccess = false
				};

			    var res = JsonConvert.SerializeObject(dto);
				var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
				return apiResponseDto;
			}
		}
	}
}
