using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour {
	public Animator[] box;
	public UnityEngine.UI.Text pts;
	public UnityEngine.UI.Text price;
	public UnityEngine.UI.Text button;
	private int selected = 0;

	void Start () {
		changeButton0();
	}

	private void selectCharacter(){
		if (selected == 0)
			Info.changeCharacter ("Penguin");
		else if (selected == 1 && PlayerPrefs.HasKey ("Gray"))
			Info.changeCharacter ("Gray");
		else if (selected == 2 && PlayerPrefs.HasKey ("Black"))
			Info.changeCharacter ("Black");
	}

	public void buttonPress(){
		if (selected == 1) {
			if (!PlayerPrefs.HasKey ("Gray")) {
				Info.buyCharacter ("Gray", 10000);
				selectCharacter ();
				changeButton1 ();
				return;
			}
			selectCharacter ();
			changeButton1 ();
			return;
		}
		if (selected == 2) {
			if (!PlayerPrefs.HasKey ("Black")) {
				Info.buyCharacter ("Black", 1000000);
				selectCharacter ();
				changeButton2 ();
				return;
			}
			selectCharacter ();
			changeButton2 ();
			return;
		}
		selectCharacter ();
		if (selected == 0) {
			changeButton0 ();
		}
	}

	public void changeButton0(){
		box [0].SetBool ("go", true);
		box [1].SetBool ("go", false);
		box [2].SetBool ("go", false);
		selected = 0;
		pts.text = "" + PlayerPrefs.GetInt ("points") + " pts";
		if (PlayerPrefs.GetString ("current") == "Penguin")
			price.text = "Selected";
		else
			price.text = "Owned";
		button.text = "Select";
	}

	public void changeButton1(){
		box [1].SetBool ("go", true);
		box [0].SetBool ("go", false);
		box [2].SetBool ("go", false);
		selected = 1;
		pts.text = "" + PlayerPrefs.GetInt ("points") + " pts";
		if (PlayerPrefs.HasKey ("Gray")) {
			if (PlayerPrefs.GetString ("current") == "Gray")
				price.text = "Selected";
			else
				price.text = "Owned";
			button.text = "Select";
		} else {
			price.text = "Price: 10,000";
			button.text = "Purchase";
		}
	}

	public void changeButton2(){
		box [2].SetBool ("go", true);
		box [1].SetBool ("go", false);
		box [0].SetBool ("go", false);
		selected = 2;
		pts.text = "" + PlayerPrefs.GetInt ("points") + " pts";
		if (PlayerPrefs.HasKey ("Black")) {
			if (PlayerPrefs.GetString ("current") == "Black")
				price.text = "Selected";
			else
				price.text = "Owned";
			button.text = "Select";
		} else {
			price.text = "Price: 1,000,000";
			button.text = "Purchase";
		}
	}

	public void mainMenuButton(){
		SceneManager.LoadScene ("MainMenu");
	}

}
