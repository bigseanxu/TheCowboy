using UnityEngine;
using System.Collections;

public class ScreenController : MonoBehaviour {

	 //public bool isFront=true;
	public Transform bg;
	public Transform sub;
	public Transform walk;
	//public bool isMusicOn=AudioSet.isMusicOn;
	// Use this for initialization
	void Start () {

		print (Game.musicSwitch);
	}
	
	// Update is called once per frame
	void Update () {

		print (Game.musicSwitch);

		if (Game.musicSwitch==1) {
				
			bg.GetComponent<AudioSource> ().enabled=true;
			bg.GetComponent<AudioSource> ().volume=1;

		}else {
			bg.GetComponent<AudioSource> ().enabled=false;
				

		}

		if (Game.soundSwitch==1 ) {

			if(sub!=null){
				sub.GetComponent<AudioSource> ().enabled = true;
				sub.GetComponent<AudioSource> ().volume = 1;
			}
				walk.GetComponent<AudioSource> ().enabled = true;
				walk.GetComponent<AudioSource> ().volume = 1;
				
		}
		 else{
			if(sub!=null){
			sub.GetComponent<AudioSource> ().enabled = false;
			}
			walk.GetComponent<AudioSource> ().enabled = false;
		}
	}



}
