using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	//public Transform a;
	//设置界面
	public bool b=false;
	public void OnSettingBtnClick(Transform a){
		Vector3 vec = a.transform.position;
		if (!b) {

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
		print ("开始游戏");
	}
	public void ShowGameCenter(){
		print ("打开游戏中心");
	}

	public void SoundToggle(bool isOff){
		print (isOff);
	}
	public void MusicToggle(bool isOff){
		print (isOff);
	}
	public void DeleteAdvert(){
		print ("DeleteAdvert");
	}

}
