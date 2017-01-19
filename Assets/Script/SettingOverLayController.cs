using UnityEngine;
using System.Collections;

public class SettingOverLayController : MonoBehaviour {

	// Use this for initialization
	public GameObject popUp;
	public ballController ball;
	public GameObject magGlass;
	bool justClicked;
	void Start () {
		justClicked = true;


	}
	
	// Update is called once per frame
	void Update () {
		if(justClicked){
			gameController.isBusy = true;
			popUp.SetActive(false);
			justClicked = false;
		}
	}
	public void DisablePopUp()
	{
		justClicked = true;
		ball.enabled = false;
		magGlass.SetActive(false);
	}
}
