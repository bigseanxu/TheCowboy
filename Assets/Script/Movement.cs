using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
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
	//public bool isLoop=true;
	void Start () {
		Invoke("StartTween", waitingTime);
		//StartTween ();
	}
	
	// Update is called once per frame

	void StartTween() {
		//StartCoroutine(Test());
		Vector3 vec = transform.position;
		vec.x += moveXFirst;
		vec.y += moveYFirst;
	//	vec.z += moveZFirst;
		if (isLoopFirst) {
			LTDescr des = LeanTween.move (gameObject, vec, moveTimeFirstAni).setOnComplete (TweenOnComplete1);
		} else {
			LeanTween.move (gameObject, vec, moveTimeFirstAni);
		}
		
	}
	
	void TweenOnComplete() {

		Vector3 vec = transform.position;
		vec.x += moveX;
		vec.y += moveY;
	//	vec.z += moveZ;
		LTDescr des = LeanTween.move (gameObject, vec, moveTime).setOnComplete(TweenOnComplete1);
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

}
