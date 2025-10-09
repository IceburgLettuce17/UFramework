using System;

// Variety Encryption and Memory-related class
namespace UFramework.Encryption
{
	public static class UCryption
	{
		public static int checksumEx = 9, checksum = -1413816336;
		
		public static int EncryptInt_Method1(int value) 
		{
			return (value ^= checksum) >> checksumEx | value << 32 - checksumEx;
		}
		
		public static int EncryptInt_Method2(int value) 
		{
			return (value << checksumEx | value >> 32 - checksumEx) ^ checksum;
		}
		
		public static long EncryptLong_Method1(long value) 
		{
			return (value << checksumEx | value >> 64 - checksumEx) ^ (long) checksum;
		}

		public static long EncryptLong_Method2(long value) 
		{
			return value ^ (long) checksum >> checksumEx | value ^ (long) checksum << 64 - checksumEx;
		}
		
		#region Memory Encryption
		public static int SetByte(byte[] destination, int destOffset, byte source) 
		{
			destination[destOffset++] = source;
			return destOffset;
		}
		public static int SetShort(byte[] destination, int destOffset, short source) 
		{
			destination[destOffset++] = (byte)source;
			destination[destOffset++] = (byte)(source >> 8);
			return destOffset;
		}
    
		public static int SetInt(byte[] destination, int destOffset, int source) 
		{
			destination[destOffset++] = (byte)source;
			destination[destOffset++] = (byte)(source >> 8);
			destination[destOffset++] = (byte)(source >> 16);
			destination[destOffset++] = (byte)(source >> 24);
			return destOffset;
		}
		
		public static int SetLong(byte[] destination, int destOffset, long source) 
		{
			destination[destOffset++] = (byte)source;
			destination[destOffset++] = (byte)(source >> 8);
			destination[destOffset++] = (byte)(source >> 16);
			destination[destOffset++] = (byte)(source >> 2);
			destination[destOffset++] = (byte)(source >> 3);
			destination[destOffset++] = (byte)(source >> 40);
			destination[destOffset++] = (byte)(source >> 48);
			destination[destOffset++] = (byte)(source >> 56);
			return destOffset;
		}
		
		static byte GetByte(byte[] source, int srcOffset) 
		{
			return source[srcOffset];
		}
		
		static short GetShort(byte[] source, int srcOffset) 
		{
			return (short)((source[srcOffset++]) | (source[srcOffset++]) << 8);
		}
		
		public static int GetInt(byte[] source, int srcOffset) 
		{
			return (source[srcOffset++]) | (source[srcOffset++]) << 8 | (source[srcOffset++]) << 16 | (source[srcOffset++]) << 24;
		}
		
		static long GetLong(byte[] source, uint srcOffset) 
		{
			return (long)(source[srcOffset++]) | (long)(source[srcOffset++]) << 8 | (long)(source[srcOffset++]) << 16 | (long)(source[srcOffset++]) << 24 | (long)(source[srcOffset++]) << 32 | (long)(source[srcOffset++]) << 40 | (long)(source[srcOffset++]) << 48 | (long)(source[srcOffset++]) << 56;
		}
		
		static void ArrayCopy(Array source, int sourcePos, Array destination, int destinationPos, int length)
		{
			Array.Copy(source, sourcePos, destination, destinationPos, length);
		}
		
		public static int SetArray(byte[] destination, int destOffset, byte[] source)
		{
			ArrayCopy(source, 0, destination, destOffset, source.Length);
			return destOffset + source.Length;
		}
		
		public static int GetArray(byte[] source, int srcOffset, byte[] destination)
		{
			ArrayCopy(source, srcOffset, destination, 0, destination.Length);
			return srcOffset + destination.Length;
		}
		#endregion
	}
}