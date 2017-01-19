using UnityEngine;
using System.Collections;

public class NoStickBounce : MonoBehaviour {

	// Use this for initialization
	Vector3 pos3D;
	Vector2 pos2D;
	Vector2 lastPos;
	Vector2 velo;

	void Start () {
		pos3D = new Vector3();
		pos2D = new Vector2();
		lastPos = new Vector2();
		velo = new Vector2();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		pos3D = transform.position;
		pos2D = new Vector2(pos3D.x, pos3D.y);
		velo = pos2D - lastPos;
		lastPos = pos2D;

	}

	void OnCollisionEnter2D(Collision2D coll) {

		float vSpeed = (velo  * 500).magnitude;
		float difference = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.magnitude - vSpeed);
		if(difference < 1)
		{		
			Vector3 N = coll.contacts[0].normal;
			Vector3 V = velo.normalized;
			Vector3 R = Vector3.Reflect(V, N).normalized;
			
			GetComponent<Rigidbody2D>().velocity = new Vector2(R.x, R.y) * vSpeed;
		}
	}
}
