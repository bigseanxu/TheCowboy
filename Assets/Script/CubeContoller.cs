﻿using UnityEngine;
using System.Collections;

public class CubeContoller : MonoBehaviour {

	public enum RotateDirection {
		Left,
		Right,
		Up,
		Down
	};

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
	
	// Use this for initialization
	void Start () {
		float aspect = Screen.width / mScreenRect.x;
		mActualCowboyRect.x = aspect * mCowboyRect.x;
		mActualCowboyRect.y = aspect * mCowboyRect.y;

		float cameraZ = (Screen.height / mActualCowboyRect.y * mCubeSize + mCubeSize) / 2.0f;
		mCamera.transform.position = new Vector3 (0, 0, cameraZ);

		float mCubeOffsetY = mCowboyOffsetY / mScreenRect.y * 2.0f * (cameraZ - 200.0f);
		Vector3 newPosition = transform.position;
		newPosition.y = mCubeOffsetY;
		transform.position = newPosition;

		Debug.Log ("screenheight = " + Screen.height + " cowboy size = " + mActualCowboyRect.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Rotate90WithTween(RotateDirection dir) {
		isRotating = true;
		if (dir == RotateDirection.Left) {
			LeanTween.rotateAround(gameObject, Vector3.up, 90, mRotateTime).setEase(LeanTweenType.linear).setOnComplete(OnTweenComplete);
			LeanTween.rotateAround(mCubeIndicator.parent.gameObject, Vector3.up, 90, 0.01f);
		} else if (dir == RotateDirection.Right) {
			LeanTween.rotateAround(gameObject, Vector3.up, -90, mRotateTime).setEase(LeanTweenType.linear).setOnComplete(OnTweenComplete);
			LeanTween.rotateAround(mCubeIndicator.parent.gameObject, Vector3.up, -90, 0.01f);
		} else if (dir == RotateDirection.Up) {
			LeanTween.rotateAround(gameObject, Vector3.right, 90, mRotateTime).setEase(LeanTweenType.linear).setOnComplete(OnTweenComplete);
			LeanTween.rotateAround(mCubeIndicator.parent.gameObject, Vector3.right, 90, 0.01f);
		} else if (dir == RotateDirection.Down) {
			LeanTween.rotateAround(gameObject, Vector3.right, -90, mRotateTime).setEase(LeanTweenType.linear).setOnComplete(OnTweenComplete);
			LeanTween.rotateAround(mCubeIndicator.parent.gameObject, Vector3.right, -90, 0.01f);
		} else {
			// do nothing
		}
	}

	void RepackTheCube() {
		Transform [] faces = new Transform[5];
		faces [0] = transform.FindChild ("FaceB");
		faces [1] = transform.FindChild ("FaceR");
		faces [2] = transform.FindChild ("FaceL");
		faces [3] = transform.FindChild ("FaceU");
		faces [4] = transform.FindChild ("FaceD");

		for (int i = 0; i < 5; i++) {
			Game.GameScreens screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate ((Game.CubeFaces)i);
			faces[i].GetComponent<MeshRenderer>().material.mainTexture = mTextures[(int)screen];
		}

	}

	void OnTweenComplete() {
		isRotating = false;
		transform.rotation = new Quaternion ();
		RepackTheCube ();
	}

	public bool IsRotating() {
		return isRotating;
	}
}
