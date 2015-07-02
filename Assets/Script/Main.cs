using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	//public Transform a;
	//设置界面
	public bool b=false;
	public AudioClip btnAudio;
	public Vector3 v3=new Vector3(0,0,0);
	public bool isSoundActivating=true;
	public bool isMusicActivating=true;
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
		if (isOff)
			isSoundActivating = false;
		else
			isSoundActivating = true;
	}
	public void MusicToggle(bool isOff){
		if(isSoundActivating)
			AudioSource.PlayClipAtPoint (btnAudio, v3);
		print (isOff);
		if (isOff)
			isMusicActivating = false;
		else
			isMusicActivating = true;

	}
	public void DeleteAdvert(){
		if(isSoundActivating)
			AudioSource.PlayClipAtPoint (btnAudio, v3);
		print ("DeleteAdvert");
	}

}
