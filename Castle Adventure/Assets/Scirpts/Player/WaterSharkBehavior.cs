using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSharkBehavior : MonoBehaviour {

	void Awake()
	{
		Vector3 temp = transform.transform.localScale;
		temp.x *= FindObjectOfType<PlayerController> ().gameObject.transform.transform.localScale.x;
		this.transform.transform.localScale = temp;
	}
}
