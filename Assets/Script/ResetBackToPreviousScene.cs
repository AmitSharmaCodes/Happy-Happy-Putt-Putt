using UnityEngine;
using System.Collections;

public class ResetBackToPreviousScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.LoadLevel(SaveManager.save.PreviousScene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
