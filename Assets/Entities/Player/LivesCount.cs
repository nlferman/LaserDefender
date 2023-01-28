using UnityEngine;
using System.Collections;

public class LivesCount : MonoBehaviour {

//A code to handle the number of lives independently.  Initializes on "Start" Level.
//To test individual levels with lives, add this as a script component to Scene's Level Manager.
//Do not forget to remove it as a component.  Lives will reset on each level otherwise.


	private LevelManager levelManager;  //Access LevelManager.cs
	public static int lives; //Creates a public integer for lives.

	// Use this for initialization
	void Start () {
		lives = 3;  //Sets the lives count to 3 regardless of inspector.
		//GameObject.DontDestroyOnLoad(gameObject); //Retains lives count through each level.
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getLives(){
		return lives;
	}

	public void incLives(){
		lives++;
	}

	public void decLives(){
		lives--;
	}
}
