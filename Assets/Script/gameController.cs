using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

	public static int stroke;
	public static bool victory;
	public static bool beginTurn;
	public	static float victoryThres;
	public static Color victoryColor;
	public static bool isZoomed;

	public static bool isBusy;

	public Color victoryC;
	public float victoryT;
	// Use this for initialization
	void Start () {
	
		stroke = 0	;
		victory = false;
		victoryColor = victoryC;
		victoryColor.a = 1;
		victoryThres = victoryT;
		beginTurn = true;
		isZoomed = false;
		isBusy = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
	