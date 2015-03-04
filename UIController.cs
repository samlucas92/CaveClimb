using UnityEngine;
using System.Collections;
using System;
using ChartboostSDK;

public class UIController : MonoBehaviour {

	// Use this for initialization


	public TextMesh scoreTextMesh,ScoreShadowTextMesh,finalScoreTextMesh,BestScoreTextMesh;
	int inGameScore =0;

	public GameObject newScoreObj,ScoreBoard,MainMenuContainer,Tutorial,QuitButton, LeaderBoard;
	public Camera UICamera;
	public static bool isRestartPressed  = false;
	bool readyToPlay  = false;
	public int coins;


	void OnEnable(){
		//PlayerPrefs.DeleteAll();
		playerController.IncreaseScore += OnScoreIncrease;
		playerController.PlayerDead += OnPlayerDead;
		MainMenuContainer.SetActive(true);
		newScoreObj.SetActive(false);
		ScoreBoard.SetActive(false);
		LeaderBoard.SetActive(false);


		if(isRestartPressed)
		{ 
			MainMenuContainer.SetActive(false);
			isRestartPressed = false;
			readyToPlay = true;
		} 
		else {
			playerController.currentState = playerController.playerStates.idle;

		}


	}
	 

	RaycastHit hit ;
	void Update () {

		if(Input.GetKeyDown(KeyCode.Mouse0) )
		{

			Ray R = UICamera.ScreenPointToRay(Input.mousePosition);
			if( readyToPlay && playerController.currentState == playerController.playerStates.idle)
			{
				playerController.currentState = playerController.playerStates.alive;
				readyToPlay = false;
				iTween.ScaleTo(Tutorial,iTween.Hash("scale",Vector3.zero,"time",0.5f,"easetype",iTween.EaseType.linear));
				iTween.FadeTo(Tutorial,iTween.Hash("alpha",0,"time",0.2f,"easetype",iTween.EaseType.linear));
			}
			if(Physics.Raycast(R,out hit,100))
			{
				//iTween.ScaleTo(hit.collider.gameObject,iTween.Hash("scale",new Vector3(0.45f,0.45f,0.45f),"time",0.5f,"easetype",iTween.EaseType.easeInOutBounce));
				SoundController.Static.PlayClickSound();
				switch(hit.collider.name)
				{
					
				 
				case "Play":
					MainMenuContainer.SetActive(false);
					Tutorial.SetActive(true);
					readyToPlay = true;
				 
					break;
				case "LeaderButton":
					MainMenuContainer.SetActive(false);
					LeaderBoard.SetActive(true);

					break;
				case "facebookLike":
					#if UNITY_ANDROID
					Application.OpenURL("https://www.facebook.com/CaveClimb");
					#endif
					#if UNITY_IOS
					Application.OpenURL("https://www.facebook.com/CaveClimb");
					#endif
					#if UNITY_WEBPLAYER
					Application.OpenURL("https://www.facebook.com/CaveClimb");
					#endif
					#if UNITY_EDITOR
					Application.OpenURL("https://www.facebook.com/CaveClimb");
					#endif

					break;
				}
			 
			}





		}

		if(Input.GetKeyUp(KeyCode.Mouse0) )
		{
	
			string score = inGameScore.ToString();
			Ray R = UICamera.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(R,out hit,100))
			{

				switch(hit.collider.name)
				{
					
				case "Home":
					//LeaderBoard.SetActive(false);
					restart();
					break;
					
				case "Replay":
					isRestartPressed = true;
					restart();
					playerController.currentState = playerController.playerStates.idle;
					break;

				case "Facebook":
					//share.OnClick();


					break;

				case "Quit":

					Application.Quit();

					break;
				}
			}
			
		}

	
		//to handle escape key
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			if( playerController.currentState ==playerController.playerStates.idle)
			{
				
				Application.Quit();
			}
			else {
				
				restart();
			}
			
		}
	}

	public void restart()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}
	public void DidCompleteRewardedVideo(CBLocation location, int x)
	{
		coins = coins + 100;
		int curCoin = PlayerPrefs.GetInt ("Coins",0);
		coins = coins + curCoin;
		PlayerPrefs.SetInt("Coins", coins);
	}
	void OnScoreIncrease(System.Object obj,EventArgs args) 
	{
		inGameScore++;
        scoreTextMesh.text =""+ inGameScore;
		ScoreShadowTextMesh.text=""+inGameScore;
		SoundController.Static.PlayScoreIncrease();
	}

	void onCustomize()
	{
		iTween.ScaleTo(ScoreBoard,iTween.Hash("scale",Vector3.one,"time",1.5f,"easetype",iTween.EaseType.easeOutSine,"delay",1.0f));
		
	}

	void OnPlayerDead(System.Object obj,EventArgs args)
	{
		ScoreBoard.transform.localScale = Vector3.zero;
		ScoreBoard.SetActive(true);
		int turns = PlayerPrefs.GetInt ("turns", 0);
		turns++;
		PlayerPrefs.SetInt ("Scored", inGameScore);
		PlayerPrefs.SetInt ("turns", turns);
		int deaths = PlayerPrefs.GetInt ("turns", 0);
		if(deaths % 3 == 0){
			Chartboost.cacheInterstitial(CBLocation.Default);
			Chartboost.showInterstitial(CBLocation.Default);

		}

      
	 	iTween.ScaleTo(ScoreBoard,iTween.Hash("scale",Vector3.one,"time",1.5f,"easetype",iTween.EaseType.easeOutSine,"delay",1.0f));
		scoreTextMesh.renderer.enabled = false;
		ScoreShadowTextMesh.renderer.enabled= false;
		finalScoreTextMesh.text = "Score : "+inGameScore;


		updateLeader();


		BestScoreTextMesh.text = "Best : " + PlayerPrefs.GetInt("BestScore",inGameScore);

	}
	void OnDisable()
	{

		playerController.IncreaseScore -= OnScoreIncrease;
		playerController.PlayerDead -= OnPlayerDead;

		 
	}
	void updateLeader(){
		int best = PlayerPrefs.GetInt ("BestScore",0);
		int score1 = PlayerPrefs.GetInt ("Score1", 0);
		int score2 = PlayerPrefs.GetInt ("Score2", 0);
		int score3 = PlayerPrefs.GetInt ("Score3", 0);
		int score4 = PlayerPrefs.GetInt ("Score4", 0);
		int score5 = PlayerPrefs.GetInt ("Score5", 0);
		int score6 = PlayerPrefs.GetInt ("Score6", 0);
		int score7 = PlayerPrefs.GetInt ("Score7", 0);
		int score8 = PlayerPrefs.GetInt ("Score8", 0);
		int score9 = PlayerPrefs.GetInt ("Score9", 0);



		if ((best < inGameScore) && (best != inGameScore)) {

			PlayerPrefs.SetInt("Score9",score8);
			PlayerPrefs.SetInt("Score8",score7);
			PlayerPrefs.SetInt("Score7",score6);
			PlayerPrefs.SetInt("Score6",score5);
			PlayerPrefs.SetInt("Score5",score4);
			PlayerPrefs.SetInt("Score4",score3);
			PlayerPrefs.SetInt("Score3",score2);
			PlayerPrefs.SetInt("Score2",score1);
			PlayerPrefs.SetInt("Score1",best);

			PlayerPrefs.SetInt ("BestScore", inGameScore);
			newScoreObj.SetActive (true);


		} else if ((score1 < inGameScore) || (score1 == inGameScore)){
			if(score1 != best){
				PlayerPrefs.SetInt("Score9",score8);
				PlayerPrefs.SetInt("Score8",score7);
				PlayerPrefs.SetInt("Score7",score6);
				PlayerPrefs.SetInt("Score6",score5);
				PlayerPrefs.SetInt("Score5",score4);
				PlayerPrefs.SetInt("Score4",score3);
				PlayerPrefs.SetInt("Score3",score2);
				PlayerPrefs.SetInt("Score2",score1);

				PlayerPrefs.SetInt ("Score1", inGameScore);
			}else{
				goto done;
			}

		}  else if ((score2 < inGameScore) || (score2 == inGameScore)){
			if(score2 != score1){
				PlayerPrefs.SetInt("Score9",score8);
				PlayerPrefs.SetInt("Score8",score7);
				PlayerPrefs.SetInt("Score7",score6);
				PlayerPrefs.SetInt("Score6",score5);
				PlayerPrefs.SetInt("Score5",score4);
				PlayerPrefs.SetInt("Score4",score3);
				PlayerPrefs.SetInt("Score3",score2);

				PlayerPrefs.SetInt ("Score2", inGameScore);
			}else{
				goto done;
			}
			
		}  else if ((score3 < inGameScore) || (score3 == inGameScore)){
			if(score3 != score2){
				PlayerPrefs.SetInt("Score9",score8);
				PlayerPrefs.SetInt("Score8",score7);
				PlayerPrefs.SetInt("Score7",score6);
				PlayerPrefs.SetInt("Score6",score5);
				PlayerPrefs.SetInt("Score5",score4);
				PlayerPrefs.SetInt("Score4",score3);
				
				PlayerPrefs.SetInt ("Score3", inGameScore);
			}else{
				goto done;
			}
			
		}  else if ((score4 < inGameScore) || (score4 == inGameScore)){
			if(score4 != score3){
				PlayerPrefs.SetInt("Score9",score8);
				PlayerPrefs.SetInt("Score8",score7);
				PlayerPrefs.SetInt("Score7",score6);
				PlayerPrefs.SetInt("Score6",score5);
				PlayerPrefs.SetInt("Score5",score4);

				
				PlayerPrefs.SetInt ("Score4", inGameScore);
			}else{
				goto done;
			}
			
		}  else if ((score5 < inGameScore) || (score5 == inGameScore)){
			if(score5 != score4){
				PlayerPrefs.SetInt("Score9",score8);
				PlayerPrefs.SetInt("Score8",score7);
				PlayerPrefs.SetInt("Score7",score6);
				PlayerPrefs.SetInt("Score6",score5);

				PlayerPrefs.SetInt ("Score5", inGameScore);
			}else{
				goto done;
			}
			
		} else if ((score6 < inGameScore) || (score6 == inGameScore)){
			if(score6 != score5){
				PlayerPrefs.SetInt("Score9",score8);
				PlayerPrefs.SetInt("Score8",score7);
				PlayerPrefs.SetInt("Score7",score6);

				
				PlayerPrefs.SetInt ("Score6", inGameScore);
			}else{
				goto done;
			}
			
		}  else if ((score7 < inGameScore) || (score7 == inGameScore)){
			if(score7 != score6){
				PlayerPrefs.SetInt("Score9",score8);
				PlayerPrefs.SetInt("Score8",score7);

				
				PlayerPrefs.SetInt ("Score7", inGameScore);
			}else{
				goto done;
			}
			
		}  else if ((score8 < inGameScore) || (score8 == inGameScore)){
			if(score8 != score7){
				PlayerPrefs.SetInt("Score9",score8);

				
				PlayerPrefs.SetInt ("Score8", inGameScore);
			}else{
				goto done;
			}
			
		}  else if ((score9 < inGameScore) || (score9 == inGameScore)){
			if(score9 != score8){
				PlayerPrefs.SetInt ("Score9", inGameScore);
			}else{
				goto done;
			}
			
		}done:;

	}
}
