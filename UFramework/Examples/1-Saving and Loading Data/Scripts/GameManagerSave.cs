using UnityEngine;
using UFramework.Save;
using UFramework.Examples;

namespace UFramework.Examples
{
	public class GameManagerSave : MonoBehaviour, IPersistent
	{
		public int anInt;
			
		public bool aBool;
			
		public string aString;
			
		public double aDouble;
			
		public string getterSetter
		{
			get
			{
				return "getter";
			}	
			set
			{
				value = "setter";
			}
		}
			
		public static int staticVar;
			
		protected int protVar;
			
		private int privVar;
			
		public decimal aDecimal;
		
		public void SaveData(ref GameData data)
		{
			data.anInt = anInt;
			data.aBool = aBool;
			data.aDecimal = aDecimal;
			data.aString = aString;
			data.aDouble = aDouble;
		}
		
		public void LoadData(GameData data)
		{
			anInt = data.anInt;
			aBool = data.aBool;
			aDecimal = data.aDecimal;
			aString = data.aString;
			aDouble = data.aDouble;
		}
	}
}