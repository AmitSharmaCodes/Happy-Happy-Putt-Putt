using UnityEngine;
using System.Collections;

public class PhysicsCameraScript : MonoBehaviour {

	// Use this for initialization
	public Rigidbody2D rigidBody;
	public bool lockHorizontal;
	public bool lockVertical;

	public float veloScale;

	public float xMax;
	public float xMin;
	
	public float yMax;
	public float yMin;



	Vector3 lastMousePosition;
	Vector2 dragDelta;
	Vector2 newVelo;
	bool firstTime; 

	float dragTime;


	void Start () {
		firstTime = true;
		dragTime = 0;
		dragDelta = new Vector2();
	}
	// Update is called once per frame
	void Update () {
		WithinBounds();
		if(InputDragTracker.drags.isDrag())
		{
			dragTime += Time.deltaTime;
			Vector3 temp = transform.position;
			if(lockHorizontal){
				temp.y += InputDragTracker.drags.getDeltaPosition().y;
				dragDelta.y += InputDragTracker.drags.getDeltaPosition().y;

			}
			else if(lockVertical){
				temp.x += InputDragTracker.drags.getDeltaPosition().x;
				dragDelta.x += InputDragTracker.drags.getDeltaPosition().x;
			}
			else
			{
				temp.x += InputDragTracker.drags.getDeltaPosition().x;
				temp.y += InputDragTracker.drags.getDeltaPosition().y;

				dragDelta.x += InputDragTracker.drags.getDeltaPosition().x;
				dragDelta.y += InputDragTracker.drags.getDeltaPosition().y;
			}
			transform.position = temp;
			firstTime = true;

		}
		if(InputDragTracker.drags.wasDragged() && firstTime)
		{
			firstTime = false;
		//	Vector2 temp = new Vector2();
		//	if(lockHorizontal)
		//		temp.y += InputDragTracker.drags.getDeltaPosition().y;
		//	else if(lockVertical)
		//		temp.x += InputDragTracker.drags.getDeltaPosition().x;
		//	else
		//	{
		//		temp.x += InputDragTracker.drags.getDeltaPosition().x;
		//		temp.y += InputDragTracker.drags.getDeltaPosition().y;
		//	}

			GetComponent<Rigidbody2D>().velocity +=	(dragDelta / dragTime);
			dragTime = 0;
			dragDelta = new Vector2();
		}


	}

	private void WithinBounds()
	{
		
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
