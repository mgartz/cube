using UnityEngine;
using System.Collections;

public class RotateCubeCommand : Command
{
	BadassCube cube;
	BadassCube.Axis axis;
	int dir;

	public RotateCubeCommand(BadassCube cube, BadassCube.Axis axis, int dir){
		this.cube = cube;
		this.axis = axis;
		this.dir = dir;
	}

	public override void doCommand(){
		cube.StartCubeRotation (axis, dir);
	}
}

