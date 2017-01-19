using UnityEngine;
using System.Collections;

public class InputDragTracker : MonoBehaviour {

	// Use this for initialization
	bool drag, wasDrag;
	float minDrag;
	Vector3 previousTouch;
	Vector3 afterTouch;
	Vector3 beginTouch;
	Vector3 lastPosition;
	Vector3 dragDelta;

	float hScreenPixal;
	float wScreenPixal;
	public float speedConstant;


	public Camera cam;

	public static InputDragTracker drags;


	void Awake() {
		
		if(drags == null)
		{
			DontDestroyOnLoad(gameObject);
			drags = this;
		}
		else if(drags != this)
		{
			Destroy(gameObject);
		}
		ResetValues();
	}

	void Start(){
	//	Debug.Log("Input Start Called");
	}
	void ResetValues()
	{
	//	Debug.Log("Drag Reset");
		drag = false;
		wasDrag = false;
		cam = FindObjectOfType<Camera>();
		Debug.Log(cam);
		minDrag = 15f;
		dragDelta = new Vector3();
		previousTouch = new Vector3();
		lastPosition = new Vector3();
		beginTouch = new Vector3();

		hScreenPixal = 1.0f / Screen.height;
		wScreenPixal = 1.0f / Screen.width;
		
		//	Debug.Log("Width: " + Screen.width + " Height: " + Screen.height);

	}
	
	// Update is called once per frame
	void Update () {
		updateDelta();

		if(Input.touchCount > 0)
		{
			if(Input.touches[0].phase == TouchPhase.Ended)
			{
				lastPosition = new Vector3();
				previousTouch = new Vector3();
				beginTouch = new Vector3();
				
				if(drag)
				{
					wasDrag = true;
					//			Debug.Log("DRAG END!");
				}
				drag = false;
			//	afterTouch = cam.ScreenToWorldPoint(Input.touches[0].position);

			//	lastPosition = afterTouch;
			//	updateDelta();
			//	if(drag)
			//	{
			//		wasDrag = true;
				//	Debug.Log("DRAG END!");
			//	}
			//	drag = false;
			}
			else if(Input.touches[0].phase == TouchPhase.Began)
			{
			//	previousTouch = cam.ScreenToWorldPoint(Input.touches[0].position);
			//	lastPosition = previousTouch;
			//	updateDelta();
			//	wasDrag = false;

				lastPosition = Input.touches[0].position;
				previousTouch = lastPosition;
				beginTouch = lastPosition;
				wasDrag = false;
				drag = false;
			}
			else{
			//	afterTouch = cam.ScreenToWorldPoint(Input.touches[0].position);
			//	lastPosition = afterTouch;
			//	updateDelta();
			//	if(!drag)
			//	{
			//		float distance = Vector3.Distance(previousTouch, lastPosition);
				//	Debug.Log ("Distance: " + distance);	
			//		if(distance > minDrag)
			//		{
					//	Debug.Log("DRAG BEGIN");
			//			drag = true;
			//		}
			//	}

				previousTouch = lastPosition;
				lastPosition = Input.touches[0].position;
				
				if(!drag)
				{
					float distance = Vector3.Distance(beginTouch, lastPosition);
					if(distance > minDrag)
					{
				//		Debug.Log("DRAG BEGIN");
						drag = true;
					}
				}
			}
		}
		
		//COMPUTER

		if(Input.GetMouseButtonUp(0))
		{
			lastPosition = new Vector3();
			previousTouch = new Vector3();
			beginTouch = new Vector3();

			if(drag)
			{
				wasDrag = true;
	//			Debug.Log("DRAG END!");
			}
			drag = false;
		}
		else if(Input.GetMouseButtonDown(0))
		{
			//Debug.Log("MOUSE DOWN");
			lastPosition = Input.mousePosition;
			previousTouch = lastPosition;
			beginTouch = lastPosition;
			wasDrag = false;
		}
		else if (Input.GetMouseButton(0))
		{
			previousTouch = lastPosition;
			lastPosition = Input.mousePosition;

			if(!drag)
			{
				float distance = Vector3.Distance(beginTouch, lastPosition);
				if(distance > minDrag)
				{
					Debug.Log("DRAG BEGIN");
					drag = true;
				}
			}
		}
		//computer only end
	}

	private void updateDelta()
	{
		dragDelta.x = (previousTouch.x - lastPosition.x) * wScreenPixal * speedConstant;
		dragDelta.y = (previousTouch.y - lastPosition.y) * hScreenPixal * speedConstant;
		dragDelta.z = 0;


		//dragDelta = cam.ScreenToWorldPoint(dragDelta);

	//	Debug.Log("Delta Drag: " + dragDelta);
	}

	public bool isDrag()
	{
		return drag;
	}
	public Vector3 getLastPos()
	{
		return lastPosition;
	}
	public bool wasDragged()
	{
		if(wasDrag)
		{
	//		Debug.Log("Was Dragged");
		}
		return wasDrag;
	}

	public Vector3 getDeltaPosition()
	{
		return dragDelta;
	}

	public Vector3 getLastGamePos()
	{
		if(cam == null)
			cam = FindObjectOfType<Camera>();
		return cam.ScreenToWorldPoint(lastPosition);
	}
}
