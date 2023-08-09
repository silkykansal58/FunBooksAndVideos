using System;
namespace FunBooksAndVideos.Exceptions
{
	public class ItemNotFoundException : Exception
	{
		public ItemNotFoundException(string message) : base(message)
		{
		}
	}
}

