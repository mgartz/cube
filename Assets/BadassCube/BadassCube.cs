using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BadassCube : MonoBehaviour {
	public Transform faceAnchor;
	FaceAnchor faceAnchorScript;

	public Transform cubeAnchor;

	public Transform sphere;

	public AudioSource turnAudioSource;

	Transform[] cubes;


	public enum Face {Left, Right};
	public enum Axis {X, Y, Z};

	bool isRotating;
	float rotationProgress;
	Quaternion rotationOrig;
	Quaternion rotationTarget;

	int countShiftDown = 0;

	List<Command> queuedCommands = new List<Command>();

	// Use this for initialization
	void Start () {
		faceAnchorScript = faceAnchor.GetComponent<FaceAnchor>();

		cubes = new Transform[Global.size * Global.size * Global.size + Global.size * Global.size * 6];
		int i=0;
		foreach (Transform t in transform)
			if (t.name.StartsWith("RCube") || t.name.Equals("Wall"))
				cubes[i++] = t;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateShiftState();
		int dir = countShiftDown == 0 ? 1 : -1;

		if (Input.GetKeyDown(Global.cubeRotationKeys[0]))
			StartCubeRotation(Axis.X, dir);
		if (Input.GetKeyDown(Global.cubeRotationKeys[1]))
			StartCubeRotation(Axis.Z, dir);
		if (Input.GetKeyDown(Global.cubeRotationKeys[2]))
			StartCubeRotation(Axis.Y, -dir);

		for (int i=0; i<3; i++)
			if (Input.GetKeyDown(Global.faceRotationKeys[i]))
				StartFaceRotation(Face.Left, i, dir);
		for (int i=0; i<3; i++)
			if (Input.GetKeyDown(Global.faceRotationKeys[3+i]))
				StartFaceRotation(Face.Right, i, dir);

		if (!isRotating && !faceAnchorScript.isRotating)
			CheckQueuedCommands ();
		UpdateCubeRotation();
    }

	void UpdateShiftState(){
		if (Input.GetKeyDown(KeyCode.LeftShift))
			countShiftDown++;
		if (Input.GetKeyDown(KeyCode.RightShift))
			countShiftDown++;
		if (Input.GetKeyUp(KeyCode.LeftShift))
			countShiftDown--;
		if (Input.GetKeyUp(KeyCode.RightShift))
			countShiftDown--;
	}

	public void StartCubeRotation(Axis axis, int dir){
		if (!isRotating && !faceAnchorScript.isRotating){
			turnAudioSource.Play();
			isRotating = true;
			rotationOrig = Quaternion.Euler(0,0,0);
			rotationProgress = 0;
			
			cubeAnchor.localRotation = rotationOrig;

			if (axis == Axis.X)
				rotationTarget = Quaternion.Euler(90*dir, 0, 0);
			if (axis == Axis.Y)
				rotationTarget = Quaternion.Euler(0, 90*dir, 0);
			if (axis == Axis.Z)
				rotationTarget = Quaternion.Euler(0, 0, 90*dir);
			sphere.parent = cubeAnchor;
			transform.parent = cubeAnchor;
		}
		else
			queuedCommands.Add(new RotateCubeCommand(this, axis, dir));
	}
	public void StartFaceRotation(Face face, int col, int dir){
		if (!isRotating && !faceAnchorScript.isRotating){
			turnAudioSource.Play();
			faceAnchorScript.StartFaceRotation(cubes, sphere, face, col, dir);
		}
		else
			queuedCommands.Add(new RotateFaceCommand(this, face, col, dir));
	}

	void UpdateCubeRotation(){
		if (isRotating){
			rotationProgress += Global.rotationSpeed * Time.deltaTime;
			rotationProgress = Mathf.Min(1, rotationProgress);
			
			cubeAnchor.localRotation = Quaternion.Lerp(rotationOrig, rotationTarget, Smooth.Interp(rotationProgress));
			
			if (rotationProgress == 1){
				transform.parent = null;
				sphere.parent = null;
				isRotating = false;
			}
		}
	}

	void CheckQueuedCommands(){
		if (queuedCommands.Count > 0){
			Command cmd = queuedCommands[0];
			queuedCommands.Remove(cmd);
			cmd.doCommand();
		}
	}

}
