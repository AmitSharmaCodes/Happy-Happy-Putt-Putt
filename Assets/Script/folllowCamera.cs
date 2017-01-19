using UnityEngine;
using System.Collections;

public class folllowCamera : MonoBehaviour {

	Vector3 offset;
	Vector3 temp;
	public GameObject cam;
	void Start () {
		offset = transform.position;
		temp = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
		temp.x = cam.transform.position.x;
		temp.y = cam.transform.position.y;
		transform.position = temp + offset;
	}
}
