using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject shellPrefab;
	public float shellFlyForce = 700;
	public float speed = 6f;
	public float shellYSpeed = 2f;
	public int dmg = 1;
	public float knockBackForce = 200;
	Rigidbody2D rb2D;

	void Awake(){
		rb2D = GetComponent<Rigidbody2D>();
	}

	public void Fly(bool facingRight){
		if(facingRight){
			rb2D.velocity = new Vector2(speed, 0);
		}
		else{
			rb2D.velocity = new Vector2(-speed, 0);
		}

		// leave bullet shell
		GameObject shellGO = Instantiate(shellPrefab, transform.position, transform.rotation) as GameObject;
		Vector2 shellFlyDir = new Vector2(-rb2D.velocity.normalized.x, shellYSpeed);
		shellGO.GetComponent<Rigidbody2D>().AddForce(shellFlyDir.normalized * shellFlyForce);
	}

	void OnTriggerEnter2D(Collider2D other){
		// if game is multiplayer in the future, handle this differently
		// to allow players to hit each other
		if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
			return;
		}

		Destroy(gameObject);
		if(other.gameObject.layer == LayerMask.NameToLayer("Enemy")){
			BasicEnemy basicE = other.GetComponent<BasicEnemy>();
			basicE.TakeDamage(dmg);
			basicE.movement.KnockBack(rb2D.velocity.x, knockBackForce);
		}
	}

	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}
