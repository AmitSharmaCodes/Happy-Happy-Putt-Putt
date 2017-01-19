using UnityEngine;
using System.Collections;

public class PowerGaugeController : MonoBehaviour {
	public ballController b;
	public GUITexture g;
	float maxPull;
	float direction;
	// Use this for initialization
	void Start () {
		maxPull = b.getMaxPull();
	}
	
	// Update is called once per frame
	void Update () {

		float leng = b.PullLength() / maxPull;



		Vector3 temp = g.transform.localScale;
		temp.x = leng;
		g.transform.localScale = temp;
	
	}
}
