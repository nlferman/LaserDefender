using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed = 9.0f;
	public float padding = 1f;
	public float projectileSpeed = 3f;
	public float firingRate = 1.0f;
	public float health = 300f;
	public float maxhealth = 300f;
	public AudioClip playerDestroyed;
	
	private Lives lives;
	private LivesCount livescount;
	public GameObject laserPrefab;
	
	float xmin;
	float xmax;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
			
	}
	
	
	void OnTriggerEnter2D (Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile){
			health -= missile.GetDamage();
			missile.Hit();	
			if (health <= 0){
				lives = GameObject.FindObjectOfType<Lives>();
				lives.minusLives();
				AudioSource.PlayClipAtPoint(playerDestroyed, transform.position);
					if (lives.noLives){
						Destroy(gameObject);
					}
				reSpawn();
			}
		}
	}
	
	void reSpawn(){
		health = maxhealth;
		transform.position = new Vector3 (0, -4.5f, 0);
	}
	void Fire (){
		Vector3 offset = new Vector3(0,1,0);
		GameObject beam = Instantiate(laserPrefab, transform.position+offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, projectileSpeed, 0);
		}
	// Update is called once per frame
	void Update () {
	if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
		//transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		transform.position += Vector3.right * speed * Time.deltaTime;
	}else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
		//transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		transform.position += Vector3.left * speed * Time.deltaTime;
		}
	//Shooting a laser
		if (Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.000001f, firingRate);
			}
		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
			}
	//restrict the player to the gamespace
	float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
	transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
