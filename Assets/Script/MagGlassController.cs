using UnityEngine;
using System.Collections;

public class MagGlassController : MonoBehaviour {

	public BaseButton gBut;
	public CameraController cam;
	public GameObject ball;
	public GameObject popUp;
	public float speed;
	public float camSpeed;
	public float camZoomOut;
	public bool dragMatters;
	
	bool act;
	float originalSize;


	void Start () {
		act = false;
		originalSize = cam.Size();
	}
	// Update is called once per frame
	void Update () {
		if(gBut.isPushed())
		{
			if((dragMatters && !InputDragTracker.drags.wasDragged()) || !dragMatters){
				Debug.Log("PUSHED");
				act = !act;
			
				if(act)
				{
					gameController.isBusy = true;
					popUp.SetActive(true);
					gameController.isZoomed = true;
					cam.LerpSize(camZoomOut);
				}
				else
				{
					gameController.isBusy = false;
					popUp.SetActive(false);
					Vector3 temp = cam.transform.position;
					temp.x = ball.transform.position.x;
					temp.y = ball.transform.position.y;

					//Debug.Log ("In effect");
					gameController.isZoomed = false;
					cam.LerpTo(temp, Time.deltaTime * speed);
					cam.LerpSize(originalSize);
				}
			}
		} 
		/*
		if(act)
		{
			if(Input.GetMouseButtonDown(0))
			{
				from = Input.mousePosition;
				to = Input.mousePosition;
				down = true;

			}
			if(Input.GetMouseButton(0) && down)
			{
				from = to;
				to = Input.mousePosition;
				difference = from - to;
				difference.x /= Screen.width;
				difference.y /= Screen.height;
				Vector3 temp = cam.transform.position;
				temp.x += difference.x * camSpeed;
				temp.y += difference.y * camSpeed;
				//cam.transform.position = temp;
				cam.LerpTo(temp, 1);

			}
			if(Input.GetMouseButtonUp(0))
			{

				down = false;
			}*/

			//cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 6.4f, Time.deltaTime * speed);

		//}
		//else
		//{
			//cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, originalSize, Time.deltaTime * speed);
			
	//	}
	}

	public void LerpToOriginalSize()
	{
	//	popUp.SetActive(false);
		act = false;
		Vector3 temp = cam.transform.position;
		temp.x = ball.transform.position.x;
		temp.y = ball.transform.position.y;
			
//			Debug.Log ("In effect");
		gameController.isZoomed = false;
		cam.LerpTo(temp, Time.deltaTime * speed);
		cam.LerpSize(originalSize);
	}
}	
