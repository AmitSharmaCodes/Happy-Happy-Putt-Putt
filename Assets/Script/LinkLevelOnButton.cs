using UnityEngine;
using System.Collections;

public class LinkLevelOnButton : MonoBehaviour {

	public BaseButton but;
	public int linkToLevelNumber;
	public bool unlocked;
	public bool dragMatters;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(but.isPushed())
		{
			if((dragMatters && !InputDragTracker.drags.wasDragged()) || !dragMatters){
				if(unlocked)
					Application.LoadLevel(linkToLevelNumber);
			}
		}
	}
}
