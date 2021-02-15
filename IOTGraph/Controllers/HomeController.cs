using IOTGraph.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOTGraph.Controllers
{
    public class HomeController : Controller
    {
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}


		public ContentResult JSON(int xStart = 0, double yStart = 0, int length = 1)
		{

            List<DataPoint> dataPoints = new List<DataPoint>();
			Random random = new Random();
			double y = yStart;

			for (int i = 0; i < length; i++)
			{
				y = y + random.Next(-1, 2);
				dataPoints.Add(new DataPoint(xStart + i, y));
			}

			return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
		}

		JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };


        //public async System.Threading.Tasks.Task<string> downloadLatestBlobContent()
        //{
        //    CloudStorageAccount storageAccount = ConnectionString.GetConnectionString();

        //    // Create the blob client.
        //    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

        //    // Retrieve reference to a previously created container.
        //    CloudBlobContainer container = blobClient.GetContainerReference("hithaiothub");

        //    //find the latest blob
        //    CloudBlockBlob latestBlob = container.ListBlobs()
        //                    .OfType<CloudBlockBlob>()
        //                    .OrderByDescending(m => m.Properties.LastModified)
        //                    .ToList()
        //                    .First();

        //    return await latestBlob.DownloadTextAsync();
        //}
    }
}