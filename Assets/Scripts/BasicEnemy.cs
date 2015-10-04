using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour {
	public int health = 2;
	public BasicMovement movement;
	[SerializeField]
	SpriteRenderer spriteRenderer;

	public void TakeDamage(int dmg){
		health -= dmg;
		if(health <= 0){
			Death();
		}
	}

	void Death(){
		// Flavor: disable enemy, leave body behind instead of destroying gameobject
		spriteRenderer.color = Color.black;
		transform.localScale = new Vector3(1, 0.5f, 1);
		// change layer to "Dead" to ignore all physics interactions
		gameObject.layer = LayerMask.NameToLayer("Dead");
		movement.StopMoving();
	}

}
