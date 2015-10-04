using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {
	public float speed = 5f;
	int dir = 1;
	[SerializeField]
	Rigidbody2D rb2D;

	bool dead = false;

	public void StopMoving(){
		rb2D.velocity = new Vector2(0, 0);
		dead = true;
		rb2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
	}

	
	public void KnockBack(float x, float knockBackForce){
		int dir = 0;
		if(x >= 0){
			dir = 1;
		}
		else if(x < 0){
			dir = -1;
		}
		rb2D.AddForce(new Vector2(transform.position.x + dir * knockBackForce,0));
		// wait a short period to go back to original velocity
		StartCoroutine(ReturnToNormalVelocity());
	}

	IEnumerator ReturnToNormalVelocity(){
		yield return new WaitForSeconds(0.2f);
		rb2D.velocity = new Vector2(dir * speed, rb2D.velocity.y);
	}

	// change dir on collision
	void OnCollisionEnter2D(Collision2D coll){
		if(dead == true){
			return;
		}

		if (coll.gameObject.layer != LayerMask.NameToLayer("Ground")){
			return;
		}

		dir = -dir;
		rb2D.velocity = new Vector2(dir * speed, rb2D.velocity.y);
	}
}
