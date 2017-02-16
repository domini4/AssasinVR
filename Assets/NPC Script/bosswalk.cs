using UnityEngine;
using System.Collections;

public class bosswalk : MonoBehaviour {

	public GameObject WayPoint;
	Animator anim;
	private bool collided = false;

	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (KillGuards_one.Globals.GameWon) {
			Vector3 direction = WayPoint.transform.position - transform.position;
			anim.SetBool ("isIdle", false);
			if (direction.magnitude > 2) {
				this.transform.Translate (0, 0, 0.05f);
				anim.SetBool ("isWalking", true);
			} else {
				anim.SetBool ("isWalking", false);
			}
		}
			else
			{
				anim.SetBool("isIdle", true);
				anim.SetBool("isWalking", false);
			}
	}

}
