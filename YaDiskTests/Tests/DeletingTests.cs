using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YaDiskTests
{
	[TestClass]
	public class DeletingTests : BaseTest
	{
		[TestMethod]
        public void FolderCanBeDeletedTest()
		{
			HttpWebResponse response = ResourceHelper.DeleteResource(folderName, true);
            string actualResponseStatus = response.StatusCode.ToString();

            Assert.AreEqual(ResponseStatus.NoContent, actualResponseStatus);
        }
    }
}
