using UnityEngine;
using System.Collections;

public class SettingsButtonController : MonoBehaviour {
	public BaseButton but;
	public GameObject SettingsOverlay;
	public GameObject popUp;
	public MagGlassController mag;
	public bool dragMatters;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(but.isPushed())
		{
			if((dragMatters && !InputDragTracker.drags.wasDragged()) || !dragMatters){
				Debug.Log("Settings Pushed");
				mag.LerpToOriginalSize();
				SettingsOverlay.GetComponent<SettingOverLayController>().DisablePopUp();
				SettingsOverlay.SetActive(!SettingsOverlay.activeSelf);
			}
		}
	}
}
