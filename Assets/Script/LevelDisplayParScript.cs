using UnityEngine;
using System.Collections;

public class LevelDisplayParScript : MonoBehaviour {

	public int levelNum;
	public TextMesh text;
	public LinkLevelOnButton unlocked;
	public GameObject lockUI, achievementUI, parUI;
	void Start () {
		LevelInfo level = (LevelInfo)SaveManager.save.levels[levelNum - 1];
		text.text = level.lowScore + "/" + level.par;
		unlocked.unlocked = level.unlocked;
		lockUI.SetActive(!level.unlocked);
		achievementUI.SetActive(level.achievement);

		if(level.lowScore <= level.par && level.lowScore != 0)
			parUI.SetActive(true);
		else
			parUI.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	}
}
