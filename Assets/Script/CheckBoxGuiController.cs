using UnityEngine;
using System.Collections;

public class CheckBoxGuiController : MonoBehaviour {

	// Use this for initialization
	public Sprite CheckOn;
	public Sprite CheckOff;
	public BaseButton but;
	public bool dragMatters;

	bool state;

	void Start () {
		state = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(but.isPushed())
		{
			if((dragMatters && !InputDragTracker.drags.wasDragged()) || !dragMatters){
				Debug.Log("VIBRATION HIT");
				state = !state;
				if(state)
					gameObject.GetComponent<SpriteRenderer>().sprite = CheckOn;
				else
					gameObject.GetComponent<SpriteRenderer>().sprite = CheckOff;
			}
		}
	}

}
