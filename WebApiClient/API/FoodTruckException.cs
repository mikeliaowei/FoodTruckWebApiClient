using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiClient.API
{
	public class FoodTruckException : Exception
	{

		public FoodTruckException(string message)
			: base(message)
		{
		}

		public FoodTruckException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
