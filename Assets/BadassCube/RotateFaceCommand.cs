using UnityEngine;
using System.Collections;

public class RotateFaceCommand : Command
{
	BadassCube cube;
	BadassCube.Face face;
	int col;
	int dir;

	public RotateFaceCommand(BadassCube cube, BadassCube.Face face, int col, int dir){
		this.cube = cube;
		this.face = face;
		this.col = col;
		this.dir = dir;
	}

	public override void doCommand ()
	{
		cube.StartFaceRotation (face, col, dir);
	}
}

