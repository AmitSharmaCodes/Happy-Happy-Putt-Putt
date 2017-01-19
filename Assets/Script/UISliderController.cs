using UnityEngine;
using System.Collections;

public class UISliderController : MonoBehaviour {

	// Use this for initialization
	public BaseButton but;
	public float maxSlide;
	public float minSlide;

	Camera cam;
	Vector3 tabPosition;

	void Start () {
		tabPosition = transform.position;
		cam = FindObjectOfType<Camera>();
		maxSlide -= cam.transform.position.x;
		minSlide -= cam.transform.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(but.isDown())
		{
			//translate max relative to cameras
			maxSlide += cam.transform.position.x;
			minSlide += cam.transform.position.x;

			tabPosition = transform.position;
			tabPosition.x = InputDragTracker.drags.getLastGamePos().x;

			if(tabPosition.x > maxSlide)
				tabPosition.x = maxSlide;
			else if(tabPosition.x < minSlide)
				tabPosition.x = minSlide;

			transform.position = tabPosition;
			//translate back to original
			maxSlide -= cam.transform.position.x;
			minSlide -= cam.transform.position.x;
		}
	}
}
