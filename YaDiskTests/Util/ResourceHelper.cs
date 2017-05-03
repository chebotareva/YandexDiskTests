using System.Collections.Generic;
using System.Net;
using System;

namespace YaDiskTests
{
	public class ResourceHelper : JsonHelper
	{
		public static HttpWebResponse CreateResource(string resourceName)
		{
			return RequestHelper.HttpRequest(URL.FullDiskPath + resourceName, RequestMethod.Put);
		}

		public static string CreateResourceReturnString(string resourceName)
		{
			HttpWebResponse response = RequestHelper.HttpRequest(URL.FullDiskPath + resourceName, RequestMethod.Put);
			return RequestHelper.ReadHttpResponseString(response);
		}

		public static void TwiceCreateFolder(string pathToFolder)
		{
			RequestHelper.HttpRequest(URL.FullDiskPath + pathToFolder, RequestMethod.Put);
			RequestHelper.HttpRequest(URL.FullDiskPath + pathToFolder, RequestMethod.Put);
		}

		public static HttpWebResponse DeleteResource(string pathToResource, bool permanently)
		{
			return RequestHelper.HttpRequest(URL.FullDiskPath + pathToResource + "&permanently=" + permanently, RequestMethod.Delete);
		}

        public static bool ItemNameIsPresent(string url, string itemName)
		{
			ResourceModel root = HttpRequestReturnJson<ResourceModel>(url, RequestMethod.Get);

			Resource[] items = root._embedded.items;

			List<string> itemsNamesList = new List<string>();
			foreach (Resource item in items)
			{
				string nameOfItem = item.name;
				itemsNamesList.Add(nameOfItem);
			}
			
			if (itemsNamesList.Contains(itemName))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
