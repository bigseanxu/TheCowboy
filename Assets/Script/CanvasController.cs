using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {
	public enum MoveDirection {
		Left,
		Right,
		Up,
		Down
	};

	public Transform mCubeIndicator;
	public RectTransform mLayers;
	public float mMoveTime;
	RectTransform [] faces = new RectTransform[6];
	float mLayerWidth;
	float mLayerHeight;
	// Use this for initialization
	void Start () {
		mLayerWidth = mLayers.GetComponent<RectTransform> ().rect.width;
		mLayerHeight = mLayers.GetComponent<RectTransform> ().rect.height;

		Transform screens = transform.FindChild ("Screens");
		faces [0] = (RectTransform)screens.FindChild ("Screen01");
		faces [1] = (RectTransform)screens.FindChild ("Screen02");
		faces [2] = (RectTransform)screens.FindChild ("Screen03");
		faces [3] = (RectTransform)screens.FindChild ("Screen04");
		faces [4] = (RectTransform)screens.FindChild ("Screen05");
		faces [5] = (RectTransform)screens.FindChild ("Screen06");
		
		ReorderLayers ();
//		Debug.Log ("width = " + mLayerWidth + Canvas.);
	}
	
	// Update is called once per frame 
	void Update () {
	
	}

	public void MoveLayer(MoveDirection dir) {

		// disable all screen in this moment;
		InactivateAllScreens ();

		//mLayers.SetSiblingIndex(999);
		if (dir == MoveDirection.Left) {

			LeanTween.move(mLayers, new Vector2(-mLayerWidth, 0), mMoveTime).setOnComplete(OnTweenComplete);
		} else if (dir == MoveDirection.Right) {
			LeanTween.move(mLayers, new Vector2(mLayerWidth, 0), mMoveTime).setOnComplete(OnTweenComplete);
		} else if (dir == MoveDirection.Up) {
			LeanTween.move(mLayers, new Vector2(0, mLayerHeight), mMoveTime).setOnComplete(OnTweenComplete);
		} else if (dir == MoveDirection.Down) {
			LeanTween.move(mLayers, new Vector2(0, -mLayerHeight), mMoveTime).setOnComplete(OnTweenComplete);
		} else {
			// do nothing
		}
	}

	void OnTweenComplete() {
		mLayers.anchoredPosition = new Vector2 (0, 0);
		ReorderLayers ();
	}

	void InactivateAllScreens() {
		foreach (RectTransform t in faces) {
			t.GetComponent<ScreenController> ().SetActive (false);
		}
	}

	void ReorderLayers() {

		Game.GameScreens screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceB);
		//faces [(int)screen].SetSiblingIndex (999);
		faces [(int)screen].anchoredPosition = new Vector2 (0, 0);
		faces [(int)screen].GetComponent<ScreenController> ().SetActive (true);
		faces [(int)screen].SetSiblingIndex (5);

		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceL);
		faces [(int)screen].anchoredPosition = new Vector2 (-mLayerWidth, 0);
		faces [(int)screen].GetComponent<ScreenController> ().SetActive (false);

		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceR);
		faces [(int)screen].anchoredPosition = new Vector2 (mLayerWidth, 0);
		faces [(int)screen].GetComponent<ScreenController> ().SetActive (false);

		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceU);
		faces [(int)screen].anchoredPosition = new Vector2 (0, mLayerHeight);
		faces [(int)screen].GetComponent<ScreenController> ().SetActive (false);

		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceD);
		faces [(int)screen].anchoredPosition = new Vector2 (0, -mLayerHeight);
		faces [(int)screen].GetComponent<ScreenController> ().SetActive (false);

		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceF);
		faces [(int)screen].anchoredPosition = new Vector2 (mLayerWidth, mLayerHeight);
		faces [(int)screen].GetComponent<ScreenController> ().SetActive (false);
	}

}
