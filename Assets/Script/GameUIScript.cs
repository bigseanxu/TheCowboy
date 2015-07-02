using UnityEngine;
using System.Collections;

public class GameUIScript : MonoBehaviour {

	// Use this for initialization

	public Transform pause;
	public Transform stop;
	public Transform died;
	public bool isDied=false;
	// Update is called once per frame
	public AudioClip stopAudio;
	public AudioClip btnAudio;
	public AudioClip restartAudio;
	//public Main main=new Main();
	public Vector3 v3=new Vector3(0,0,0);

	public void OnStopButtonClick(){
		if(new Main().isSoundActivating)
		AudioSource.PlayClipAtPoint (stopAudio, v3);
		pause.gameObject.SetActive (true);
		stop.gameObject.SetActive (false);
		//游戏暂停代码
	}

	public void OnContinueButtonClick(){
		if(new Main().isSoundActivating)
		AudioSource.PlayClipAtPoint (btnAudio, v3);
		pause.gameObject.SetActive (false);
		stop.gameObject.SetActive (true);
		print ("游戏继续代码");
	}
	public void OnBackButtonClick(){
		if(new Main().isSoundActivating)
		AudioSource.PlayClipAtPoint (btnAudio, v3);
		pause.gameObject.SetActive (false);
		stop.gameObject.SetActive (true);
		print ("游戏后退代码");//后退代码
	}
	public void OnRestartButtonClick(){
		if(new Main().isSoundActivating)
		AudioSource.PlayClipAtPoint (restartAudio, v3);
		pause.gameObject.SetActive (false);
		stop.gameObject.SetActive (true);
		print ("游戏重新开始");
	}

	public void OnDiedBackButtonClick(){
		died.gameObject.SetActive (false);
		//回到菜单界面
	}
	public void OnDiedContinueButtonClick(){
		died.gameObject.SetActive (false);
		//开始游戏
	}
	public void OnDiedFacebookButtonClick(){

		//facebook
	}
	public void OnDiedTwitterButtonClick(){

		//twitter
	}
	public void CheckDiedOrAlive(){
		if (isDied) {
			died.gameObject.SetActive (true);
		}
	}

}
