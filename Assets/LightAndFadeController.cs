using UnityEngine;
using System.Collections;

public class LightAndFadeController : MonoBehaviour {

	// Use this for initialization
	public Fade fade;
	public LightUpOnDown light;
	void Start () {
		light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(fade.DoneFading())
			light.enabled = true;
	}
}
