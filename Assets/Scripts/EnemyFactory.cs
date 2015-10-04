using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	public GameObject basicEnemyPrefab;
	public int numberToInstantiate;

	IEnumerator Start(){
		for(int i = 0; i < numberToInstantiate; ++i){
			yield return new WaitForSeconds(0.5f);
			GameObject newE = Instantiate(basicEnemyPrefab, transform.position, transform.rotation) as GameObject;
		}
	}
}
