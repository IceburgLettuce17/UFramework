using UnityEngine;
using UFramework.Encryption;

public class EncryptionUc : MonoBehaviour 
{
	public static string str = "todo";
	
	public void Encrypt(int value, int method)
	{
		switch (method)
		{
			case 1:
			{
				value = UCryption.EncryptInt_Method1(value);
				print(value);
				break;
			}
			case 2:
			{
				value = UCryption.EncryptInt_Method2(value);
				print(value);
				break;
			}
		}
		str = value + "";
	}

	public void Encrypt1(int value)
	{
		Encrypt(value, 1);
	}

	public void Encrypt2(int value)
	{
		Encrypt(value, 2);
	}
	
	public void Encrypt1L(long value)
	{
		EncryptLong(value, 1);
	}

	public void Encrypt2L(long value)
	{
		EncryptLong(value, 2);
	}
	
	public void EncryptLong(long value, int method)
	{
		switch (method)
		{
			case 1:
			{
				value = UCryption.EncryptLong_Method1(value);
				print(value);
				break;
			}
			case 2:
			{
				value = UCryption.EncryptLong_Method2(value);
				print(value);
				break;
			}
		}
		str = value + "";
	}
}
