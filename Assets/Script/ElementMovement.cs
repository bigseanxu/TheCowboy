using UnityEngine;
using System.Collections;


public class ElementMovement : MonoBehaviour {


	// Use this for initialization
	void Start () {
		StartTween ();
	}
	
	// Update is called once per frame


	public void StartTween() {
		Vector3 vec = transform.position;
		vec.x -= 800;
		LTDescr des = LeanTween.move (gameObject, vec, 32).setOnComplete(TweenOnComplete);

	}

	void TweenOnComplete() {
		Vector3 vec = transform.position;
		vec.x += 800;
		transform.position = vec;
		StartTween ();
	}
}
