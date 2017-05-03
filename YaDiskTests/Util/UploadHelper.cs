using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YaDiskTests
{
	public class UploadHelper
    {
		public string pathForUpload;
		public bool overwrite;
		public string fields;

		public static string RequestUrlForUploadFile(string uploadPath)
        {
			string urlForUploadFile = RequestHelper.HttpGetRequestToString(URL.UploadPath + uploadPath);
            return urlForUploadFile;
        }

		public static string RequestUrlForUploadFile(string uploadPath, bool overwrite)
        {
			string urlForUploadFile = RequestHelper.HttpGetRequestToString(URL.UploadPath + uploadPath + "&overwrite=" + overwrite);
            return urlForUploadFile;
        }

		public static string UnauthorizedRequestUrlForUploadFile(string uploadPath)
		{
			HttpWebResponse response = RequestHelper.HttpRequest(URL.UploadPath + uploadPath, RequestMethod.Get, null);
			string urlForUploadFile = RequestHelper.ReadHttpResponseString(response);
			return urlForUploadFile;
		}

		public static HttpWebResponse RequestUrlAndUploadFile(string localFilePath, string uploadFolder)
		{
			string responseUrlForUploadFile = RequestUrlForUploadFile(URL.Disk + uploadFolder);
			HttpWebResponse response = ParseJsonAndUploadLocalFile(localFilePath, responseUrlForUploadFile);
			return response;
		}

		public static HttpWebResponse TwiceRequestUrlAndUploadFile(string localFilePath, string uploadFolder)
		{
			RequestUrlAndUploadFile(localFilePath, uploadFolder);
			return RequestUrlAndUploadFile(localFilePath, uploadFolder);
		}

		public static HttpWebResponse RequestUrlAndUploadFile(string localFilePath, string uploadFolder, bool overwrite)
		{
			string responseUrlForUploadFile = RequestUrlForUploadFile(URL.Disk + uploadFolder, overwrite);
			HttpWebResponse response = ParseJsonAndUploadLocalFile(localFilePath, responseUrlForUploadFile);
			return response;
		}

		public static HttpWebResponse ParseJsonAndUploadLocalFile(string localFilePath, string responseForUploadFile)
		{
			ResponseModel uploadJson = JsonHelper.ConvertToJson<ResponseModel>(responseForUploadFile);
			string urlForUploadFile = uploadJson.href;
			HttpWebResponse responseText = UploadLocalFile(localFilePath, urlForUploadFile);
			return responseText;
		}

		public static HttpWebResponse UploadLocalFile(string localFile, string uploadUrl)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);

			request.Method = RequestMethod.Put;
			request.ServicePoint.Expect100Continue = true;
			request.AllowWriteStreamBuffering = true;
			request.SendChunked = false;
			request.KeepAlive = true;
			Stream requestStream = request.GetRequestStream();
			FileStream reader = new FileStream(localFile, FileMode.Open, FileAccess.Read);
			byte[] inData = new byte[4096];
			int bytesRead = reader.Read(inData, 0, inData.Length);

			while (bytesRead > 0)
			{
				requestStream.Write(inData, 0, bytesRead);
				bytesRead = reader.Read(inData, 0, inData.Length);
			}

			requestStream.Close();
			reader.Close();

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			return response;
		}
    }
}