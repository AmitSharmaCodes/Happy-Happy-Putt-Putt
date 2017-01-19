using UnityEngine;
using System.Collections;

public class TransitionTutorial : MonoBehaviour {

	// Use this for initialization
	public Fade good;
	bool reversed;
	float timer = 0;
	void Start () {
		reversed = false;
	}
	
	// Update is called once per frame
	void Update () {


		if(good.DoneFading() && !reversed)
		{
			timer += Time.deltaTime;
			if(timer > 1)
				reverseTheFade();
		}
		else if(good.DoneFading() && reversed)
		{
			Debug.Log("Next Level");
			int level = Application.loadedLevel + 1;
			Application.LoadLevel(level);
		}
	}

	void reverseTheFade()
	{
		good.ReverseFade();
		reversed = true;
	}
}
