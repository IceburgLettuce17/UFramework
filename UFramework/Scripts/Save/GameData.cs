namespace UFramework.Save
{
	// This is just an example GameData script, so you don't need to make one yourself
	// I recommend a GameManager script that inherits from IPersistent to execute saving itself
	// Example: (uses this GameData class)
	//public class GameManager : MonoBehaviour, IPersistent
	//{
	//	public int anInt;
	//		
	//	public bool aBool;
	//		
	//	public string aString;
	//		
	//	public double aDouble;	
	//		
	//	public string getterSetter
	//	{
	//		get
	//		{
	//			return "getter";
	//		}	
	//		set
	//		{
	//			value = "setter";
	//		}
	//	}
	//		
	//	public static int staticVar;
	//		
	//	protected int protVar;
	//		
	//	private int privVar;
	//		
	//	public decimal aDecimal;
	//	
	//	public void SaveData(ref GameData data)
	//	{
	//		data.anInt = anInt;
	//		data.aBool = aBool;
	//		data.aDecimal = aDecimal;
	//		data.aString = aString;
	//		data.aDouble = aDouble;
	//	}
	//	
	//	public void LoadData(GameData data)
	//	{
	//		anInt = data.anInt;
	//		aBool = data.aBool;
	//		aDecimal = data.aDecimal;
	//		aString = data.aString;
	//		aDouble = data.aDouble;
	//	}
	//}
	public class GameData
	{
		// Example lines below (remove these before setting up saving/loading)
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
	}
}