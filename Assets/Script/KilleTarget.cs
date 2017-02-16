using UnityEngine;
using System.Collections;

public class KilleTarget : MonoBehaviour {

	void OnCollisionEnter(Collision collide){
		if(collide.gameObject.tag == "ball"){
			GameManager.Instance.isKilled = true;
		}
	}

}
