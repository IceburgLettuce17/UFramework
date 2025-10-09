using System.Collections.Generic;
using System;

namespace UFramework.Core
{
	// Some extension stuffs for locale
	public static class Extensions
	{
		private static Random _random;
		
		private static Random random
		{
			get
			{
				if (_random == null)
				{
					_random = new Random();
				}
				return _random;
			}
		}
		// Gets a random value from a List	
		public static T GetRandom<T>(this IList<T> list) where T : class
		{
			if (list.Count == 0)
			{
				return (T)((object)null);
			}
			return list[random.Next(0, list.Count)];
		}
		
		// Gets a random value from an Enum
		public static T GetRandomEnum<T>(this IList<T> list) where T : struct, IConvertible, IComparable, IFormattable
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("[Extensions] Must be an Enum type!");
			}
			if (list.Count == 0)
			{
				return default(T);
			}
			return list[Extensions.random.Next(0, list.Count)];
		}	
	}
}