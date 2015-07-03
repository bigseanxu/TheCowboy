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
	float mLayerWidth;
	float mLayerHeight;
	// Use this for initialization
	void Start () {
		mLayerWidth = mLayers.GetComponent<RectTransform> ().rect.width;
		mLayerHeight = mLayers.GetComponent<RectTransform> ().rect.height;
		ReorderLayers ();
//		Debug.Log ("width = " + mLayerWidth + Canvas.);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveLayer(MoveDirection dir) {
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

	void ReorderLayers() {
		Transform screens = transform.FindChild ("Screens");
		RectTransform [] faces = new RectTransform[6];
		faces [0] = (RectTransform)screens.FindChild ("Screen01");
		faces [1] = (RectTransform)screens.FindChild ("Screen02");
		faces [2] = (RectTransform)screens.FindChild ("Screen03");
		faces [3] = (RectTransform)screens.FindChild ("Screen04");
		faces [4] = (RectTransform)screens.FindChild ("Screen05");
		faces [5] = (RectTransform)screens.FindChild ("Screen06");

		Game.GameScreens screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceB);
		faces [(int)screen].anchoredPosition = new Vector2 (0, 0);
		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceL);
		faces [(int)screen].anchoredPosition = new Vector2 (-mLayerWidth, 0);
		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceR);
		faces [(int)screen].anchoredPosition = new Vector2 (mLayerWidth, 0);
		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceU);
		faces [(int)screen].anchoredPosition = new Vector2 (0, mLayerHeight);
		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceD);
		faces [(int)screen].anchoredPosition = new Vector2 (0, -mLayerHeight);
		screen = mCubeIndicator.GetComponent<CubeIndicator> ().GetScreenAfterRotate (Game.CubeFaces.FaceF);
		faces [(int)screen].anchoredPosition = new Vector2 (mLayerWidth, mLayerHeight);
	}

}
