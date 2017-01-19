using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public float fadeSpeed;
	public bool fadeUp;
	public bool fadeDown;

	// Use this for initialization
	enum Fades {Sprites, Texts};

	Color c;
	float time;
	float topAlpha;
	bool fading;


	Fades type;
	TextMesh tm;
	SpriteRenderer sr;



	void Start () {
		if(fadeUp && fadeDown)
		{
			fadeUp = false;
			fadeDown = false;
		}

		tm = GetComponent<TextMesh>();
		sr = GetComponent<SpriteRenderer>();

		if(tm != null) {
			type = Fades.Texts;
			c = tm.color;
		}
		else if(sr != null) {
			type = Fades.Sprites;
			c = sr.color;
		}

		if(fadeUp)
		{
			topAlpha = c.a;
			c.a = 0;
			time = 0;
			fading = true;
		}
		else if(fadeDown)
		{
			time = 0;
			fading = true;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if(fadeDown)
		{
			FadeDown();
		}
		else if(fadeUp)
		{
			FadeUp();
		}
	
	}

	void FadeDown()
	{
		if(fading)
		{
			time += Time.deltaTime;
			c.a -= time * .01f;
			if(c.a < 0)
			{
				c.a = 0;
				fading = false;
			}
			changeColor(c);
		}
	}

	void FadeUp()
	{
		if(fading)
		{
			time += Time.deltaTime;
			c.a += time * .01f;
			if(c.a > topAlpha)
			{
				c.a = topAlpha;
				fading = false;
			}
			changeColor(c);
		}
	}

	public void ReverseFade()
	{
		fading = true;
		if(fadeDown){
			fadeDown = false;
			fadeUp = true;
		}
		else
		{
			fadeUp = false;
			fadeDown = true;
		}
	}

	public bool DoneFading()
	{
		if(fading)
			return false;
		return true;
	}

	void changeColor(Color c)
	{
		switch(type)
		{
		case Fades.Sprites:
			sr.color = c;
			break;
		case Fades.Texts:
			tm.color = c;	
			break;
		}
	}

	public float getColorAlpha()
	{
		return c.a;
	}
}
