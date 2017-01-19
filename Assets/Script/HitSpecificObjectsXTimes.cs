using UnityEngine;
using System.Collections;

public class HitSpecificObjectsXTimes : Achievement {
	public Collider2D[] ObjectsToHit;
	public int[] timesToHit;

	int[] timesBeenHit;
	bool[] haveBeenHit;
	// Use this for initialization
	void Start () {
		haveBeenHit = new bool[ObjectsToHit.Length];
		timesBeenHit = new int[ObjectsToHit.Length];

		for(int i = 0; i < ObjectsToHit.Length; i++)
		{
			haveBeenHit[i] = false;
			timesBeenHit[i] = 0;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		for(int i = 0; i < ObjectsToHit.Length; i++)
		{
			if(ObjectsToHit[i] == coll.collider)
			{
				timesBeenHit[i] = timesBeenHit[i] + 1;

				if(timesToHit[i] <= timesBeenHit[i])
				{
					haveBeenHit[i] = true;
					Debug.Log("THAT OBJECT HAS BEEN HIT ENOUGH");
				}
				Debug.Log("YOU HIT ONE OF THE OBJECTS TO HIT!");
			}
		}
	}
	
	
	public override bool isAchieved()
	{
		for(int i = 0; i < ObjectsToHit.Length; i++)
		{
			if(!haveBeenHit[i])
			{
				Debug.Log("NOT ACHIEVED");
				return false;
			}
		}
		Debug.Log("ACHIEVED");
		return true;
	}
	
	public override void desc()
	{
		Debug.Log("Hit Some combination of walls");
	}
}