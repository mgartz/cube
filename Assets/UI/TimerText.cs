using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerText : MonoBehaviour {
	int totalSeconds;
	int currentSecondsLeft;
	float timeAtStart;

	int showExtraSecondsCounter = 0;
	int lastExtraSecondsAwarded;

	void FixedUpdate () {
		UpdateTimeElapsed();
	}

	void UpdateTimeElapsed(){
		int secondsElapsed = (int)(Time.time - timeAtStart);
		int secondsLeft = Mathf.Max(0, totalSeconds - secondsElapsed);
		if (secondsLeft != currentSecondsLeft){
			currentSecondsLeft = secondsLeft;
			UpdateSecondsLeft();
		}
	}

	void UpdateSecondsLeft(){
		string text = "";
		text += currentSecondsLeft + "s";
		if (showExtraSecondsCounter-- > 0)
			text += "\n+" + lastExtraSecondsAwarded;
		GetComponent<Text>().text = text;

		if (currentSecondsLeft == 0){
			Game.instance.EndGame();
		}
	}

	public void StartTimer(int seconds){
		totalSeconds = seconds;
		currentSecondsLeft = totalSeconds;
		timeAtStart = Time.time;

		UpdateSecondsLeft();
	}

	public void AddSeconds(int secondsToAdd){
		lastExtraSecondsAwarded = secondsToAdd;
		showExtraSecondsCounter = 4;

		totalSeconds += secondsToAdd;
		UpdateTimeElapsed();
	}
}
