using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	private bool movingRight = true;
	public float spawnDelay = 0.1f;
	
	public float speed = 2.0f;

	private ScoreKeeper scoreKeeper;
	
	float xmin;
	float xmax;

	int greenShipAppearance = 3000;
	int greenshipCount = 0;

	// Use this for initialization
	void Start () {
	
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 rightBounder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		xmin = leftBoundary.x;
		xmax = rightBounder.x;

		scoreKeeper = FindObjectOfType<ScoreKeeper> ();
		
		SpawnUntilFull();
		
		}
	
	public void spawn(){
		foreach( Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab[1], child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
			}
	}
	
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		int includeShips = 0;
		if (scoreKeeper.getScore () > greenShipAppearance && greenshipCount > 0) {
			includeShips = Random.Range (0, 2);
			if (includeShips == 1) {
				greenshipCount--;
			}
		}
		if(freePosition){
			GameObject enemy = Instantiate(enemyPrefab[includeShips], freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;	
		}
		if(NextFreePosition()){
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
		if (movingRight){
		transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
		transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float rightEdgeOfFormation = transform.position.x + (0.45f*width);
		float leftEdgeOfFormation = transform.position.x - (0.45f*width);
		if (leftEdgeOfFormation < xmin){
			movingRight = true;
		}else if (rightEdgeOfFormation > xmax){
			movingRight = false;		
		}
		
		if(AllMembersDead()){
			if (scoreKeeper.getScore () > greenShipAppearance) {
				greenshipCount = 2;
			}
			SpawnUntilFull();
		}
	}
	
	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount == 0){
				return childPositionGameObject;
			}
		}
		
		return null;
		
	}
	
	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount > 0){
				return false;
			}
		}
			
			return true;
			
		}
}
