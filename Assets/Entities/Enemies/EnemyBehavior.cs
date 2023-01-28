using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 100;
	public float projectileSpeed = 3f;
	public float shotsPerSecond = 0.5f;
	
	public AudioClip enemyDestroyed;
	
	public int pointValue = 100;
	
	public GameObject laserPrefab;
	
	private ScoreKeeper scorekeeper;

	void Start(){
		scorekeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3 (0, -1f, 0);
		GameObject beam = Instantiate(laserPrefab, startPosition, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, -projectileSpeed, 0);
		
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile){
			health -= missile.GetDamage();
			missile.Hit();	
			if (health <= 0){
				Die ();
			}
		}
	}
	
	void Die(){
		Destroy(gameObject);
		scorekeeper = GameObject.FindObjectOfType<ScoreKeeper>();
		scorekeeper.Score(pointValue);
		AudioSource.PlayClipAtPoint(enemyDestroyed, transform.position);
	}
	
	
	
	void Update (){
		Animator anim = gameObject.GetComponent<Animator>();
		
		bool idle = anim.GetCurrentAnimatorStateInfo(0).IsName("Idle");
		
		if (idle){
		float probability = Time.deltaTime * shotsPerSecond;
		if(Random.value < probability){
			Fire();
			}
		}
	}
}
