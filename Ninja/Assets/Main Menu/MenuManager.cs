using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void ButtonPressed(){
		SceneManager.LoadScene ("Ninja");
	}

	public void tutorialButtonPressed(){
		SceneManager.LoadScene ("Tutorial");
	}

	public void storeButtonPress(){
		SceneManager.LoadScene ("Store");
	}
}
