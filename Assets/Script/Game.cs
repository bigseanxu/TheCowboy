using UnityEngine;
using System.Collections;

public static class Game
{
	public enum GameScreens {
		Screen01,
		Screen02,
		Screen03,
		Screen04,
		Screen05,
		Screen06,
	};

	public enum CubeFaces {
		FaceB,
		FaceR,
		FaceL,
		FaceU,
		FaceD,
		FaceF,
	};

	// need to save
	public static int bestScore = 0;
	public static int musicSwitch = 0;
	public static int soundSwitch = 0;

	// do not need to save
	public static int currScore = 0;
	static bool isInit = false;

	public static void Initialize() {
		LoadPrefs ();
		isInit = true;
	}

	static void LoadPrefs() {
		bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		musicSwitch = PlayerPrefs.GetInt ("MusicSwitch", 1);
		soundSwitch = PlayerPrefs.GetInt ("SoundSwitch", 1);
	}

	public static bool isGameInit() {
		return isInit;
	}

	public static void SavePrefs() {
		PlayerPrefs.SetInt ("BestScore", bestScore);
		PlayerPrefs.SetInt ("MusicSwitch", musicSwitch);
		PlayerPrefs.SetInt ("SoundSwitch", soundSwitch);
	}
}