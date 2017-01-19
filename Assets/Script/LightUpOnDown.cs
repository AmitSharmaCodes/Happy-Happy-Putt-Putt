using UnityEngine;
using System.Collections;

public class LightUpOnDown : MonoBehaviour {

	// Use this for initialization
	public Color lightColor;
	public Color defaultColor;
	public SpriteRenderer[] ObjectsToColor;
	public GUITexture[] GuiToColor;
	public TextMesh[] TextToColor;
	public BaseButton but;
	public bool dragMatters;

	void Start () {
		//Debug.Log(dragMatters);
	}
	
	// Update is called once per frame
	void Update () {
		if(but.isDown()){
			if((dragMatters && (!InputDragTracker.drags.isDrag()) && !InputDragTracker.drags.wasDragged()) || !dragMatters){
				for(int i = 0; i < ObjectsToColor.Length; i++)
					ObjectsToColor[i].color = lightColor;

				for(int i = 0; i < GuiToColor.Length; i++)
					GuiToColor[i].color = lightColor;

				for(int i = 0; i < TextToColor.Length; i++)
					TextToColor[i].color = lightColor;
			}
			else {
				for(int i = 0; i < ObjectsToColor.Length; i++)
					ObjectsToColor[i].color = defaultColor;
				
				for(int i = 0; i < GuiToColor.Length; i++)
					GuiToColor[i].color = defaultColor;

				for(int i = 0; i < TextToColor.Length; i++)
					TextToColor[i].color = defaultColor;
			}
		}
		else {
			for(int i = 0; i < ObjectsToColor.Length; i++)
				ObjectsToColor[i].color = defaultColor;
			
			for(int i = 0; i < GuiToColor.Length; i++)
				GuiToColor[i].color = defaultColor;

			for(int i = 0; i < TextToColor.Length; i++)
				TextToColor[i].color = defaultColor;
		}
	}
}
