using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject prefabBullet;
	public float shootfoce;
	public Transform shootPosition;
	GameObject instanceBullet;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			instanceBullet = Instantiate (prefabBullet, transform.position, shootPosition.transform.rotation) as GameObject;
			GetComponent<AudioSource> ().Play ();
			instanceBullet.GetComponent<Rigidbody> ().AddForce (shootPosition.up * shootfoce);
		}
	}
}
