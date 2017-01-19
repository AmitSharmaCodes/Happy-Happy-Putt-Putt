using UnityEngine;
using System.Collections;

public class ReturnSettingsController : MonoBehaviour {

	// Use this for initialization
	public BaseButton but;
	public GameObject Overlay;
	public GameObject magGlass;
	public ballController ball;
	public bool dragMatters;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(but.isPushed())
		{
			if((dragMatters && !InputDragTracker.drags.wasDragged()) || !dragMatters){
				Overlay.SetActive(false);
				ball.enabled = true;
				magGlass.SetActive(true);
				gameController.isBusy = false;

			}
		}
	}
}
