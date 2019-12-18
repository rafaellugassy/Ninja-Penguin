using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour {

	public GameObject game;
	public Animator enemy;
	public Animator anim;
	public Animator player;

	void playerAttackEnd (){
		game.GetComponent<GameManager> ().playerAttackEnd ();
	}

	void enemySleep(){
		enemy.SetTrigger ("Sleep");
	}

	void enemyAttackEnd(){
		anim.SetTrigger ("EnemyAttackWin");
		enemy.SetTrigger ("Idle");
		player.SetTrigger ("Lose");
	}

	void endGame(){
		game.GetComponent<GameManager> ().endGame ();
	}
}
