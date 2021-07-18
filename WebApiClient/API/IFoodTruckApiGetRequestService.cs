using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient.API.DataTransferObjects;

namespace WebApiClient.API
{
	/// <summary>
	/// An interface containing methods that perform GET requests to the Food Truck REST API.
	/// </summary>
	public interface IFoodTruckApiGetRequestService
	{
		/// <summary>
		/// A method that calls the REST API to get a list of FoodTruck data
		/// </summary>
		/// <param name="headers">An optional list of key value pairs of headers to include in the request. Default is null</param>
		/// <returns>list of FoodTruck</returns>
		Task<FoodTrucks> GetFoodTrucks(List<KeyValuePair<string, string> > filters = null, int pageNumber = 1, int pageSize = 100, List<KeyValuePair<string, string>> headers = null);
	}
}
