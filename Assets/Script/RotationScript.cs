using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

	// Use this for initialization
	public bool ClockwiseRotation;
	public float rotationSpeed;
	
	Vector3 spinVector;

	void Start () {
		spinVector = new Vector3(0,0,rotationSpeed);

	}
	
	// Update is called once per frame
	void Update () {
		if(ClockwiseRotation)
			spinVector.z = -rotationSpeed * Time.deltaTime * 60;
		else
		spinVector.z = rotationSpeed * Time.deltaTime * 60;

		transform.Rotate(spinVector);
	
	}
}
