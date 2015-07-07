﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	public Transform mCubeIndicator;
	public Transform[] screens=new Transform[6];
	public float moveX=500;
	public float moveXFirst=250;
	public float moveY=80;
	public float moveYFirst=40;
//	public float moveZ=0;
//	public float moveZFirst=0;
	//public float moveLengthz;
	public float moveTime=120;
	public float moveTimeFirstAni=60;
	public bool isLoopFirst=true;
	public float waitingTime=0;
	public LTDescr des;
	bool isfirsttime=true;
	Vector3 vec;
	Vector3 vec2;
	//public bool isLoop=true;
	void Start () {
		Invoke("StartTween", waitingTime);
		//StartTween ();
	}
	
	// Update is called once per frame

	public void StartTween() {
		//StartCoroutine(Test());

		if (isfirsttime) {
			vec = transform.position;
			vec2 = vec;
			isfirsttime = false;
		} else {
			vec=vec2;
		}
		//vec = transform.position;
		vec.x += moveXFirst;
		vec.y += moveYFirst;
	//	vec.z += moveZFirst;
		if (isLoopFirst) {
			 des = LeanTween.move(gameObject, vec, moveTimeFirstAni).setOnComplete (TweenOnComplete1);
		} else {
			LeanTween.move (gameObject, vec, moveTimeFirstAni);
		}
		
	}
	public void StopTween(){
		LeanTween.cancel (gameObject);
	}
	void TweenOnComplete() {

		Vector3 vec = transform.position;
		vec.x += moveX;
		vec.y += moveY;
	//	vec.z += moveZ;
		des = LeanTween.move (gameObject, vec, moveTime).setOnComplete(TweenOnComplete1);

	}
	void TweenOnComplete1() {
		//Test ();
		Vector3 vec = transform.position;
		vec.x -= moveX;
		vec.y -= moveY;
	//	vec.z -= moveZ;
		transform.position = vec;
		TweenOnComplete ();
	}
	public IEnumerator Test(){
		yield return new WaitForSeconds(waitingTime);//等待x秒

	}

	public void EnableAnimation() {
		des.toggle = true;
	}

	public void DisableAnimation() {
		des.toggle = false;
	}



}
