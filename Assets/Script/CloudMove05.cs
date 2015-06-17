using UnityEngine;
using System.Collections;

public class CloudMove05 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartTween ();
	}
	
	// Update is called once per frame
	public void StartTween() {
		Vector3 vec = transform.position;
		vec.x += 300;

		LTDescr des = LeanTween.move (gameObject, vec, 16).setOnComplete(TweenOnComplete1);
		
	}
	
	void TweenOnComplete() {
		Vector3 vec = transform.position;
		vec.x += 600;

		LTDescr des = LeanTween.move (gameObject, vec, 32).setOnComplete(TweenOnComplete1);
	}
	void TweenOnComplete1() {
		Vector3 vec = transform.position;
		vec.x -= 600;

		transform.position = vec;
		TweenOnComplete ();
	}
}
