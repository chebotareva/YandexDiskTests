using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YaDiskTests
{
	public class CreateBaseTest
	{
		protected string folderName = @"Test";

		[TestInitialize]
		public void SetupTest()
		{
			try
			{
				ResourceHelper.DeleteResource(folderName, true);
			}
			catch
			{ }
		}

		[TestCleanup]
		public void TeardownTest()
		{
			try
			{
				ResourceHelper.DeleteResource(folderName, true);
			}
			catch
			{ }
		}
	}
}
