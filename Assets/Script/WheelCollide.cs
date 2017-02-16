using UnityEngine;
using System.Collections;

public class WheelCollide : MonoBehaviour {

	private bool isHit = false;
	public GameObject targetFab;
	public GameObject guardFab;

	private GameObject targetInstance;
	private GameObject guardInstance;

	void OnCollisionEnter(Collision collide){
		if(collide.gameObject.tag == "ball"){
			if (!isHit) {
				GetComponent<UnityStandardAssets.Vehicles.Car.CarAIControl> ().m_Driving = false;
				isHit = true;
				StartCoroutine ("spawnEnemies");
			}
		}
	}

	IEnumerator spawnEnemies () {
		yield return new WaitForSeconds (2);
		targetInstance = Instantiate (targetFab, transform.position + transform.right * 1.7f, transform.rotation) as GameObject;
		guardInstance = Instantiate (guardFab, transform.position - transform.right * 1.7f, transform.rotation) as GameObject;
	}


}