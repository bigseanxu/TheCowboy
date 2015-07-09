using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	float screenWidth = 1080;
	//public bool isLoop=true;
	void Start () {
		Invoke("StartTween", waitingTime);
		//StartTween ();
	}
	
	// Update is called once per frame

	public void StartTween() {
		//StartCoroutine(Test());

		if (isfirsttime) {
			vec = ((RectTransform)transform).anchoredPosition3D;
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
			des = LeanTween.move((RectTransform)transform, vec, moveTimeFirstAni).setLoopPingPong();
		} else {
			LeanTween.move ((RectTransform)transform, vec, moveTimeFirstAni);
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
		des = LeanTween.move ((RectTransform)transform, vec, moveTime).setOnComplete(TweenOnComplete1);

	}
	void TweenOnComplete1() {
		//Test ();
		Vector3 vec = vec2;
		vec.x -= moveX;
		vec.y -= moveY;
	//	vec.z -= moveZ;
		((RectTransform)transform).anchoredPosition3D = vec;
		TweenOnComplete ();
	}

	public IEnumerator Test(){
		yield return new WaitForSeconds(waitingTime);//等待x秒

	}

	void Update() {
		RectTransform rt = (RectTransform)transform;
		float alpha = 1;
		if (rt.anchoredPosition.x + rt.rect.width / 2.0f < - screenWidth / 2.0f) {
			alpha = 0;
		} else if (rt.anchoredPosition.x - rt.rect.width / 2.0f > screenWidth / 2.0f) {
			alpha = 0;
		} else if (rt.anchoredPosition.x - rt.rect.width / 2.0f < - screenWidth / 2.0f) {
			alpha = 1.0f - ((- screenWidth / 2.0f + rt.rect.width / 2.0f - rt.anchoredPosition.x) / rt.rect.width);
		} else if (rt.anchoredPosition.x + rt.rect.width / 2.0f > screenWidth / 2.0f) {
			alpha = (screenWidth / 2.0f + rt.rect.width / 2.0f - rt.anchoredPosition.x) / rt.rect.width;
		}
		GetComponent<Image> ().color = new Color (1, 1, 1, alpha);
	}
}
