using UnityEngine;
using System.Collections;

public class CameraLimits : MonoBehaviour {

	// Use this for initialization
	public bool horizontalLock;
	public bool verticalLock;

	public float xMax;
	public float xMin;

	public float yMax;
	public float yMin;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 temp = transform.position;
		if(transform.position.x > xMax){
			temp.x = xMax;
		}
		else if(transform.position.x < xMin){
			temp.x = xMin;
		}

		if(transform.position.y > yMax){
			temp.y = yMax;
		}
		else if(transform.position.y < yMin){
			temp.y = yMin;
		}

		transform.position = temp;
	
	}
}
