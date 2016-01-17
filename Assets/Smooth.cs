using UnityEngine;
using System.Collections;

public class Smooth {

	public static float Interp(float x){
		if (x == 0 || x == 1)
			return x;
		return 1/(1+Mathf.Exp(-(x*12)+6));
	}
}
