using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	private int points;

	public void ButtonPressed(){
		SceneManager.LoadScene ("Ninja");
	}

	public UnityEngine.UI.Text text;
	//private string[] line = System.IO.File.ReadAllLines("Assets/Info.txt");

	void Start () {
		Info.time = Info.playerScore;
		Vector2 score = Info.updateBestScore(points = Info.updatePoints ());
		text.text = "+" + points + " pts\nHighscore: " + score.x + " pts\nHighest Level: Level " + score.y;
	}
}