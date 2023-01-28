using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

public Text text;
public static int score = 0;

private int nextExtraLife = 10000;

private Lives lives;
private LivesCount livesCount;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		//GameObject.DontDestroyOnLoad(gameObject);
		//Reset();
	}
	
	public void Score(int points){
		score += points;
		text.text = score.ToString();
		if (score >= nextExtraLife){
			livesCount = GameObject.FindObjectOfType<LivesCount>();
			livesCount.incLives ();
			nextExtraLife += 10000;
			lives = GameObject.FindObjectOfType<Lives>();
			lives.text.text = ("Lives: " + livesCount.getLives ());
			}
	}
	
	public void DisplayFinalScore (){
	lives = GameObject.FindObjectOfType<Lives>();
		if (lives.noLives){
			text.text = score.ToString();
			}
	
	}
	
	public static void Reset(){
		score = 0;
	}

	public int getScore(){
		return score;
	}
}
