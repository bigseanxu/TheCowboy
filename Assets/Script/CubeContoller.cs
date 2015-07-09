using UnityEngine;
using System.Collections;

public class CubeContoller : MonoBehaviour {

	public enum RotateDirection {
		Left,
		Right,
		Up,
		Down
	};
	//public Transform wind;
	//public Transform camera3d;
	public Transform[] things = new Transform[6];
	public float mRotateTime = 0.5f;
	public Transform mCubeIndicator;
	public Transform mCanvas;
	public Texture2D[] mTextures = new Texture2D[6];
	public Vector2 mCowboyRect;
	public Vector2 mScreenRect;
	public float mCubeSize;
	public Transform mCamera;
	public float mCowboyOffsetY;
	Vector2 mActualCowboyRect;
	float mActualCubeSize;
	bool isRotating = false;
	Transform [] faces;
	int isOn;
	int isOnSound;
	//Movement[] movs;
	public Transform[] mCowboys = new Transform[6];
	// Use this for initialization
	void Start () {


		float aspect = Screen.width / mScreenRect.x;
		mActualCowboyRect.x = aspect * mCowboyRect.x;
		mActualCowboyRect.y = aspect * mCowboyRect.y;

		float cameraZ = (Screen.height / mActualCowboyRect.y * mCubeSize + mCubeSize) / 2.0f;
		mCamera.transform.position = new Vector3 (0, 0, cameraZ);

		float actualCowboyOffset = mCowboyOffsetY /  mScreenRect.y * (mScreenRect.y / mScreenRect.x * Screen.width) ;
		float mCubeOffsetY = (actualCowboyOffset / Screen.height * 2.0f * (cameraZ - 200.0f));
		Vector3 newPosition = transform.position;
		newPosition.y = mCubeOffsetY;
		transform.position = newPosition;

		Debug.Log ("screenheight = " + Screen.height + " cowboy size = " + mActualCowboyRect.y);

		faces = new Transform[6];
		faces [0] = transform.FindChild ("FaceB");
		faces [1] = transform.FindChild ("FaceR");
		faces [2] = transform.FindChild ("FaceL");
		faces [3] = transform.FindChild ("FaceU");
		faces [4] = transform.FindChild ("FaceD");
		faces [5] = transform.FindChild ("FaceF");

		faces [0].transform.SetSiblingIndex(6);

		OnTweenComplete ();
		isOn = Game.musicSwitch ;
		isOnSound = Game.soundSwitch;
	}
	
	// Update is called once per frame
	void Update () {
		//CheckRotate ();
	}

	public void Rotate90WithTween(RotateDirection dir) {
		isRotating = true;
		//LeanTween.cancelAll (false);
		//LeanTween.reset ();
		//LeanTween.pauseAll();
//		Game.musicSwitch=0;
		foreach (Transform thing in things) {
			thing.gameObject.SetActive(true);
			thing.GetComponentInChildren<AudioSource>().volume=0;
		}
		gameObject.SetActive (true);

			//CheckRotate();
			HideCowboys ();
			if (dir == RotateDirection.Left) {
				LeanTween.rotateAround (gameObject, Vector3.up, 90, mRotateTime).setEase (LeanTweenType.linear).setOnComplete (OnTweenComplete);
				LeanTween.rotateAround (mCubeIndicator.parent.gameObject, Vector3.up, 90, 0.01f);
			} else if (dir == RotateDirection.Right) {
				LeanTween.rotateAround (gameObject, Vector3.up, -90, mRotateTime).setEase (LeanTweenType.linear).setOnComplete (OnTweenComplete);
				LeanTween.rotateAround (mCubeIndicator.parent.gameObject, Vector3.up, -90, 0.01f);
			} else if (dir == RotateDirection.Up) {
				LeanTween.rotateAround (gameObject, Vector3.left, 90, mRotateTime).setEase (LeanTweenType.linear).setOnComplete (OnTweenComplete);
				LeanTween.rotateAround (mCubeIndicator.parent.gameObject, Vector3.right, 90, 0.01f);
			} else if (dir == RotateDirection.Down) {
				LeanTween.rotateAround (gameObject, Vector3.left, -90, mRotateTime).setEase (LeanTweenType.linear).setOnComplete (OnTweenComplete);
				LeanTween.rotateAround (mCubeIndicator.parent.gameObject, Vector3.right, -90, 0.01f);
			} else {
				// do nothing
			}


	}
	void RepackTheCube() {
		for (int i = 0;i < 6; i++) {
			Game.GameScreens screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate ((Game.CubeFaces)i);
			faces[i].GetComponent<MeshRenderer>().material.mainTexture = mTextures[(int)screen];
		}

	}

	void OnTweenComplete() {
		Game.currScore += 1;
		//Game.musicSwitch=isOn;
		isRotating = false;
	//	CheckRotate();
		transform.rotation = new Quaternion ();
		RepackTheCube ();
		ShowCowboys ();
		//HideInactiveScreens()
		gameObject.SetActive (false);
	}
		//faces [(int)Game.CubeFaces.FaceB].GetComponent<MeshRenderer> ().material.mainTexture = null;

	void HideInactiveScreens() {
		Game.GameScreens screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceB);
		for (int i = 0; i < 6; i++) {
			if ((int)screen == i) {
				things [i].gameObject.SetActive (true);
			} else {
				things [i].gameObject.SetActive (false);
			}
		}
	}


	public bool IsRotating() {
		return isRotating;
	}

	void HideCowboys() {
		foreach (Transform c in mCowboys) {
			c.gameObject.SetActive(false);
		}
	}

	void ShowCowboys() {
		foreach (Transform c in mCowboys) {
			c.gameObject.SetActive(true);
		}
	}

}
