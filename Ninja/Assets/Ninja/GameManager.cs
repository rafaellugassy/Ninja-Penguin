using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private int level;
	public int startFrames;
	private int curFrame = 0;
	public Animator anim;
	public Animator enemyAnim;
	private bool win;
	public Animator playerAnim;
	public Animator playerHolderAnim;
	private int playerFrame = 1000000000;
	private int enemyFrame;
	private int framesAfterStart = 100000000;
	private bool start = false;
	private bool button = false;
	private int framesSinceAnim  = -100;
	public GameObject exclamation;
	public UnityEngine.UI.Text text;
	private bool playerPress;
	//private string[] lines = System.IO.File.ReadAllLines("Assets/Info.txt");
	private GameObject enemyExclamation;
	private GameObject playerExclamation;
	// Use this for initialization
	void Start () {
		curFrame = 0;
		level = Info.level;
		enemyFrame = (int)(400f / (level * Mathf.Log(level + 1)));
		text.text = "Level " + level;
	}

	public void ButtonPressed(){
		if (curFrame >= startFrames && !button) {
			button = true;
			playerFrame = curFrame < framesAfterStart ? playerFrame : curFrame;
			playerAnim.SetTrigger ("Attack");
			anim.StopPlayback ();
			anim.SetTrigger ("PlayerAttack");
			enemyExclamation.transform.position = new Vector3 (-1000, 0);
			playerExclamation.transform.position = new Vector3 (-1000, 0);
		}
	}

	public void playerAttackEnd (){
		if (playerFrame - framesAfterStart <= enemyFrame && playerFrame > framesAfterStart) {
			anim.SetTrigger ("Win");
			playerAnim.SetTrigger ("Win");
			enemyAnim.SetTrigger ("PlayerWin");
			win = true;
		} else {
			win = false;
			anim.SetTrigger ("Lose");
			playerAnim.SetTrigger ("Lose");
			//enemyAnim.SetTrigger ("PlayerLose");
		}
	}

	// Update is called once per frame
	void Update () {
		if (!button) {
			curFrame++;

			if (curFrame > startFrames && !start) {
				start = Random.Range (1, 500) == 1;
				if (start) {
					framesAfterStart = curFrame;
					enemyExclamation = Instantiate (exclamation, new Vector3 (0, 1, 0), Quaternion.identity) as GameObject;
					playerExclamation = Instantiate (exclamation, new Vector3 (0, -1, 0), Quaternion.identity) as GameObject;
				}
			}

			if (curFrame - framesSinceAnim > 300) {
				if (Random.Range (1, 200) == 1) {
					framesSinceAnim = curFrame;
					anim.SetTrigger ("Full Screen");
				}
			}

			if (start && button) {
				playerExclamation.transform.localScale = new Vector3 (0, 0, 0);
			}

			if (start && curFrame - framesAfterStart > enemyFrame) {
				button = true;
				win = false;
				enemyAnim.SetTrigger ("Attack");
				anim.SetTrigger ("EnemyAttack");
			}
		}
	}

	public void endGame(){
		if (win) {
			Info.level++;
			Info.playerScore = playerFrame - framesAfterStart;
			Info.enemyScore = enemyFrame;
			SceneManager.LoadScene ("Win");
		} else {
			Info.level = 1;
			Info.playerScore = 0;
			Info.enemyScore = 0;
			SceneManager.LoadScene ("Lose");
		}
	}
}
