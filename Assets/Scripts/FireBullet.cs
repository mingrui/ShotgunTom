using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {
	PlayerController player;
	public GameObject bulletPrefab;
	public float coolDownDur = 0.2f;
	public float knockBackForce = 200f;
	float coolDownCounter;

	public float randomDist = 0.1f;

	Rigidbody2D rb2D;

	public CameraShake cameraShake;

	void Awake(){
		player = GetComponent<PlayerController>();
		rb2D = GetComponent<Rigidbody2D>();
	}

	void Update () {
		// should use keymapping
		if(Input.GetKey(KeyCode.K) && coolDownCounter > coolDownDur){
			coolDownCounter = 0;
			Fire();
		}

		if(coolDownCounter < coolDownDur){
			coolDownCounter += Time.deltaTime;
		}
	}

	// should use object pool
	void Fire(){
		GameObject bulletClone;
		// Flavor: small variation in bullet launching position
		float randomYOffset = Random.Range(-randomDist, randomDist);
		Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + randomYOffset, transform.position.z);
		bulletClone = Instantiate(bulletPrefab, bulletPosition, transform.rotation) as GameObject;
		bulletClone.GetComponent<Bullet>().Fly(player.facingRight);

		// Flavor: add player knockback when firing
		KnockBack();

		// Flavor: add camera shake
		cameraShake.StartShake();
	}

	void KnockBack(){
		int knockBackDir;
		if(player.facingRight){
			knockBackDir = -1;
		}
		else{
			knockBackDir = 1;
		}

		rb2D.AddForce(new Vector2(transform.position.x + knockBackDir * knockBackForce,0));
	}


}
