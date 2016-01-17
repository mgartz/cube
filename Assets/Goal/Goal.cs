using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	float speed = 70f;
	int currentSpot = -1;

	public Transform[] spots;

	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, Vector3.down, Time.deltaTime*speed);
	}

	void OnTriggerEnter(Collider collider){
		if (collider.transform.name.Equals("Sphere")){
			GetComponent<AudioSource>().Play();
			Game.instance.AddScore();
			MoveToNewSpot();
		}
	}

	void MoveToNewSpot(){
		int nextSpot = currentSpot;
		if (currentSpot == -1){
			nextSpot = 0;
			currentSpot = nextSpot;
		}
		else {
			while (nextSpot == currentSpot)
				nextSpot = Random.Range(0, spots.Length);
			currentSpot = nextSpot;
		}

		transform.parent = spots[currentSpot];
		transform.localPosition = Vector3.zero;
	}
}
