using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.API.DataTransferObjects;

namespace WebApiClient.API
{
	public interface IFoodTruckController
	{
		Task<FoodTrucks> GetFoodTrucksByTimeStamp(string timeStamp);
	}
}
