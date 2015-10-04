using UnityEngine;
using System.Collections;

public class CameraLerp : MonoBehaviour {
	public float damping = 5f;
	// camera will lag behind player by a very short period of time
	[SerializeField]
	GameObject focusTarget;

	// camera will lerp to front of player's direction to allow player to see more of what's next

	void LateUpdate(){
		Vector3 targetPos = new Vector3(focusTarget.transform.position.x,
		                                 focusTarget.transform.position.y,
		                                 transform.position.z);

		transform.position = Vector3.Lerp(transform.position, targetPos, damping * Time.deltaTime);
	}
}
