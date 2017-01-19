using UnityEngine;
using System.Collections;

public class HoleController : MonoBehaviour {

	public float additionalDrag;
	public float gravityStrength;
	public float timeToVic;

	public GameObject ball;

	public GameObject GameOverScreen;
	public GameObject MagGlass;

	private float rad;
	private SpriteRenderer rend;
	private float timeToVicCounter;
	private float collisionDistance;

	// Use this for initialization
	void Start () {
	
		CircleCollider2D colli = GetComponent<CircleCollider2D>();
		rend = GetComponent<SpriteRenderer>();
		rad = colli.radius;
		timeToVicCounter = 0.0f;
		collisionDistance = ball.GetComponent<CircleCollider2D>().radius + rad;
	}
	
	// Update is called once per frame
	void Update () {

		if(timeToVicCounter > 0)
		{
			float currentDistance = Vector2.Distance(transform.position, ball.transform.position);
			if(currentDistance > collisionDistance)
			{
				timeToVicCounter = 0;
				Debug.Log("RESET");
			}
		}
	
	}
	//void OnTriggerEnter2D(Collider2D other) {
//		if(!other.isTrigger)
//		{
//			beforeDrag = other.rigidbody2D.drag;
//			other.rigidbody2D.drag = additionalDrag;
//		}
//	}

	void OnTriggerEnter2D(Collider2D other) {
		Colliding(other);
	}

	void OnTriggerStay2D(Collider2D other) {
		Colliding(other);
	}

	void ResetLevel()
	{
		//int level = Application.loadedLevel + 1;
		//if(level >= Application.levelCount)
	//		level = 0;
	//	Application.LoadLevel(level);
		MagGlass.SetActive(false);
		GameOverScreen.SetActive(true);
	}

	void Colliding(Collider2D other)
	{
		if(!other.isTrigger && !gameController.victory)
		{

			Vector2 toCenter = transform.position - other.transform.position;
			float distance = (rad - toCenter.magnitude) * 10;
			toCenter *= (gravityStrength + distance);
			
			other.GetComponent<Rigidbody2D>().AddForce(toCenter);
			
			float remove = 1.0f - additionalDrag * Time.deltaTime * 60;
		//	Debug.Log ("Remove " + remove);
			other.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity * remove;
			timeToVicCounter += Time.deltaTime;
			Debug.Log ("Time " + timeToVicCounter);

			Debug.Log("HOLE COLLISION, ADD FORCE");
			
			if((/*other.rigidbody2D.velocity.magnitude < gameController.victoryThres  ||*/ timeToVicCounter > timeToVic) && !gameController.victory && !gameController.isBusy)
			{
				//Debug.Log(gameController.victoryColor.ToString());
				gameController.victory = true;
				rend.color = gameController.victoryColor;
				ball.GetComponent<SpriteRenderer>().color = gameController.victoryColor;
				ball.GetComponent<Fade>().enabled = true;
				gameObject.GetComponent<Fade>().enabled = true;

				
				ResetLevel();
			}
		}
	}

}
