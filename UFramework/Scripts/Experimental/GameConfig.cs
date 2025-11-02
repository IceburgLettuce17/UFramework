using UnityEngine;

namespace UFramework
{
	public static class GameConfig
	{
		public static string screenOrientation = "landscape";
		
		// Modify this to include your own properties/settings if you want and delete the example below
		public static string Comment1="NOTE! This is an example properties file of UFramework's Game feature.",Comment2="You should modify this with your own properties if you are using UFramework's Game feature for your own releases, and also update your scripts to use them.";
		
		public static string GameVersion = Application.version;
	}
}