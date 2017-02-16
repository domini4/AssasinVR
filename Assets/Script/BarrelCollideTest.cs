using UnityEngine;
using System.Collections;

public class BarrelCollideTest : MonoBehaviour {
	public GameObject explosionParticle;
	public GameObject NPC;


	public static bool exploded = false;

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "ball"){
			Instantiate (explosionParticle, transform.position, transform.rotation);
			Destroy (gameObject);
			if (Vector3.Distance (transform.position, NPC.transform.position) < 20) {
				GameManager.Instance.isKilled = true;
				exploded = true;
				Debug.Log ("NPC died due to barrel explosion");
			}
		}
	}
}
