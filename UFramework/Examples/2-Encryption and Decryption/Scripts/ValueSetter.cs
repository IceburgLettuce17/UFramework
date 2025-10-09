using UnityEngine;
using UnityEngine.UI;
using UFramework.Encryption;

namespace UFramework.Examples
{
	public class ValueSetter : MonoBehaviour 
	{
		public bool isXOR, isUcrypt;
		
		public Text textToChange;
		
		public void Update()
		{
			if (isXOR)
			{
				textToChange.text = EncryptionXOR.value;
			}
			else if (isUcrypt)
			{
				textToChange.text = EncryptionUc.str;
			}
			else
			{
				textToChange.text = EncryptionAES.value;
			}
		}
	}
}
