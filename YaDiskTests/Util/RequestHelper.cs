using System;
using System.IO;
using System.Net;

namespace YaDiskTests
{
	public class RequestHelper 
	{
		public static HttpWebResponse HttpRequest(string requestUri, string requestMethod)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

			request.Method = requestMethod;
			request.ContentType = "application/json";
			request.Headers["Authorization"] = Auth.authHeaders;

			return (HttpWebResponse)request.GetResponse();
		}

		public static HttpWebResponse HttpRequest(string requestUri, string requestMethod, string authHeaders)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

			request.Method = requestMethod;
			request.ContentType = "application/json";
			request.Headers["Authorization"] = authHeaders;

			return (HttpWebResponse)request.GetResponse();
		}

		public static string HttpRequestToString(string requestUri, string requestMethod)
		{
			HttpWebResponse response = HttpRequest(requestUri, requestMethod);
			return ReadHttpResponseString(response);
		}

		public static HttpWebResponse HttpPatchRequest(string requestUri, string json)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

			request.Method = RequestMethod.Patch;
			request.ContentType = "application/json";
			request.Headers["Authorization"] = Auth.authHeaders;

			using (var requestWriter = new StreamWriter(request.GetRequestStream()))
			{
				requestWriter.Write(json);
				requestWriter.Flush();
				requestWriter.Close();
			}
			return (HttpWebResponse)request.GetResponse();
		}

        public static string HttpGetRequestToString(string requestUri)
        {
            return HttpRequestToString(requestUri, RequestMethod.Get);
        }

        public static string HttpRequestReturnStatus(string requestUri, string requestMethod)
        {
            HttpWebResponse response = HttpRequest(requestUri, requestMethod);
            return response.StatusCode.ToString();
        }

        public static string ReadHttpResponseString(WebResponse response)
		{
			string responseText = String.Empty;
			using (StreamReader sr = new StreamReader(response.GetResponseStream()))
			{
				responseText = sr.ReadToEnd();
			}
			return responseText;
		}
	}
}
