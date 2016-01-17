using UnityEngine;
using System.Collections;

public class Global {
	public const int gameDurationSeconds = 100;
	public const int goalTimeRewardSeconds = 10;
	public const int size = 3;

	public const float rotationSpeed = 3f;

	//dvorak...
//	public static string[] faceRotationKeys = {"o", "e", "u", "h", "t", "n"};
//	public static string[] cubeRotationKeys = {".", "c", "space"};
	
	//qwerty...
	public static string[] faceRotationKeys = {"s", "d", "f", "j", "k", "l"};
	public static string[] cubeRotationKeys = {"e", "i", "space"};

	public static string[] playerMovementKey = {"up", "down", "left", "right"};

	public static string retryKey = "r";
}
