using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	// Use this for initialization
	//public Transform a;
	//设置界面
	AsyncOperation async;
	public bool b=false;
	public AudioClip btnAudio;
	bool firstTimeInit=false;
	public Transform loading;
	public Transform bg;
	public Transform railing;
	public Transform soundToggle;
	public Transform musicToggle;
	public Vector3 v3=new Vector3(0,0,0);
	public bool isSoundActivating=(Game.soundSwitch==1);
	public bool isMusicActivating=(Game.musicSwitch==1);

	void Start(){
		/*if (isMusicActivating) {
			bg.GetComponent<AudioSource> ().Play ();
		} else {
			if(bg.GetComponent<AudioSource> ().isPlaying)
			bg.GetComponent<AudioSource> ().Stop ();

		}
		if (isSoundActivating) {
			railing.GetComponent<AudioSource> ().Play ();
		} else {
			if(railing.GetComponent<AudioSource> ().isPlaying)
			railing.GetComponent<AudioSource> ().Stop ();
		}*/
		if (!Game.isGameInit ()) {
			Game.Initialize();
		}
		if (Game.soundSwitch == 1) {
			SoundToggle (false);
			soundToggle.GetComponent<Toggle>().isOn=false;
			railing.GetComponent<AudioSource> ().Play ();
		} else {
			SoundToggle (true);
			soundToggle.GetComponent<Toggle>().isOn=true;
			railing.GetComponent<AudioSource> ().Stop ();
		}
		if (Game.musicSwitch == 1) {
			MusicToggle (false);
			musicToggle.GetComponent<Toggle>().isOn=false;
			bg.GetComponent<AudioSource> ().Play();
		} else {

			MusicToggle(true);
			musicToggle.GetComponent<Toggle>().isOn=true;
			bg.GetComponent<AudioSource> ().Stop();
		}
		firstTimeInit = true;
	}

	public void OnSettingBtnClick(Transform a){


		Vector3 vec =((RectTransform)a.transform).anchoredPosition3D;
		if (!b) { 
			if(Game.soundSwitch==1)
				AudioSource.PlayClipAtPoint (btnAudio, v3);
			vec.x += 150f;
			print (vec);
			LeanTween.move ((RectTransform)a.transform, vec, 0.1f).setOnComplete (TweenOnCompleteTrue);
		} else {

			vec.x -= 150f;
			print (vec);
			LeanTween.move ((RectTransform)a.transform, vec, 0.1f).setOnComplete (TweenOnCompleteFalse);
		}
		
	}
	//设置界面的开关flag
	void TweenOnCompleteTrue() {
		b = true;

	}
	void TweenOnCompleteFalse() {
		b = false;
		
	}

	public void OnSettingBtnCloseClick(Transform a){

		if (b) {
			Vector3 vec =((RectTransform)a.transform).anchoredPosition3D;
			vec.x -= 150f;
			print (vec);
			LeanTween.move ((RectTransform)a.transform, vec, 0.1f);
			b=false;
		}
	}
	public void PlayGame(){
		if(Game.soundSwitch==1)
			AudioSource.PlayClipAtPoint (btnAudio, v3);
		print ("开始游戏");
		loading.gameObject.SetActive (true);
		//Application.LoadLevel ("Game");
		StartCoroutine(loadScene());

	}
	public void ShowGameCenter(){
		if(Game.soundSwitch==1)
			AudioSource.PlayClipAtPoint (btnAudio, v3);
		print ("打开游戏中心");
	}

	public void SoundToggle(bool isOff){
		if(Game.soundSwitch==1 && firstTimeInit)
			AudioSource.PlayClipAtPoint (btnAudio, v3);

		if (isOff) {
			//AudioSet.isSoundOn=false;
			Game.soundSwitch=0;

			isSoundActivating=false;
			railing.GetComponent<AudioSource> ().Stop ();
		} else {
			//AudioSet.isSoundOn=true;
			Game.soundSwitch=1;

			isSoundActivating=true;
			railing.GetComponent<AudioSource> ().Play ();
		}
		PlayerPrefs.SetInt ("SoundSwitch", Game.soundSwitch);
		print (Game.soundSwitch);
	}
	public void MusicToggle(bool isOff){
		if(Game.soundSwitch==1 && firstTimeInit)
			AudioSource.PlayClipAtPoint (btnAudio, v3);

		if (isOff) {
			//AudioSet.isMusicOn= false;
			Game.musicSwitch=0;

			isMusicActivating = false;
			bg.GetComponent<AudioSource> ().Stop ();

		} else {
			//AudioSet.isMusicOn= true;
			Game.musicSwitch=1;

			isMusicActivating =true;
			bg.GetComponent<AudioSource> ().Play ();

		}
		PlayerPrefs.SetInt ("MusicSwitch", Game.musicSwitch);
		print (Game.musicSwitch);

	}
	public void DeleteAdvert(){
		if(Game.soundSwitch==1)
			AudioSource.PlayClipAtPoint (btnAudio, v3);
		print ("DeleteAdvert");
	}

	IEnumerator loadScene()
	{
		//异步读取场景。
		async = Application.LoadLevelAsync("Game");
		yield return async;
		
	}

}
