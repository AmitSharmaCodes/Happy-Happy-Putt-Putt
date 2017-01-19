using UnityEngine;
using System.Collections;

public class ballController : MonoBehaviour {
	
	private Vector3 direction, beginning, ending;
	private bool fire;
	private float beforeMag;
	private float arrowLength;

	public float speed;
	public float forceConstant;
	public Vector3 maxDrag;
	public float maxSpeed;
	public GameObject arrow;
	public Camera cam;
	public Collider2D dragCollider;

	public float maxPull;

	Vector3 startingPos;
	Vector3 a;

	void Start () {
		direction = new Vector3();
		beginning = new Vector3();
		ending = new Vector3();

		fire = false;
		arrow.SetActive(false);
		arrowLength = arrow.transform.localPosition.y * transform.localScale.y;
		startingPos = transform.position;

		}

	// Update is called once per frame
	void Update () {
		if(!gameController.isZoomed)
		{
			// if there is a touch, active on first touch, and shot on end touch
			if(Input.touchCount > 0)
			{
				if(Input.touches[0].phase == TouchPhase.Began){
					Vector3 wTouch = cam.ScreenToWorldPoint(Input.touches[0].position);
					Vector2 com = new Vector2(wTouch.x, wTouch.y);
					if(dragCollider.OverlapPoint(com))
						arrow.SetActive(true);
				}
				else if(Input.touches[0].phase == TouchPhase.Ended && arrow.activeSelf){
						fire = true;
				        arrow.SetActive(false);
				}

			

				if(arrow.activeSelf)
				{
					ending = Input.touches[0].position;
					ending = cam.ScreenToWorldPoint(ending);
					ending.z = 0;
					beginning = transform.position;
					beginning.z = 0;
					direction = beginning - ending;
					if(direction.sqrMagnitude > maxPull * maxPull)
					{
						Vector3 n = direction.normalized;
						direction = Vector2.Scale(n, new Vector3(maxPull, maxPull, 0));
						Debug.Log(direction.magnitude);

					}
					a = direction.normalized;
				//	Vector3.Scale(a, new Vector3(arrowDistance, arrowDistance, arrowDistance));
					arrow.transform.position = transform.position + (a * arrowLength);
				}
			}




			//computer

			if(Input.GetMouseButtonDown(0))
			{
				Vector3 wTouch = cam.ScreenToWorldPoint(Input.mousePosition);
				Vector2 com = new Vector2(wTouch.x, wTouch.y);
				if(dragCollider.OverlapPoint(com))
					arrow.SetActive(true);
			}
			else if(Input.GetMouseButtonUp(0) && arrow.activeSelf)
			{
				fire = true;
				arrow.SetActive(false);
			}

			
			if(arrow.activeSelf)
			{
				ending = Input.mousePosition;
				ending = cam.ScreenToWorldPoint(ending);
				ending.z = 0;
				beginning = transform.position;
				beginning.z = 0;
				direction = beginning - ending;
				if(direction.sqrMagnitude > maxPull * maxPull)
				{
					Vector3 n = direction.normalized;
					direction = Vector2.Scale(n, new Vector3(maxPull, maxPull, 0));
					Debug.Log(direction.magnitude);
					
				}
				a = direction.normalized;
				//	Vector3.Scale(a, new Vector3(arrowDistance, arrowDistance, arrowDistance));
				arrow.transform.position = transform.position + (a * arrowLength);
			}

			//computer only end


		}

	}

	void FixedUpdate(){
		if(!gameController.isZoomed)
		{
			if(fire && !gameController.victory)
			{
				GetComponent<Rigidbody2D>().AddForce(direction * speed);
				gameController.stroke++;
				fire = false;
				direction = new Vector3();
				arrow.SetActive(false);
			}
			if(GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
			{
				Vector2 n = GetComponent<Rigidbody2D>().velocity.normalized;
				GetComponent<Rigidbody2D>().velocity = Vector2.Scale(n, new Vector2(maxSpeed, maxSpeed));
			}
		}

	}
	
//	void OnMouseDown(){
//		Debug.Log("CLICK");
//		if(!gameController.isZoomed)
//		{
//			Debug.Log("CLICK");
//			arrow.SetActive(true);
//		}
//	}
//	
//	void OnMouseUp() {
//		if(!gameController.isZoomed)
//		{
//			fire = true;
//			arrow.SetActive(false);
//		}
//	}

	public Vector3 getStartingPosition()
	{
		return startingPos;
	}
	public float PullLength()
	{
		return direction.sqrMagnitude;
	}

	public float getMaxPull()
	{
		return maxPull * maxPull;
	}

	public void cancelShot()
	{
		fire = false;
		arrow.SetActive(false);
	}


}
