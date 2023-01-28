using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

	private LevelManager levelManager;
	private LivesCount livescount;
	private PlayerController playercontroller;
	public bool noLives = false;
	
	
	public Text text;
	
	// Use this for initialization
	void Start () {
		livescount = GameObject.FindObjectOfType<LivesCount>();
		text.text = ("Lives: " + livescount.getLives ());
	}
		
		
	public void minusLives () {
		livescount = GameObject.FindObjectOfType<LivesCount>();
		livescount.decLives ();
		print (livescount.getLives ());
		if (livescount.getLives () <=0){
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel("Lose");
			noLives = true;
		} else {
		//playercontroller = GameObject.FindObjectOfType<PlayerController>();
			text.text = ("Lives: " + livescount.getLives ());
		//playercontroller.transform.position = new Vector3 (0, -4.5f, 0);
		}
	}
}
