using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	public void StartPause(float p){
		StartCoroutine(Pause(p));
	}

	IEnumerator Pause(float p)
	{
		Time.timeScale = 0f;
		float pauseEndTime = Time.realtimeSinceStartup + p;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1;
	}
}
