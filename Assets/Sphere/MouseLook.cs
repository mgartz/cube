using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
	public float sensitivity = 100f;

	public float minimumX = -360f;
	public float maximumX = 360f;
	
	public float minimumY = -60f;
	public float maximumY = 60f;
	
	float rotationY = 0;

	public void Start() {
		Screen.showCursor = false;
	}
	
	void Update() {
		float rotationX = transform.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
		
		rotationY += Input.GetAxis("Mouse Y") * sensitivity;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		
		transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
	}
}