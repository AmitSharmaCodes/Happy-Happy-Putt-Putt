using UnityEngine;
using System.Collections;
using System.IO;

public class FirstScreneScript : MonoBehaviour {

	public int tutorialLevelScene;
	public int worldMapScene;
	// Use this for initialization
	void Start () {
		Debug.Log(Application.persistentDataPath + "/Leveldata.dat");
		if(File.Exists(Application.persistentDataPath + "/Leveldata.dat"))
		{
			Debug.Log("load world");
			Application.LoadLevel(worldMapScene);
		}
		else
		{
			Debug.Log("load tutorial");
			Application.LoadLevel(tutorialLevelScene);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
