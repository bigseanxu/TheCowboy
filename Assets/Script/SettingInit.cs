using UnityEngine;
using System.Collections;

public class SettingInit : MonoBehaviour {

	// Use this for initialization
	//这里是对设置界面的初始化位置设置.
	public float moveX=68f;
	public float moveXTime=0.0001f;
	void Start () {
		Vector3 vec = transform.position;
		Vector3 screenpos = Camera.main.ScreenToViewportPoint (transform.position);
		//print (screenpos);
		vec.x -= moveX;
		LeanTween.move ((RectTransform)transform, vec, moveXTime);
		//print (Screen.width);


	}
	
	// Update is called once per frame

}
