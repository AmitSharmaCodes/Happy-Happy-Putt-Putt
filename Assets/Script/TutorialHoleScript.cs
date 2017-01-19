using UnityEngine;
using System.Collections;

public class TutorialHoleScript : MonoBehaviour {
	public float additionalDrag;
	public float gravityStrength;
	
	public GameObject ball;
	
	private float beforeDrag;
	private float rad;
	private SpriteRenderer rend;
	public Fade[] fade;
	// Use this for initialization
	void Start () {

		CircleCollider2D colli = GetComponent<CircleCollider2D>();
		rend = GetComponent<SpriteRenderer>();
		rad = colli.radius;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.victory && fade[0].getColorAlpha() <= 0)
		{
			ResetLevel();
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(!other.isTrigger)
		{
			beforeDrag = other.GetComponent<Rigidbody2D>().drag;
			other.GetComponent<Rigidbody2D>().drag = additionalDrag;
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		if(!other.isTrigger)
		{
			Vector2 toCenter = transform.position - other.transform.position;
			float distance = (rad - toCenter.magnitude) * 10;
			toCenter *= (gravityStrength + distance);
			
			other.GetComponent<Rigidbody2D>().AddForce(toCenter);
			
			if(other.GetComponent<Rigidbody2D>().velocity.magnitude < gameController.victoryThres && !gameController.victory)
			{
				//Debug.Log(gameController.victoryColor.ToString());
				gameController.victory = true;
				rend.color = gameController.victoryColor;
				ball.GetComponent<SpriteRenderer>().color = gameController.victoryColor;

				foreach(Fade f in fade)
					f.ReverseFade();
			}
		}
		
	}
	
	void ResetLevel()
	{
		int level = Application.loadedLevel + 1;
		if(level >= Application.levelCount)
			level = 0;
		Application.LoadLevel(level);
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(!other.isTrigger)
		{
			other.GetComponent<Rigidbody2D>().drag = beforeDrag;
		}
	}
}