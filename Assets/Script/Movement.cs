using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	public float moveX=500;
	public float moveXFirst=250;
	public float moveY=80;
	public float moveYFirst=40;
	//public float moveLengthz;
	public float moveTime=120;
	public float moveTimeFirstAni=60;
	void Start () {
		StartTween ();
	}
	
	// Update is called once per frame

	void StartTween() {
		Vector3 vec = transform.position;
		vec.x += moveXFirst;
		vec.y +=moveYFirst;
		LTDescr des = LeanTween.move (gameObject, vec, moveTimeFirstAni).setOnComplete(TweenOnComplete1);
		
	}
	
	void TweenOnComplete() {
		Vector3 vec = transform.position;
		vec.x += moveX;
		vec.y += moveY;
		LTDescr des = LeanTween.move (gameObject, vec, moveTime).setOnComplete(TweenOnComplete1);
	}
	void TweenOnComplete1() {
		Vector3 vec = transform.position;
		vec.x -= moveX;
		vec.y -= moveY;
		transform.position = vec;
		TweenOnComplete ();
	}

}
