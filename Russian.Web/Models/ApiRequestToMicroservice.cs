using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Russian.Web.StaticVariable;

namespace Russian.Web.Models
{
	public class ApiRequestToMicroservice
	{
		public ApiType ApiType { get; set; } = ApiType.GET;
		public string Url { get; set; }
		public object Data { get; set; }
		public string AccessToken { get; set; }
	}
}
