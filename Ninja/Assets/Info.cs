using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Info {
	public static int level = 1;
	public static int playerScore = 0;
	public static int enemyScore = 0;
	public static int time = 0;

	public static void update(){
		PlayerPrefs.Save ();
	}

	public static void changeCharacter(string character){
		PlayerPrefs.SetString ("current", character);
		update ();
	}

	public static bool buyCharacter(string character, int price){
		int points = PlayerPrefs.GetInt ("points");
		if (points >= price){
			PlayerPrefs.SetString (character, "true");
			PlayerPrefs.SetInt ("points", points - price);
			update ();
			return true;
		}
		return false;
	}

	public static Vector2 updateBestScore(int score){
		int highscore = PlayerPrefs.GetInt ("highscore");
		int highlevel = PlayerPrefs.GetInt ("highlevel");
		if (highscore < score) {
			highscore = score;
			PlayerPrefs.SetInt ("highscore", highscore);
		}
		if (highlevel < level) {
			highlevel = level;
			PlayerPrefs.SetInt ("highlevel", highlevel);
		}

		return new Vector2 ((float)highscore, (float)highlevel);
	}

	public static int updatePoints(){
		int points = (int)((10000f / (float)time) * Mathf.Log(level + 2.718218f));
		PlayerPrefs.SetInt ("points", PlayerPrefs.GetInt("points") + points);
		return points;
	}

}
