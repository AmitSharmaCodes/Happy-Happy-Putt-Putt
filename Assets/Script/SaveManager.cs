using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {

	public static SaveManager save;
	public ArrayList levels;
	public int[] fillIn = {2, 2, 3, 2, 3, 4, 2, 1, 2, 15};
	public int PreviousScene;
	void Awake() {

		if(save == null)
		{
			Debug.Log(Application.persistentDataPath + "/Leveldata.dat");
			levels = new ArrayList();
			DontDestroyOnLoad(gameObject);
			save = this;
			Load();
		}
		else if(save != this)
		{
			Destroy(gameObject);
		}
	}

	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/Leveldata.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/Leveldata.dat", FileMode.Open);
			PlayerSave ps = (PlayerSave)bf.Deserialize(file);
			levels = ps.list;

			debugSaveDisplay();
		}
		else //no data, create one
		{
			Debug.Log("Created save file");

			//save
			setData();
			Save();
			debugSaveDisplay();


		}
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/Leveldata.dat");
		PlayerSave PS = new PlayerSave();
		PS.list = levels;
		bf.Serialize(file, PS);
		file.Close();
		Debug.Log("Save Successful!");
	}

	private void setData()
	{
		Debug.Log(fillIn.Length);
		for(int i = 0; i < fillIn.Length; i++) //create data
		{
			LevelInfo temp = new LevelInfo();
			temp.achievement = false;
			if(i == 0)
				temp.unlocked = true;
			else
				temp.unlocked = false;
			temp.par = fillIn[i];
			temp.lowScore = 0;
			levels.Add (temp);
		}
	}
	private void debugSaveDisplay()
	{
		int levelI = 1;
		foreach(LevelInfo o in levels)
		{
			LevelInfo lev = o;
			Debug.Log("Level " + levelI +
			          "; low score: " + lev.lowScore +
			          ";\tpar: " + lev.par + 
			          ";\tachievement: " + lev.achievement +
			          ";\tunlocked: " + lev.unlocked);
			levelI++;
		}
	}
}

[Serializable]
class LevelInfo
{
	public int par;
	public int lowScore;
	public bool achievement;
	public bool unlocked;
}

[Serializable]
class PlayerSave
{
	public ArrayList list;
}
