using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YaDiskTests
{
	[TestClass]
	public class CreatingTests : CreateBaseTest
	{
		[TestMethod]
		public void FolderCreatingStatusCodeTest()
		{
			HttpWebResponse response = ResourceHelper.CreateResource(folderName);
			string actualResponseStatus = response.StatusCode.ToString();

			Assert.AreEqual(ResponseStatus.Created, actualResponseStatus);
		}

		[TestMethod]
		public void FolderCanBeCreatedTest()
		{ 
			string response = ResourceHelper.CreateResourceReturnString(folderName);
			ResponseModel responseJson = JsonHelper.ConvertToJson<ResponseModel>(response);
			string actualFolderUrl = responseJson.href;

			string expectedFolderUrl = @"https://cloud-api.yandex.net/v1/disk/resources?path=disk%3A%2F" + folderName;

			Assert.AreEqual(expectedFolderUrl, actualFolderUrl);
		}

		[TestMethod]
		public void FolderWithCyrillicNameCanBeCreatedTest()
		{
			folderName = @"Тест";

			string response = ResourceHelper.CreateResourceReturnString(folderName);
			ResponseModel responseJson = JsonHelper.ConvertToJson<ResponseModel>(response);
			string actualFolderUrl = responseJson.href;
			
			string expectedFolderUrl = @"https://cloud-api.yandex.net/v1/disk/resources?path=disk%3A%2F%D0%A2%D0%B5%D1%81%D1%82";

			Assert.AreEqual(expectedFolderUrl, actualFolderUrl);
		}

		[TestMethod]
		public void FolderCreatingWithExistedNameReturnErrorTest()
		{
			WebException exception = ExceptionsAsserting.AssertCatch<WebException>(() =>
				ResourceHelper.TwiceCreateFolder(folderName));

			Assert.AreEqual("The remote server returned an error: (409) Conflict.", exception.Message);
		}

		[TestMethod]
		public void FolderWithSpecialCharsNameCanBeCreatedTest()
		{
			folderName = @"$@D\,$K` ,$SIF&2YK_G";
			HttpWebResponse response = ResourceHelper.CreateResource(folderName);
			string actualResponseStatus = response.StatusCode.ToString();

			Assert.AreEqual(ResponseStatus.Created, actualResponseStatus);
		}

		[TestMethod]
		public void FolderWithMaximumNameLengthCanBeCreatedTest()
		{
			folderName = @"12Z3J@)]YPYODM%9WaV$\CA.Q:CHRNCPACBB5FE,I 7>`R?CB579#1V9%Z&H5'\6_N!+D$181Y:B)QSJ#%09,7>3M(0MC^XB`!@1Q`>$W305'=D0XJ*H0O?<UEU3 ZD(1AZP&S5,.2<9Y\\F&:IK5XY!\VEJ@+W,_Q($GEU*&5`:_3&CZaOZ91.19@X[B(V 9QX_BF>E>#PP\Q@=]PBXL'N[J^A_\YV=S\!-5[K.9\\=(,@85D<12Q@=]PBXL62";

			HttpWebResponse response = ResourceHelper.CreateResource(folderName);
			string actualResponseStatus = response.StatusCode.ToString();

			Assert.AreEqual(ResponseStatus.Created, actualResponseStatus);
		}
	}
}
