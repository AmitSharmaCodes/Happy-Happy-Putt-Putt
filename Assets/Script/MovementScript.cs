using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] path;
	public float movementSpeed;
	public float delay;
	public bool loop;
	public bool linearMovement;

	int currentNode;
	float epsilonDistance, currentTime, linearTimeCounter, distanceConstant;
	bool delayOver;
	Vector3 startPosition;


	void Start () {
		currentTime = 0;
		currentNode = 0;
		linearTimeCounter = 0;
		delayOver =false;
		epsilonDistance = 0.01f;
		//startPosition = path[0].transform.position;
		startPosition = transform.position;
		UpdateDistance();
	}
	
	// Update is called once per frame
	void Update () {

		if(!delayOver)
		{
			currentTime += Time.deltaTime;
			if(currentTime > delay)
				delayOver = true;
		}
		else
		{
			if(linearMovement){
				Vector3 temp = Vector3.Lerp(startPosition, path[currentNode].transform.position, linearTimeCounter * movementSpeed * distanceConstant * 5);
				if(!float.IsNaN(temp.x))
					transform.position = temp;
				linearTimeCounter += Time.deltaTime;
			}
			else {
			transform.position = Vector3.Lerp(transform.position, path[currentNode].transform.position, movementSpeed);
			}
			if(Vector3.Distance(transform.position, path[currentNode].transform.position) < epsilonDistance)
			{
				linearTimeCounter = 0;
				startPosition = path[currentNode].transform.position;
				currentNode++;

				if(currentNode == path.Length)
				{	
					if(loop)
						currentNode = 0;
					else
					{
						currentNode = 1;
						transform.position = path[0].transform.position;
					}
				}
				UpdateDistance();
				Debug.Log("CHANGE");
			}

		}

	}

	void UpdateDistance()
	{
		distanceConstant = Vector3.Distance(startPosition, path[currentNode].transform.position);
		distanceConstant = 1/distanceConstant;
	}
}
