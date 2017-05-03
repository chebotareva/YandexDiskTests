using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace YaDiskTests
{
	[TestClass]
	public class UploadsTests
	{
		[TestMethod]
		public void UrlForUploadingFileCanBeRequestedTest()
		{
			string uploadPath = @"disk:/Test";

			string response = UploadHelper.RequestUrlForUploadFile(uploadPath);
			ResponseModel uploadJson = JsonHelper.ConvertToJson<ResponseModel>(response);

			Assert.IsNotNull(uploadJson);
		}

		[TestMethod]
		public void UrlForUploadingFileWithOverwriteCanBeRequestedTest()
		{
			string uploadPath = @"disk:/Test";

			string response = UploadHelper.RequestUrlForUploadFile(uploadPath, true);
			ResponseModel uploadJson = JsonHelper.ConvertToJson<ResponseModel>(response);

			Assert.IsNotNull(uploadJson);
		}

		[TestMethod]
		public void UnauthorizedRequestForUploadFileTest()
		{
			string uploadPath = @"disk:/Test";

			WebException exception = ExceptionsAsserting.AssertCatch<WebException>(() =>
				UploadHelper.UnauthorizedRequestUrlForUploadFile(uploadPath));

			Assert.AreEqual("The remote server returned an error: (401) Unauthorized.", exception.Message);
		}

		[TestMethod]
		public void PathFormatIsNotSupportedForUploadTest()
		{
			string filePath = @"https://www.w3.org/2008/site/images/logo-w3c-mobile-lg";
			string folderName = @"Test";

			Exception exception = ExceptionsAsserting.AssertCatch<Exception>(() =>
				UploadHelper.RequestUrlAndUploadFile(filePath, folderName));

			Assert.AreEqual("The given path's format is not supported.", exception.Message);
		}
	}
}
