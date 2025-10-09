using UnityEngine;

namespace UFramework.Core
{
	[CreateAssetMenu(fileName = "UFrameworkSettings", menuName = "UFramework/Make settings")]
	public class Settings : ScriptableObject
	{
		[Header("Localization")]
		public string currLanguage;
		
		public string defLanguage;
		
		public string[] locales;
	}
}
