using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class LoseManager : MonoBehaviour {

	private RewardBasedVideoAd reward;

	public void Start (){
		reward = RewardBasedVideoAd.Instance;
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-9384445987292667/6653506758";
		#elif UNITY_IPHONE
		string adUnitId = "";
		#else 
		string adUnitId = "Unexpected Platform"
		#endif

		reward.LoadAd (new AdRequest.Builder().Build(), adUnitId);

		if (reward.IsLoaded())
			reward.Show ();
		else
			MonoBehaviour.print ("add not loaded");
	}

	public void ButtonPressed(){
		SceneManager.LoadScene ("MainMenu");
	}
}
