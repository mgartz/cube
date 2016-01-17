using UnityEngine;
using System.Collections;

public class PlayerMovement2D : MonoBehaviour {

	float speed = 2f;

	// Update is called once per frame
	void Update() {
		float forwardSpeed = Input.GetAxis ("Vertical");
		float lateralSpeed = Input.GetAxis ("Horizontal");
		if (Mathf.Abs (forwardSpeed) + Mathf.Abs (lateralSpeed) > 1) {
				lateralSpeed /= Mathf.Sqrt (2);
				forwardSpeed /= Mathf.Sqrt (2);
		}
		forwardSpeed *= speed;
		lateralSpeed *= speed;

		
		Vector3 angles = transform.rotation.eulerAngles*Mathf.PI/180;
		Vector3 forward = forwardSpeed * new Vector3 (Mathf.Sin(angles.y), 0, Mathf.Cos(angles.y));
		Vector3 lateral = lateralSpeed * new Vector3 (Mathf.Cos(angles.y), 0, -Mathf.Sin(angles.y));
		Vector3 directForce = (forward + lateral);

		if (directForce.magnitude < 0.01f || Vector3.Dot (rigidbody.velocity, directForce) < 0) {
			rigidbody.velocity = new Vector3 (0, rigidbody.velocity.y, 0);
		}
		else {
			rigidbody.velocity = new Vector3 (directForce.x, rigidbody.velocity.y, directForce.z);
		}
	}


}
