using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YaDiskTests
{
	[TestClass]
	public class CreatingNegativeTests
	{
		[TestMethod]
		public void SubfolderCreatingReturnErrorTest()
		{
			string foldersName = @"Test/Test2";
			WebException exception = ExceptionsAsserting.AssertCatch<WebException>(() =>
				ResourceHelper.CreateResource(foldersName));

			Assert.AreEqual("The remote server returned an error: (409) Conflict.", exception.Message);
		}
	}
}
