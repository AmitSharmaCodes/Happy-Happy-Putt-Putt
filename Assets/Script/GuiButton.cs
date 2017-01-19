using UnityEngine;
using System.Collections;

public class GuiButton : BaseButton {

	public GUIElement text;
	bool down;
	bool pushed;
	void Start () {
		down = false;
		pushed = false;
	}
	
	// Update is called once per frame
	void Update () {
		pushed = false;
		down = false;

		if(Input.touchCount > 0)
		{
			if(text.HitTest(Input.touches[0].position))
			{
				down = true;
				if(Input.touches[0].phase == TouchPhase.Ended)
					pushed = true;
			}
		}

		if(Input.GetMouseButton(0))
		{
			if(text.HitTest(Input.mousePosition))
				down = true;
		}

		if(Input.GetMouseButtonUp(0)){
			if(text.HitTest(Input.mousePosition))
				pushed = true;
		}


	}

	public override bool isPushed()
	{
	//	if(pushed)
	//		Debug.Log("GUI BUTTON PUSHED");
		return pushed;
	}
	
	public override bool isDown()
	{
	//	if(down)
	//		Debug.Log("GUI BUTTON DOWN");
		return down;
	}
}
