﻿using UnityEngine;
using System.Collections;

public class GameEntrance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!Game.isGameInit ()) {
			Game.Initialize();
		}
		Game.musicSwitch = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
