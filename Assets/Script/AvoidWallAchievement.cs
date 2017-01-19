using UnityEngine;
using System.Collections;

public class AvoidWallAchievement : Achievement{

	// Use this for initialization
	GameObject[] exList;
	bool hitSomething;

	void Start () {
		hitSomething = false;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log("Hit Something: " + hitSomething);
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		hitSomething = true;
		Debug.Log("YOU HIT A WALL!");
	}

	public override bool isAchieved()
	{

		if(!hitSomething && gameController.victory)
		{
			Debug.Log("ACHIEVED");
			return true;
		}
		Debug.Log("NOT ACHIEVED");
		return false;
	}

	public override void desc()
	{
		Debug.Log("DONT HIT ANY WALLS GODDAMNIT");
	}


}
