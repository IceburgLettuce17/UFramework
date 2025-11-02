using UFramework;

namespace UFramework.Save
{
	public interface IPersistent
	{
		void LoadData(GameData data);
	
		void SaveData(ref GameData data);
	}
}