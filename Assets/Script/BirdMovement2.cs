using UnityEngine;
using System.Collections;

public class BirdMovement2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartTween ();
	}
	
	// Update is called once per frame

	public void StartTween() {
		Vector3 vec = transform.position;
		vec.x += 250;
		vec.y += 80;
		LTDescr des = LeanTween.move (gameObject, vec, 55f).setOnComplete(TweenOnComplete1);
		
	}
	
	void TweenOnComplete() {
		Vector3 vec = transform.position;
		vec.x += 500;
		vec.y += 80;
		LTDescr des = LeanTween.move (gameObject, vec, 110f).setOnComplete(TweenOnComplete1);
	}
	void TweenOnComplete1() {
		Vector3 vec = transform.position;
		vec.x -= 500;
		vec.y -= 80;
		transform.position = vec;
		TweenOnComplete ();
	}
	public void AniEvent(){

	}
}
