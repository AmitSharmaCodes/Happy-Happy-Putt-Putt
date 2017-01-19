using UnityEngine;
using System.Collections;

public class Tutorial_1 : MonoBehaviour {


	public Fade[] fades;
	public GameObject good;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Ball")
		{
			foreach(Fade f in fades)
			{
				f.ReverseFade();
			}
			good.SetActive(true);
		}
	}




}
