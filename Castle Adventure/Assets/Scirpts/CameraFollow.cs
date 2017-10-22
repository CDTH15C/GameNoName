using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	public float smoothTime;

	private Vector3 velocity;
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetPos = player.position;
		targetPos.y += 2f;
		targetPos.z = -10f;
		Vector3 temp = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, smoothTime);
		transform.position = temp;
	}
}
