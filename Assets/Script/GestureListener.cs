using UnityEngine;
using System.Collections;

public class GestureListener : MonoBehaviour {

	public Transform cube;
	public Transform mCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnSwipe(SwipeGesture gesture) {
		if (cube.GetComponent<CubeContoller> ().IsRotating ()) {
			return;
		}

		if (gesture.Direction == FingerGestures.SwipeDirection.Left) {
			cube.GetComponent<CubeContoller>().Rotate90WithTween(CubeContoller.RotateDirection.Left);
			mCanvas.GetComponent<CanvasController>().MoveLayer(CanvasController.MoveDirection.Left);
		} else if (gesture.Direction == FingerGestures.SwipeDirection.Right) {
			cube.GetComponent<CubeContoller>().Rotate90WithTween(CubeContoller.RotateDirection.Right);
			mCanvas.GetComponent<CanvasController>().MoveLayer(CanvasController.MoveDirection.Right);
		} else if (gesture.Direction == FingerGestures.SwipeDirection.Up) {
			cube.GetComponent<CubeContoller>().Rotate90WithTween(CubeContoller.RotateDirection.Up);
			mCanvas.GetComponent<CanvasController>().MoveLayer(CanvasController.MoveDirection.Up);
		} else if (gesture.Direction == FingerGestures.SwipeDirection.Down) {
			cube.GetComponent<CubeContoller>().Rotate90WithTween(CubeContoller.RotateDirection.Down);
			mCanvas.GetComponent<CanvasController>().MoveLayer(CanvasController.MoveDirection.Down);
		} else {
			// do nothing
		}
	}
}
