using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient.API;
using System.Linq;

namespace WebAPIClient
{
    class Program
    {
       
        static async Task Main(string[] args)
        {
            if(args.Length != 3)
			{
                PrintDataString("NA");
            }

            string endPoint = args[0].TrimStart('[').TrimEnd(']').TrimEnd(',');
            string authToken = args[2].TrimStart('[').TrimEnd(']').TrimEnd(',');
            string timeStamp = args[1].TrimStart('[').TrimEnd(']').TrimEnd(',');

            if (!string.IsNullOrEmpty(endPoint) && !string.IsNullOrEmpty(authToken) && !string.IsNullOrEmpty(timeStamp))
			{

				try
				{
                    FoodTruckController controller = new FoodTruckController(endPoint, authToken);

                    var trucks = await controller.GetFoodTrucksByTimeStamp(timeStamp);

                    if (trucks != null && trucks.data.Count > 0)
                    {
                        List<string> lstResults = new List<string>();
                        foreach (var item in trucks.data.OrderBy(c => c.applicant))
                        {
                            lstResults.Add(item.applicant.ToString().Trim() + ", " + item.locationid.ToString().Trim());
                        }

                        //Sort the result by alphabetical order
                        lstResults.Sort((s1, s2) => { return string.Compare(s1, s2, StringComparison.Ordinal); });

                        foreach (string s in lstResults)
                        {
                            PrintDataString(s);
                        }
                    }
                    else
                    {
                        PrintDataString("NA");
                    }
				}
				catch(Exception e)
				{
                    PrintDataString("NA");
                }

            }
			else
			{
                PrintDataString("NA");

            }
        }

        

        public static void PrintDataString(string str)
		{
            Console.WriteLine(str);
        }
    }
}