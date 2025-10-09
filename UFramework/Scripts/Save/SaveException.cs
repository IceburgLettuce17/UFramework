using System;
using System.Runtime.Serialization;

namespace UFramework.Save
{
	public class SaveException : Exception 
	{
		public SaveException()
		{
		}
		
		public SaveException(string message) : base (message)
		{
		}
		
		public SaveException(string message, Exception inner) : base (message, inner)
		{
		}
	}
}

