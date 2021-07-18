using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.API.DataTransferObjects;
using Newtonsoft.Json;
using System.Linq;

namespace WebApiClient.API
{
	/// <inheritdoc cref="IFoodTruckApiGetRequestService"/>
	public class FoodTruckApiGetRequestService : IFoodTruckApiGetRequestService
	{
		private readonly IFoodTruckApiService _foodTruckApiService;

		public FoodTruckApiGetRequestService(IFoodTruckApiService foodTruckApiService)
		{
			_foodTruckApiService = foodTruckApiService;
		}

		public async Task<FoodTrucks> GetFoodTrucks(List<KeyValuePair<string, string>> filters = null, int pageNumber = 1, int pageSize = 100, List<KeyValuePair<string, string>> headers = null)
		{
			using (var responseMessage = await _foodTruckApiService.PerformGetRequest("", headers, filters))
			{
				// Check that response was successful or throw an exception.
				responseMessage.EnsureSuccessStatusCode();

				var result = await responseMessage.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<FoodTrucks>(result);
			}
		}
	}
}
