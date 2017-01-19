using UnityEngine;
using System.Collections;

public class Button : BaseButton {

	// Use this for initialization
	public Collider2D coll;
	Camera cam;
	bool pushed;
	bool down;
	
	void Start () {

		pushed = false;
		cam = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {	
		pushed = false;
		down = false;

		if(Input.touchCount > 0)
		{
			Vector3 touch = cam.ScreenToWorldPoint(Input.touches[0].position);
			if(coll.OverlapPoint(new Vector2(touch.x, touch.y)))
			{
				down = true;	
				if(Input.touches[0].phase == TouchPhase.Ended)
						pushed = true;
			}
			

		}

		//COMPUTER

		if(Input.GetMouseButtonUp(0))
		{
			Vector3 touchPoint = cam.ScreenToWorldPoint(Input.mousePosition);
				if(coll.OverlapPoint(new Vector2(touchPoint.x, touchPoint.y)))
					pushed = true;
		}
		if(Input.GetMouseButton(0))
		{
			Vector3 touchPoint = cam.ScreenToWorldPoint(Input.mousePosition);
			if(coll.OverlapPoint(new Vector2(touchPoint.x, touchPoint.y)))
				down = true;
		}
		//Computer Only End
	}

	public override bool isPushed()
	{
		return pushed;
	}

	public override bool isDown()
	{
		return down;
	}

}
