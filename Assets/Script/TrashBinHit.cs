using UnityEngine;
using System.Collections;

public class TrashBinHit : MonoBehaviour {

	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.tag == "ball"){
			GetComponent<AudioSource> ().Play ();
		}

	}

}
