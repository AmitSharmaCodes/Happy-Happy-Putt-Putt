using UnityEngine;
using System.Collections;

public class LevelScript: MonoBehaviour {

	// Use this for initialization
	public int levelNum;
	public Achievement ach;
	void Start () {
		ach.desc();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy()
	{
		if(gameController.victory)
		{
			LevelInfo level = (LevelInfo)SaveManager.save.levels[levelNum - 1];
			if(level.lowScore == 0)
				level.lowScore = gameController.stroke;
			else if(level.lowScore > gameController.stroke)
				level.lowScore = gameController.stroke;

			if(level.lowScore <= level.par)
			{
				level.achievement = ach.isAchieved();
				Debug.Log("MADE PAR");
			}

			int nextLevelNum = levelNum; // next level is the same as levelNum, because level 1 is at index 0, and 
										// and next level index is at 1, so, nextLevelIndex = this level number
			if(nextLevelNum <= SaveManager.save.fillIn.Length)
			{
				LevelInfo nextLevel = (LevelInfo)SaveManager.save.levels[nextLevelNum];
				nextLevel.unlocked = true;
				SaveManager.save.levels[nextLevelNum] = nextLevel;
			}

			SaveManager.save.levels[levelNum - 1] = level;
			SaveManager.save.Save();

		}
	}
}
