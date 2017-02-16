using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

	public GameObject explosionParticle;


	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.tag == "ball"){
			Instantiate(explosionParticle, transform.position, Quaternion.identity);
			explosionParticle.GetComponent<AudioSource> ().Play();
			Destroy(gameObject);
		}

	}
}
