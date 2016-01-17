using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {
	float scaleToEdit = 2;

	// Use this for initialization
	void Start () {
		Vector3 scale = transform.localScale;
		transform.localScale = new Vector3(
			scale.x == scaleToEdit ? scaleToEdit*0.9f : scale.x,
			scale.y == scaleToEdit ? scaleToEdit*0.9f : scale.y,
			scale.z == scaleToEdit ? scaleToEdit*0.9f : scale.z);
	}

}
