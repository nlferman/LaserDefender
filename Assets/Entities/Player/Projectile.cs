using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Projectile : MonoBehaviour {

	public float damage = 100f;

	void Start(){
		string projectileName = transform.name;
		switch (projectileName) {
		case "Enemy_Laser(Clone)":
			damage = 100f;
			break;
		case "Enemy_Rocket(Clone)":
			damage = 150f;
			break;
		default:
			damage = 100f;
			break;
		}


	}


	public float GetDamage(){
		return damage;
	}
	
	public void Hit(){
		Destroy(gameObject);
	}	
}
