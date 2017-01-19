using UnityEngine;
using System.Collections;

public class WaterController : MonoBehaviour {

	// Use this for initialization
//	GameObject ball;

	public float waterDrag;
	public float resetSpeed;

	void Start () {
	//	ballPos = ball.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Ball")
		{
			other.gameObject.GetComponent<ballController>().cancelShot();
			//other.gameObject.GetComponent<ballController>().enabled = false;
			Debug.Log("DISABLE BALL CONTROL");
		}
		Collide(other);
	}

	void OnTriggerStay2D(Collider2D other){
		Collide(other);
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "Ball")
		{
			other.gameObject.GetComponent<ballController>().cancelShot();
			other.gameObject.GetComponent<ballController>().enabled = true;
			Debug.Log("Enable BALL CONTROL");
		}
	}

	private void Collide(Collider2D other)
	{
		if(other.tag == "Ball")
		{
			if(other.GetComponent<Rigidbody2D>().velocity.magnitude < resetSpeed)
			{
				other.transform.position = other.GetComponent<ballController>().getStartingPosition();
				other.gameObject.GetComponent<ballController>().enabled = true;
				other.GetComponent<Rigidbody2D>().velocity = new Vector2();
			//	other.gameObject.GetComponent<ballController>().enabled = true;
			//	Debug.Log("Enable BALL CONTROL");
			}

			float remove = 1.0f - waterDrag * Time.deltaTime * 60;
			other.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity * remove;
		}
	}
}
