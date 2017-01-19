using UnityEngine;
using System.Collections;

public class DisappearOnDown : MonoBehaviour {

	// Use this for initialization
	public BaseButton but;
	public bool dragMatters;

	void Start () {
		Debug.Log ("drag Matters" + dragMatters);
	
	}
	
	// Update is called once per frame
	void Update () {
		if(but.isPushed()){
			if((dragMatters && !InputDragTracker.drags.wasDragged()) || (!dragMatters)){
				gameObject.SetActive(false);
			}
		}
	}
}
