using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour{
	public static Game instance;

	public ScoreText scoreText;
	public TimerText timerText;

	public AudioSource gameOverAudioSource;

	int score = 0;

	bool isGameActive = true;

	// Use this for initialization
	void Start () {
		instance = this;
		timerText.StartTimer(Global.gameDurationSeconds);
	}

	void Update(){
		if (Input.GetKeyDown(Global.retryKey))
			RestartGame();
	}

	public void EndGame(){
		isGameActive = false;
		timerText.GetComponent<Text>().enabled = false;
		scoreText.ShowRestart();
		gameOverAudioSource.Play();
	}

	public void RestartGame(){
		if (!isGameActive){
			isGameActive = true;

			score = 0;
			scoreText.UpdateScore(score);

			timerText.GetComponent<Text>().enabled = true;
			timerText.StartTimer(Global.gameDurationSeconds);
		}
	}

	public void AddScore(){
		if (isGameActive){
			scoreText.UpdateScore(++score);
			timerText.AddSeconds(Global.goalTimeRewardSeconds);
		}
	}

}
