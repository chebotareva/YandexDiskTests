using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YaDiskTests
{
	public class BaseTest
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
			finally
			{
				ResourceHelper.CreateResource(folderName);
			}
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
