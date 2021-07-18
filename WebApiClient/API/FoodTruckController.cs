using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.API.DataTransferObjects;

namespace WebApiClient.API
{
	public class FoodTruckController : IFoodTruckController
	{
		private readonly FoodTruckApiService _foodTruckApiService;
		private readonly FoodTruckApiGetRequestService _foodTruckApiGetRequestService;

		public FoodTruckController(string endPoint, string authToken)
		{
			_foodTruckApiService = new FoodTruckApiService(endPoint, authToken);
			_foodTruckApiGetRequestService = new FoodTruckApiGetRequestService(_foodTruckApiService);
		}

		public async Task<FoodTrucks> GetFoodTrucksByTimeStamp(string timeStamp)
		{
			bool timeIsValide = FoodTruckHelper.UnixTimeStampToDateTime(timeStamp, out DateTime utcDate);

			if (!timeIsValide)
				return null;

			List<KeyValuePair<string, string>> kvParams = new List<KeyValuePair<string, string>>()
														{ new KeyValuePair<string, string>("hour", utcDate.Hour.ToString()),
														  new KeyValuePair<string, string>("minutes", utcDate.Minute.ToString()),
														  new KeyValuePair<string, string>("dayOrder", FoodTruckHelper.StartOfWeek(utcDate, DayOfWeek.Sunday).ToString())};

			return await _foodTruckApiGetRequestService.GetFoodTrucks(kvParams);
		}
	}
}
