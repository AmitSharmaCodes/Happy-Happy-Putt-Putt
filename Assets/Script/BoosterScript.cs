using UnityEngine;
using System.Collections;

public class BoosterScript : MonoBehaviour {

	// Use this for initialization
	public float boost;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Ball"){
			Vector2 N = coll.contacts[0].normal;
			N.Normalize();
			N.Scale(new Vector2(-boost, -boost));

			coll.rigidbody.AddForce(N);
		}
	}
}
