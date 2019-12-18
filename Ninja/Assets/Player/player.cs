using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public Animator anim;
	public string character;

	// Use this for initialization
	void Start () {
		if (character == "") {
			if (!PlayerPrefs.HasKey ("current")) {
				PlayerPrefs.SetString ("current", "Penguin");
			}
			anim.SetTrigger (PlayerPrefs.GetString ("current"));

		}
		else
			anim.SetTrigger (character);
	}
}
