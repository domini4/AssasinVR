using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using VRTK;

 



public class GameManager : MonoBehaviour {

	public AudioClip officeWelcome;
	public AudioClip niceJob;
    public AudioClip lvl1instructions;
    public AudioClip lvl2instructions;
	public AudioClip rangeInstructions;
	bool playedAudio;

	public AudioSource audio;

	public static GameManager Instance;

	private string currentLevel;
	private GameState currentState;
	public string currentTargetGuard;
	public int guardsNum = 4;
	public int ammuNum = 200;
	public bool isKilled = false;
	public bool isExposed = false;

	//all of the game state
	public enum GameState{
		Started,
		Trained,
		Level_1_Finished,
		Level_2_Finished,
		Level_3_Finished
	};

	IEnumerator PlayClip(AudioClip clip,float delay) {
		yield return new WaitForSeconds (delay);
		audio.PlayOneShot (clip);
	}

	// Use this for initialization
	void Start () {
		//initiate the GameManager
		if(Instance != null){
			GameObject.Destroy (gameObject);
		}else{
			GameObject.DontDestroyOnLoad (gameObject);
			Instance = this;
			currentLevel = "Office";
			currentState = GameState.Started;
			currentTargetGuard = "four";
			audio = GetComponent<AudioSource> ();
			playedAudio = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentLevel) {
		//Office level
		case "Office":
			//interaction in office
			DoOffice();
			break;
		//shootingRange level
		case "shootingRange":
			//interaction in train
			DoTrain();
			break;
		//Level 1
		case "Level1":
			//interaction in leve1
			DoLevel1();
			break;
		//Level 2
		case "Level2":
			//interaction in level2
			Dolevel2();
			break;
		//Level 3
		case "Level3":
			//interaction in level3
			Dolevel3();
			break;
		}
	}

	private void DoOffice(){
		GameObject radio = GameObject.Find ("radio");
		switch(currentState){
		case GameState.Started:
			//play the audio
			if (!playedAudio) {
				audio.PlayOneShot (officeWelcome);
				playedAudio = true;
			}
			//pick up the radio, then switch to the train level

			if (radio.GetComponent<VRTK_InteractableObject> ().IsGrabbed () == true) {
				ammuNum = 1000;
				SceneManager.LoadScene ("shootingRange");
				SetLevelName ("shootingRange");
				playedAudio = false;
			}
			break;
		case GameState.Trained:
                //play the audio
                if (!playedAudio)
                {
                    audio.PlayOneShot(lvl1instructions);
                    playedAudio = true;
                }

                //pick up the radio, then swithc to  the level 1

                if (radio.GetComponent<VRTK_InteractableObject> ().IsGrabbed () == true){
				ammuNum = 10;
				SceneManager.LoadScene ("Level1");
				SetLevelName ("Level1");
			}
			break;
		case GameState.Level_1_Finished:
                //paly the audio
                if (!playedAudio)
                {
                    audio.PlayOneShot(lvl2instructions);
                    playedAudio = true;
                }


                //pick up the radio, then swithc to  the level 2
                if (radio.GetComponent<VRTK_InteractableObject> ().IsGrabbed () == true){
				ammuNum = 35;
				SceneManager.LoadScene ("Level2");
				SetLevelName ("Level2");
                }
			break;
		case GameState.Level_2_Finished:
			//play the audio


			////pick up the radio, then swithc to  the level 3
			if(radio.GetComponent<VRTK_InteractableObject> ().IsGrabbed () == true){
				currentTargetGuard = "four";
				ammuNum = 30;
				SceneManager.LoadScene ("Level3");
				SetLevelName ("Level3");
                }

			break;
		case GameState.Level_3_Finished:
			break;
		}
	}

	private void DoTrain(){
		GameObject radio = GameObject.Find ("radio");
		//back to the office

		if (!playedAudio) {
			audio.PlayOneShot (rangeInstructions);
			playedAudio = true;
		}

		if (radio.GetComponent<VRTK_InteractableObject> ().IsGrabbed () == true) {
			//play the audio

            
			playedAudio = false;
			SceneManager.LoadScene ("Office");
			//set the level name
			SetLevelName("Office");
			//set state
			currentState = GameState.Trained;
		}
	}

	private void DoLevel1(){
		GameObject radio = GameObject.Find ("radio");
		//back to the office
		if (radio.GetComponent<VRTK_InteractableObject> ().IsGrabbed () == true) {
			if(isKilled){
				//target killed
				//play the audio


				//back to the office
				playedAudio = false;
				SceneManager.LoadScene ("Office");
				//set the state
				SetLevelName("Office");
				currentState = GameState.Level_1_Finished;
				//reset the isKilled
				isKilled = false;
			}else{
				//target not killed
				if(ammuNum<=0){
					//play the audio
				}else{
					//play the audio
				}
					
				//back to the office
				Debug.Log(currentState);
				SceneManager.LoadScene ("Office");
				SetLevelName("Office");
			}
		}
	}

	private void Dolevel2(){
		//back to the office
		GameObject radio = GameObject.Find ("radio");
		if (radio.GetComponent<VRTK_InteractableObject> ().IsGrabbed () == true) {
			if(isKilled){
				//target killed
				//play the audio


				//back to the office
				playedAudio = false;
				SceneManager.LoadScene ("Office");
				SetLevelName("Office");
				//set the state
				currentState = GameState.Level_2_Finished;
				//reset the isKilled
				isKilled = false;
			}else{
				//target not killed
				//play the audio

				//back to the office
				SceneManager.LoadScene ("Office");
				SetLevelName("Office");
			}
		}
	}

	private void Dolevel3(){
		//back to the office
		GameObject radio = GameObject.Find ("radio");
		if (radio.GetComponent<VRTK_InteractableObject> ().IsGrabbed () == true) {
			if (!isExposed) {
				//not exposed
				if (isKilled) {
					//mission success
					//play the audio


					//back to the office
					playedAudio = false;
					SceneManager.LoadScene ("Office");
					//set the state
					currentState = GameState.Level_3_Finished;
					SetLevelName ("Office");
					//reset the isKilled
					isKilled = false;
				} else {
					//give up the mission
					//play the audio


					//back to the office
					SceneManager.LoadScene ("Office");
					SetLevelName ("Office");
				}
			} else {
				//exposed
				//play the audio


				//back to the office
				SceneManager.LoadScene ("Office");
				SetLevelName ("Office");
			}
		}
	}

	private void SetLevelName(string levelName){
		currentLevel = levelName;
	}

	public void KillGuards(){
		guardsNum--;
	}

	public void AmmunationDeduct(int num){
		ammuNum = ammuNum - num;
	}

}
