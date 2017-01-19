using UnityEngine;
using System.Collections;

public class GameOverParController : MonoBehaviour {

	// Use this for initialization
	public TextMesh current;
	public GUIText copy;
	void Start () {
	
		current.text = copy.text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
