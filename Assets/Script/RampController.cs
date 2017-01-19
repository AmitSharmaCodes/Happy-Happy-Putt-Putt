using UnityEngine;
using System.Collections;

public class RampController : MonoBehaviour {

	// Use this for initialization
	public float force;
	Vector2 push;
	void Start () {
		push = new Vector2(Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad));
		Debug.Log(push);	
	}
	
	// Update is called once per frame
	void Update () {
		push = new Vector2(Mathf.Cos((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad), Mathf.Sin((transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad));
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Ball")
		{
			other.GetComponent<Rigidbody2D>().AddForce(push * force);
		}
	}
}
