using UnityEngine;
using System.Collections;

public class DestroyLives : MonoBehaviour {

	private LivesCount livescount;
	private Lives lives;
		
	// Use this for initialization
	void Start () {
	livescount = GameObject.FindObjectOfType<LivesCount>();
	DestroyObject (livescount);
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
