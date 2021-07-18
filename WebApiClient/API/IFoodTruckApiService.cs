using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiClient.API
{
	public interface IFoodTruckApiService
	{
		Task<HttpResponseMessage> PerformGetRequest(string route = null, IEnumerable<KeyValuePair<string, string>> headers = null, IEnumerable<KeyValuePair<string, string>> filters = null);
	}
}
