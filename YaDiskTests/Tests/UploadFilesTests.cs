using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace YaDiskTests
{
    [TestClass]
	public class UploadFilesTests : CreateBaseTest
    {
		[TestMethod]
		public void TextFileCanBeUploadedTest()
		{
			string localFile = @"Test.txt";

			HttpWebResponse response = UploadHelper.RequestUrlAndUploadFile(localFile, folderName);
			string actualStatusCode = response.StatusCode.ToString();

			Assert.AreEqual(ResponseStatus.Created, actualStatusCode);
		}

		[TestMethod]
		public void FileAlreadyExistResponseErrorTest()
		{
			string localFile = @"Test.txt";

			WebException exception = ExceptionsAsserting.AssertCatch<WebException>(() =>
				UploadHelper.TwiceRequestUrlAndUploadFile(localFile, folderName));

			Assert.AreEqual("The remote server returned an error: (409) Conflict.", exception.Message, "Error (409) Conflict expected");
		}

		[TestMethod]
		public void ExistedFileCanBeUploadedWithOverwriteTest()
		{
			string localFile = @"Test.txt";

			UploadHelper.RequestUrlAndUploadFile(localFile, folderName);
			HttpWebResponse response = UploadHelper.RequestUrlAndUploadFile(localFile, folderName, true);
			string actualStatusCode = response.StatusCode.ToString();

			Assert.AreEqual(ResponseStatus.Created, actualStatusCode);
		}

        [TestMethod]
        public void EmptyTextFileCanBeUploadedTest()
        {
			string localFile = @"EmptyFile.txt";

			HttpWebResponse response = UploadHelper.RequestUrlAndUploadFile(localFile, folderName);
			string actualStatusCode = response.StatusCode.ToString();

			Assert.AreEqual(ResponseStatus.Created, actualStatusCode);
        }

        [TestMethod]
        public void CyrillicNamedFileCanBeUploadedTest()
        {
			string localFile = @"Текст.txt";

			HttpWebResponse response = UploadHelper.RequestUrlAndUploadFile(localFile, folderName);
			string actualStatusCode = response.StatusCode.ToString();

			Assert.AreEqual(ResponseStatus.Created, actualStatusCode);
		}
    }
}
