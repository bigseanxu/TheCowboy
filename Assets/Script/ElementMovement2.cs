using UnityEngine;
using System.Collections;

public class ElementMovement2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartTween ();
	}
	
	// Update is called once per frame
	
	
	public void StartTween() {
		Vector3 vec = transform.position;
		vec.x -= 700;
		LTDescr des = LeanTween.move (gameObject, vec, 21).setOnComplete(TweenOnComplete);
		
	}
	
	void TweenOnComplete() {
		Vector3 vec = transform.position;
		vec.x += 700;
		transform.position = vec;
		StartTween ();
	}
}
