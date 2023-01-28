using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

//A script to handle loading levels.

	public void LoadLevel(string name){  //Loads the next level when all of the breakable bricks are destroyed.
		SceneManager.LoadScene (name);
	}
	public void QuitRequest(){  //Option to quit the game from start menu.
		Application.Quit ();
	}
}
