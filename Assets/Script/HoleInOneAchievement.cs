using UnityEngine;
using System.Collections;

public class HoleInOneAchievement : Achievement {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public override bool isAchieved()
	{
		if(gameController.stroke == 1)
			return true;
		Debug.Log("NOT ACHIEVED");
		return false;
	}
	
	public override void desc()
	{
		Debug.Log("Get A Hole-In-One");
	}
}
