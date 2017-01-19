using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour {

	// Use this for initialization
	public GUIText text;
	float previousTime;
	float currentTime;
	void Start () {
		previousTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = Time.time;
		text.text = "FPS: " + (1 / (currentTime - previousTime));
		previousTime = currentTime;
	}
}
