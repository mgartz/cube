using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateScore(int score){
		GetComponent<Text>().text = "" + score;
	}

	public void ShowRestart(){
		GetComponent<Text>().text = GetComponent<Text>().text + "\nR - RESTART";
	}

}
