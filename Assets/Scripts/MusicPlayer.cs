using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	
	private AudioSource music;
	
	void Start (){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;		
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
	}

	void Update(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene level, LoadSceneMode mode){
		music.Stop();
		
		if(level.buildIndex == 0){
			music.clip = startClip;
			}
		if(level.buildIndex == 1){
			music.clip = gameClip;
		}
		if(level.buildIndex == 2){
			music.clip = endClip;
		}
		music.loop = true;
		music.Play();
	}
	
}
