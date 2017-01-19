using UnityEngine;
using System.Collections;

public class HitXDifferentWalls : Achievement {

	// Use this for initialization\
	public int numOfWallsToHit;
	public Collider2D[] WallOptions;

	bool[] hasBeenHit;

	void Start () {
		hasBeenHit = new bool[WallOptions.Length];
		for(int i = 0; i < hasBeenHit.Length; i++)
			hasBeenHit[i] = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		for(int i = 0; i < WallOptions.Length; i++)
		{
			if(WallOptions[i] == coll.collider)
			{
				hasBeenHit[i] = true;
				break;
			}
		}

		Debug.Log("YOU HIT A WALL!");
	}

	public override bool isAchieved()
	{
		int count = 0;

		for(int i = 0; i < hasBeenHit.Length; i++)
			if(hasBeenHit[i])
				count++;

		if(count >= numOfWallsToHit){
			Debug.Log("ACHIEVED");
			return true;
		}
		Debug.Log("NOT ACHIEVED");
		return false;
	}
	
	public override void desc()
	{
		Debug.Log("Hit X Different Walls");
	}

}
