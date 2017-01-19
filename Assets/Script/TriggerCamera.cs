using UnityEngine;
using System.Collections;

public class TriggerCamera : MonoBehaviour {

	// Use this for initialization
	//public GameObject cam;
	//Vector3 temp;
	Vector3 to;
	public CameraController cam;
	void Start () {
		to = cam.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	//	if(!gameController.isZoomed)
	//		cam.transform.position = Vector3.Lerp(cam.transform.position, to, Time.deltaTime * 3);

	//	temp.x = transform.position.x;
	//	temp.y = transform.position.y;
	//	cam.transform.position = temp; 
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "CamTrigger" && !gameController.isZoomed)
		{
			to.x = other.transform.position.x;
			to.y = other.transform.position.y;
			cam.LerpTo(to,Time.deltaTime * 3);

		}	
	}
}
