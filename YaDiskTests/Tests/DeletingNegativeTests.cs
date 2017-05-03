using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YaDiskTests
{
	[TestClass]
	public class DeletingNegativeTests
	{
		[TestMethod]
		public void DeletingNonexistentFolderReturnErrorTest()
		{
			string nonexistentFolderName = @"NonexistentFolderName";

			WebException exception = ExceptionsAsserting.AssertCatch<WebException>(() =>
				ResourceHelper.DeleteResource(nonexistentFolderName, true));

			Assert.AreEqual("The remote server returned an error: (404) Not Found.", exception.Message);
		}
	}
}
