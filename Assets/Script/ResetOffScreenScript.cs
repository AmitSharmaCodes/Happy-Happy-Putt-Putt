using UnityEngine;
using System.Collections;

public class ResetOffScreenScript : MonoBehaviour {

	// Use this for initialization
	Vector3 pos; 
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible() {
		transform.position = pos;
		GetComponent<Rigidbody2D>().velocity = new Vector2();
	}
}
