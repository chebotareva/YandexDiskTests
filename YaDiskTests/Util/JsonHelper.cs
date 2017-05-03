using System;
using System.Net;
using Newtonsoft.Json;

namespace YaDiskTests
{
	public class JsonHelper
    {
		public static T ConvertToJson<T>(string text) where T : new()
		{
			return !string.IsNullOrEmpty(text) ? JsonConvert.DeserializeObject<T>(text) : new T();
		}

        public static T HttpRequestReturnJson<T>(string requestUri, string requestMethod) where T : new()
        {
            string responseText = RequestHelper.HttpRequestToString(requestUri, requestMethod);
			return ConvertToJson<T>(responseText);
        }
    }
}
