using UnityEngine;
using System.Collections;

public class ScreenController : MonoBehaviour {

	 public bool isFront=true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//print (isFront);
	}

	public void SetAsFront (bool front) {
		isFront = front;
		Movement[] movs = gameObject.GetComponentsInChildren<Movement> ();
		foreach (Movement mov in movs) {
			if(mov.des!=null){
				mov.des.toggle=isFront;
				//print(front);
			}
		}
	}
}
