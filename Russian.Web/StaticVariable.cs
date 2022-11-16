using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Russian.Web
{
	public static class StaticVariable
	{
		public static string PRODUCTAPIBASE { get; set; }
		public enum ApiType
		{
			GET,
			POST,
			PUT,
			DELETE
		}
	}
}
