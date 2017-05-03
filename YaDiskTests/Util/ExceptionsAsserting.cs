using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YaDiskTests
{
	public class ExceptionsAsserting
	{
		public static TException AssertCatch<TException>(Action action)
	where TException : Exception
		{
			try
			{
				action();
			}
			catch (TException exception)
			{
				return exception;
			}

			throw new AssertFailedException("Expected exception of type " +
											typeof(TException) + " was not thrown");
		}
	}
}
