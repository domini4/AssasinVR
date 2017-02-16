using UnityEngine;
using System.Collections;



public class KillGuards_one : MonoBehaviour {

	public static class Globals 
	{
		public static bool GameWon = false;
	}

	private string targetGuardNum;
	void OnCollisionEnter(Collision collide){
		targetGuardNum = GameManager.Instance.currentTargetGuard;
		if(collide.gameObject.tag == "ball"){
			if (gameObject.tag == targetGuardNum) {
				Debug.Log ("YOU WIN THE GAME!");
				GameManager.Instance.currentTargetGuard = "None";
				GameManager.Instance.isKilled = true;
				GameManager.Instance.KillGuards ();
				Globals.GameWon = true;
			} else {
				GameManager.Instance.isExposed = true;
			}
		}
	}
}
