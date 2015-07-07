using UnityEngine;
using System.Collections;

public class GameUIScript : MonoBehaviour {

	// Use this for initialization
	AsyncOperation async;
	public Transform pause;
	public Transform stop;
	public Transform died;
	public bool isDied=false;
	// Update is called once per frame
	public AudioClip stopAudio;
	public AudioClip btnAudio;
	public AudioClip restartAudio;
	public Transform[] bgs=new Transform[6];

	//public Main main=new Main();
	public Vector3 v3=new Vector3(0,0,0);

	 void start(){
		if (Main.isMusicActivating) {
			foreach (Transform bg in bgs) {
				bg.GetComponent<AudioSource> ().Play ();
			}
		} else {
			foreach (Transform bg in bgs) {
				bg.GetComponent<AudioSource> ().Stop ();
			}
		}
	}
	public void OnStopButtonClick(){
		if(Main.isSoundActivating)
		AudioSource.PlayClipAtPoint (stopAudio, v3);
		pause.gameObject.SetActive (true);
		stop.gameObject.SetActive (false);
		//游戏暂停代码
		Time.timeScale = 0;
	}

	public void OnContinueButtonClick(){
		if(Main.isSoundActivating)
		AudioSource.PlayClipAtPoint (btnAudio, v3);
		pause.gameObject.SetActive (false);
		stop.gameObject.SetActive (true);
		print ("游戏继续代码");
		Time.timeScale = 1;

	}
	public void OnBackButtonClick(){
		if(Main.isSoundActivating)
		AudioSource.PlayClipAtPoint (btnAudio, v3);
		pause.gameObject.SetActive (false);
		stop.gameObject.SetActive (true);
		print ("游戏后退代码");//后退代码
		Application.LoadLevel ("StartMenu");
		Time.timeScale = 1;
	}
	public void OnRestartButtonClick(){
		if(Main.isSoundActivating)
		AudioSource.PlayClipAtPoint (restartAudio, v3);
		pause.gameObject.SetActive (false);
		stop.gameObject.SetActive (true);
		print ("游戏重新开始");
		Application.LoadLevel ("Game");
		//StartCoroutine (loadScene ("Game"));
		Time.timeScale = 1;
	}

	public void OnDiedBackButtonClick(){
		died.gameObject.SetActive (false);
		//回到菜单界面
		StartCoroutine (loadScene ("StarMenu"));
		Time.timeScale = 1;
	}
	public void OnDiedContinueButtonClick(){
		died.gameObject.SetActive (false);
		//开始游戏
		Application.LoadLevel ("Game");
		//StartCoroutine (loadScene ("Game"));
		Time.timeScale = 1;
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
	IEnumerator loadScene(string name)
	{

		async = Application.LoadLevelAsync(name);
		

		yield return async;
		
	}
}
