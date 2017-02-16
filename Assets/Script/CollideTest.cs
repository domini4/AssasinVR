using UnityEngine;
using System.Collections;

public class CollideTest : MonoBehaviour {
	public GameObject explosionParticle;
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "ball"){
			Instantiate (explosionParticle, transform.position, transform.rotation);
			Destroy (gameObject);
		}

	}
}
