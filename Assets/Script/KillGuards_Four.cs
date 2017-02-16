using UnityEngine;
using System.Collections;

public class KillGuards_Four : MonoBehaviour {
	private string targetGuardNum;
	void OnCollisionEnter(Collision collide){
		targetGuardNum = GameManager.Instance.currentTargetGuard;
		if(collide.gameObject.tag == "ball"){
			if (gameObject.tag == targetGuardNum) {
				GameManager.Instance.currentTargetGuard = "three";
				GameManager.Instance.KillGuards ();
			} else {
				GameManager.Instance.isExposed = true;
			}
		}
	}
}
