using UnityEngine;
using System.Collections;

public class GameUIScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public Transform pause;
	public Transform stop;
	public Transform died;
	// Update is called once per frame

	public void OnStopButtonClick(){

		pause.gameObject.SetActive (true);
		stop.gameObject.SetActive (false);
		//游戏暂停代码
	}

	public void OnContinueButtonClick(){
		pause.gameObject.SetActive (false);
		stop.gameObject.SetActive (true);
		print ("游戏继续代码");
	}
	public void OnBackButtonClick(){
		pause.gameObject.SetActive (false);
		stop.gameObject.SetActive (true);
		print ("游戏后退代码");//后退代码
	}
	public void OnRestartButtonClick(){
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


}
