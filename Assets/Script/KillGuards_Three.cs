using UnityEngine;
using System.Collections;

public class KillGuards_Three : MonoBehaviour {
	private string targetGuardNum;
	void OnCollisionEnter(Collision collide){
		targetGuardNum = GameManager.Instance.currentTargetGuard;
		if(collide.gameObject.tag == "ball"){
			if (gameObject.tag == targetGuardNum) {
				GameManager.Instance.currentTargetGuard = "two";
				GameManager.Instance.KillGuards ();
			} else {
				GameManager.Instance.isExposed = true;
			}
		}
	}
}
