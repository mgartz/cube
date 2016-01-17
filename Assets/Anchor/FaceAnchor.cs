using UnityEngine;
using System.Collections;

public class FaceAnchor : MonoBehaviour {

	public bool isRotating;
	float rotationProgress;
	Quaternion rotationOrig;
	Quaternion rotationTarget;

	Transform[] cubes;
	Transform sphere;

	// Update is called once per frame
	void Update () {
		UpdateRotation();
	}

	public void StartFaceRotation(Transform[] cubes, Transform sphere, BadassCube.Face face, int col, int dir){
		if (!isRotating){
			this.sphere = sphere;
			this.cubes = cubes;
			isRotating = true;
			
			rotationOrig = Quaternion.Euler(0,0,0);
			rotationProgress = 0;
			
			transform.rotation = rotationOrig;
			
			if (face == BadassCube.Face.Left){
				rotationTarget = Quaternion.Euler(90*dir,0,0);
				int targetX = (col-1)*2;
				foreach (Transform cube in cubes)
					if (Mathf.Abs(cube.position.x - targetX) < 1.6f)
						cube.parent = transform;
				if (Mathf.Abs(sphere.position.x - targetX) < 1)
					sphere.parent = transform;
			}
			else if (face == BadassCube.Face.Right){
				rotationTarget = Quaternion.Euler(0,0,90*dir);
				int targetZ = (col-1)*2;
				foreach (Transform cube in cubes)
					if (Mathf.Abs(cube.position.z - targetZ) < 1.6f)
						cube.parent = transform;
				if (Mathf.Abs(sphere.position.z - targetZ) < 1)
					sphere.parent = transform;
			}
		}
	}

	void UpdateRotation(){
		if (isRotating){
			rotationProgress += Global.rotationSpeed * Time.deltaTime;
			rotationProgress = Mathf.Min(1, rotationProgress);
			
			transform.rotation = Quaternion.Lerp(rotationOrig, rotationTarget, Smooth.Interp(rotationProgress));
			
			if (rotationProgress == 1){
				foreach (Transform cube in cubes)
					cube.parent = transform.parent;
				isRotating = false;
				sphere.parent = transform.parent;
			}
		}
	}
}
