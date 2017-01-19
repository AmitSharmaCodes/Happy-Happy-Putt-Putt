using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public float xBoundaryMin;
	public float yBoundaryMin;
	public float xBoundaryMax;
	public float yBoundaryMax;
	public float speed;
	public Camera cam;


	Vector3 lerpTo;
	float sizeTo;

	bool lerpy;
	bool sizey;

	float testSpeed;
	void Start () {
		lerpTo = new Vector3();
		lerpy = false;
		sizey = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(lerpy)
		{
			transform.position = Vector3.Lerp(transform.position, lerpTo, testSpeed);
			Vector3 mag = lerpTo - transform.position;
			if(mag.magnitude < Mathf.Epsilon)
				lerpy = false;
		}

		if(sizey)
		{
			cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, sizeTo, Time.deltaTime * speed);
			float dif = Mathf.Abs(sizeTo - cam.orthographicSize);
			if(dif < Mathf.Epsilon)
				sizey = false;

		}
	}

	public void LerpTo(Vector3 le, float sp)
	{
		lerpTo = le;
		testSpeed = sp;
		
		if(lerpTo.x > xBoundaryMax)
				lerpTo.x = xBoundaryMax;
		else if(lerpTo.x < xBoundaryMin)
				lerpTo.x = xBoundaryMin;
		
		if(lerpTo.y > yBoundaryMax)
			lerpTo.y = yBoundaryMax;
		else if(lerpTo.y < yBoundaryMin)
			lerpTo.y = yBoundaryMin;


		lerpy = true;
	}

	public void LerpSize(float s)
	{
		sizeTo = s;
		sizey = true;
	}

	public float Size() {
		return cam.orthographicSize;
	}

}
