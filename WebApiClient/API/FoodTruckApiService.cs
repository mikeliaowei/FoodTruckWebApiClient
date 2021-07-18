using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.API
{
	public class FoodTruckApiService : IFoodTruckApiService
	{

		private static readonly string FOOD_TRUCK_ENDPOINT = "https://data.sfgov.org/";
		private static readonly string APP_TOKEN = "mhcO1FwIW722614v32QRXL42s";

		private string _endPoint;
		private string _token;

		public FoodTruckApiService(string endPoint, string token)
		{
			_endPoint = endPoint;
			_token = token;
		}

		public string GetFoodTruckEndpoint()
		{
			return _endPoint;
		}

		public string GetFoodTruckToken()
		{
			return "Basic " + _token;
		}

		public async Task<HttpResponseMessage> PerformGetRequest(string route = "", IEnumerable<KeyValuePair<string, string>> headers = null, IEnumerable<KeyValuePair<string, string>> filters = null)
		{
			using (var client = new HttpClient())
			{
				AddCommonDefaultRequestHeaders(client);

				if (headers != null)
				{
					foreach (var header in headers)
					{
						client.DefaultRequestHeaders.Add(header.Key, header.Value);
					}
				}

				try
				{

					return await client.GetAsync(GetFoodTruckEndpoint() + route.Trim('/') + GetRequestFilterString(filters));

				}
				catch (Exception ex)
				{
					var logMessage = "Get request to Food Truck Rest API failed.";
					throw new FoodTruckException(logMessage, ex);
				}
			}
		}

		/// <summary>
		/// Generate fitler string for the request
		/// </summary>
		/// <param name="filters"></param>
		/// <returns></returns>
		private string GetRequestFilterString(IEnumerable<KeyValuePair<string, string>> filters)
		{
			if (filters == null) return "";

			StringBuilder sb = new StringBuilder();
			int i = 0;
			foreach(var filter in filters)
			{
				if (!string.IsNullOrEmpty(filter.Key))
				{
					if (i == 0)
					{
						sb.Append("?");
					}
					else
					{
						sb.Append("&");
					}
					sb.Append(filter.Key).Append("=").Append(filter.Value);
					i++;
				}
				
			}

			return sb.ToString();
		}

		/// <summary>
		/// Add common default request header
		/// </summary>
		/// <param name="client"></param>
		private void AddCommonDefaultRequestHeaders(HttpClient client)
		{
			client.DefaultRequestHeaders.Add(ApiHeaders.ACCEPT, "application/json");
			client.DefaultRequestHeaders.Add(ApiHeaders.AUTHORIZATION, GetFoodTruckToken());
		}
	}
}
