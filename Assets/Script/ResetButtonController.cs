using UnityEngine;
using System.Collections;

public class ResetButtonController : MonoBehaviour {

	// Use this for initialization
	public BaseButton but;
	public bool dragMatters;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(but.isPushed())
		{
			if((dragMatters && !InputDragTracker.drags.wasDragged()) || !dragMatters){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
