using UnityEngine;
using System.Collections;

public class CubeIndicator : MonoBehaviour {
	Transform [] faces = new Transform[6];
	Vector3 [] normals = new Vector3[6];
	bool isInitNormal = false;
	// Use this for initialization
	void Start () {
		faces [0] = transform.FindChild ("FaceB");
		faces [1] = transform.FindChild ("FaceR");
		faces [2] = transform.FindChild ("FaceL");
		faces [3] = transform.FindChild ("FaceU");
		faces [4] = transform.FindChild ("FaceD");
		faces [5] = transform.FindChild ("FaceF");
		if (!isInitNormal) {
			InitNormals();
		}
	}

	void InitNormals() {
		normals [0] = new Vector3 (0, 0, 1);
		normals [1] = new Vector3 (-1, 0, 0);
		normals [2] = new Vector3 (1, 0, 0);
		normals [3] = new Vector3 (0, 1, 0);
		normals [4] = new Vector3 (0, -1, 0);
		normals [5] = new Vector3 (0, 0, -1);
	}

	// Update is called once per frame
	void Update () {
	
	}

	public Game.GameScreens GetScreenAfterRotate(Game.CubeFaces face) {
		if (!isInitNormal) {
			InitNormals();
		}
		Vector3 rotatedNormal = new Vector3();  
		int f = 0;
		for (int i = 0; i < 6; i++) {
			rotatedNormal = transform.parent.localToWorldMatrix * normals[i];
//			Debug.Log("face" + i + " = " + rotatedNormal.ToString);
			if ( rotatedNormal == normals[(int)face]) {
				f = i;
				break;
			}
		}
		
//		Debug.Log (f.ToString());
		return (Game.GameScreens) f;
	}
}
