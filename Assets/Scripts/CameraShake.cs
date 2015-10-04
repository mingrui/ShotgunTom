using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	public float shakeAmt = 0.05f;

	public void StartShake(){
		InvokeRepeating("Shake", 0, .01f);
		Invoke("StopShaking", 0.3f);
	}

	void Shake()
	{
		if(shakeAmt>0)
		{
			float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
			Vector3 withOffSet = Camera.main.transform.position;
			// vertical shake
			withOffSet.y += quakeAmt;
			Camera.main.transform.position = withOffSet;
		}
	}

	// camera kick, opposite of firing direction
	void CameraKick(){

	}
	
	void StopShaking()
	{
		CancelInvoke("Shake");
	}
}
