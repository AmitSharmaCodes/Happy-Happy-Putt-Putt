using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {
	public GUIText text;
	int par;
	// Use this for initialization
	//public float ratio;
	void Start () {


		par = ((LevelInfo)SaveManager.save.levels[FindObjectOfType<LevelScript>().levelNum - 1]).par;
//		Debug.Log (par);
		float height = Screen.currentResolution.height;
		text.fontSize = Mathf.RoundToInt(height / 18);
		text.text = gameController.stroke + "/" + par;
	}
	// Update is called once per frame
	void Update () {
		text.text = gameController.stroke + "/" + par;
	}
}
