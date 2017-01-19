using UnityEngine;
using System.Collections;

public class AvoidSpecificObjectAchievement : Achievement {
	public Collider2D[] ObjectsToAvoid;

	bool[] hasBeenHit;

	// Use this for initialization
	void Start () {
		hasBeenHit = new bool[ObjectsToAvoid.Length];
		for(int i = 0; i < hasBeenHit.Length; i++)
			hasBeenHit[i] = false;
	
	}
	

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		for(int i = 0; i < ObjectsToAvoid.Length; i++)
		{
			if(ObjectsToAvoid[i] == coll.collider)
			{
				hasBeenHit[i] = true;
				Debug.Log("YOU HIT ONE OF THE OBJECTS TO HIT!");
			}
		}
	}

	
	public override bool isAchieved()
	{

		for(int i = 0; i < hasBeenHit.Length; i++)
			if(hasBeenHit[i])
				return false;
		return true;
	}
	
	public override void desc()
	{
		Debug.Log("Don't hit Certain Object ");
	}
}
