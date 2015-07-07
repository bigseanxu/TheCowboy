using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	//public Transform a;
	//设置界面
	AsyncOperation async;
	public bool b=false;
	public AudioClip btnAudio;

	public Transform loading;
	public Transform bg;
	public Transform railing;
	public Transform soundToggle;
	public Transform musicToggle;
	public Vector3 v3=new Vector3(0,0,0);
	public static bool isSoundActivating=true;
	public static bool isMusicActivating=true;

	void Start(){
		if (isMusicActivating) {
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
		}
	}

	public void OnSettingBtnClick(Transform a){

		Vector3 vec = a.transform.position;
		if (!b) { 
			if(isSoundActivating)
				AudioSource.PlayClipAtPoint (btnAudio, v3);
			vec.x += 68f;
			print (vec);
			LeanTween.move (a.gameObject, vec, 0.1f).setOnComplete (TweenOnCompleteTrue);
		} else {

			vec.x -= 68f;
			print (vec);
			LeanTween.move (a.gameObject, vec, 0.1f).setOnComplete (TweenOnCompleteFalse);
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
			Vector3 vec = a.transform.position;
			vec.x -= 68f;
			print (vec);
			LeanTween.move (a.gameObject, vec, 0.1f);
			b=false;
		}
	}
	public void PlayGame(){
		if(isSoundActivating)
			AudioSource.PlayClipAtPoint (btnAudio, v3);
		print ("开始游戏");
		loading.gameObject.SetActive (true);
		//Application.LoadLevel ("Game");
		StartCoroutine(loadScene());

	}
	public void ShowGameCenter(){
		if(isSoundActivating)
			AudioSource.PlayClipAtPoint (btnAudio, v3);
		print ("打开游戏中心");
	}

	public void SoundToggle(bool isOff){
		if(isSoundActivating)
			AudioSource.PlayClipAtPoint (btnAudio, v3);
		print (isOff);
		if (isOff) {
			isSoundActivating = false;
			GameUIScript.isSoundActivating=false;
			railing.GetComponent<AudioSource> ().Stop ();
		} else {
			isSoundActivating = true;
			GameUIScript.isSoundActivating=true;
			railing.GetComponent<AudioSource> ().Play ();
		}
	}
	public void MusicToggle(bool isOff){
		if(isSoundActivating)
			AudioSource.PlayClipAtPoint (btnAudio, v3);
		print (isOff);
		if (isOff) {
			isMusicActivating = false;
			GameUIScript.isMusicActivating = false;
			bg.GetComponent<AudioSource> ().Stop ();

		} else {
			isMusicActivating = true;
			GameUIScript.isMusicActivating =true;
			bg.GetComponent<AudioSource> ().Play ();

		}

	}
	public void DeleteAdvert(){
		if(isSoundActivating)
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
