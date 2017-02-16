using UnityEngine;
using System.Collections;

public class BulletHole : MonoBehaviour {

	public GameObject bulletHole;
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "ball"){
			Instantiate (bulletHole, col.gameObject.transform.position, col.gameObject.transform.rotation);
			Destroy (col.gameObject);

		}

	}
}
