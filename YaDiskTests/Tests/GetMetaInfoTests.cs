using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace YaDiskTests.Tests
{
	[TestClass]
	public class GetMetaInfoTests
	{
		[TestMethod]
		public void MetaInfoResponseStatusCodeTest()
		{
			string statusCode = RequestHelper.HttpRequestReturnStatus(URL.FullDiskPath, RequestMethod.Get);

			Assert.AreEqual(ResponseStatus.Ok, statusCode);
		}

		[TestMethod]
		public void MetaInfoResponseReturnJsonTest()
		{
			string response = RequestHelper.HttpRequestToString(URL.FullDiskPath, RequestMethod.Get);
			ResponseModel metaInfoJson = JsonHelper.ConvertToJson<ResponseModel>(response);

			Assert.IsNotNull(metaInfoJson);
		}
	}
}
