using UnityEngine;
using System.Collections;

public class HitXWallsAchievement : Achievement {

	// Use this for initialization
	public float numOfWalls;
	int hitCount;
	void Start () {
		hitCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		hitCount++;
		Debug.Log("YOU HIT A WALL!");
	}


	public override bool isAchieved()
	{
		
		if(hitCount >= numOfWalls)
		{
			Debug.Log("ACHIEVED");
			return true;
		}
		Debug.Log("NOT ACHIEVED");
		return false;
	}
	
	public override void desc()
	{
		Debug.Log("Hit " + numOfWalls + " Walls!");
	}

}
