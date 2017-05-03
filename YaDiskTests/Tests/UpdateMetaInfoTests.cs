using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace YaDiskTests
{
	[TestClass]
	public class UpdateMetaInfoTests : BaseTest
	{
		[TestMethod]
		public void ResourceNameIsPresentTest()
		{
			bool isPresent = ResourceHelper.ItemNameIsPresent(URL.FullDiskPath, folderName);

			Assert.IsTrue(isPresent);
		}

		[TestMethod]
		public void AddMetaInfoForFolderResponseStatusTest()
		{
			string json = "{\"custom_properties\":{\"foo\":\"1\",\"bar\":\"2\"}}";

			HttpWebResponse response = RequestHelper.HttpPatchRequest(URL.FullDiskPath + folderName, json);
			string actualResponseStatus = response.StatusCode.ToString();

			Assert.AreEqual(ResponseStatus.Ok, actualResponseStatus);
		}

		[TestMethod]
		public void InvalidAttributesMetaInfoIgnoredTest()
		{
			string json = "{\"test_properties\":{\"foo\":\"1\",\"bar\":\"2\"}}";

			HttpWebResponse response = RequestHelper.HttpPatchRequest(URL.FullDiskPath + folderName, json);
			string actualResponseCode = response.StatusCode.ToString();

			Assert.AreEqual(ResponseStatus.Ok, actualResponseCode);
		}
	}
}