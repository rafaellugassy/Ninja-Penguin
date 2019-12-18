using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

	public Text text;
	private int curMessage = 0;
	private int curCharMessage = 0;
	private int charDelay = 5;
	private int curFrame = 0;
	private int dots = 0;
	private int dotDelay = 30;
	bool messageDone = false;
	public Animator anim;
	public Animator textPenguinAnim;
	private bool startAnim = false;
	private string[] messages = {"Hello, Welcome to Ninja Penguin!", 
		"The objective of the game is to help your character, Penguin, defeat foes in order to save the Arctic!",
		"Animals of the Arctic are being controlled by an evil power to stop you at all costs..!",
		"To defeat enemies, you have to react quickly, when prompted to attack!",
		"Be sure to not tap the screen too early OR too late, doing this will cause Penguin to be defeated!!",
		"Now to show an example"};

	public void ExitButton(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void SkipText(){
		if (messageDone) {
			text.text = "";
			curMessage++;
			messageDone = false;
			if (curMessage >= messages.Length) {
				startAnim = true;
				textPenguinAnim.SetBool ("Exit", true);
			}
		} else {
			messageDone = true;
			text.text = messages [curMessage];
			curCharMessage = 0;
		}
			
	}

	// Update is called once per frame
	void Update () {
		curFrame++;
		if (startAnim) {
			anim.SetTrigger ("start");
		} else if (messageDone) {
			if (curFrame % dotDelay == 0) {
				if (dots != 3) {
					text.text = text.text + '.';
					dots++;
				} else {
					dots = 0;
					text.text = messages [curMessage];
				}
			}
		} else if (curFrame % charDelay == 0) {
			text.text = text.text + messages [curMessage] [curCharMessage];

			curCharMessage = curCharMessage + 1 == messages [curMessage].Length ? 0 : curCharMessage + 1;
			if (curCharMessage == 0) {
				messageDone = true;
			}
		}
			

	}
}
