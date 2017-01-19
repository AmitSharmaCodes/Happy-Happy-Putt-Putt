using UnityEngine;
using System.Collections;

public class arrowController : MonoBehaviour {
	public GameObject follow;
	public float speed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per framee
	void Update () {
		transform.RotateAround(follow.transform.position, Vector3.forward,Time.deltaTime * speed);
	}


}
