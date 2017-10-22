using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBehavior : MonoBehaviour {

	public GameObject effect;

	void Start()
	{
		StartCoroutine (Effect ());
	}

	IEnumerator Effect(){
		yield return new WaitForSeconds (0.6f);
		Instantiate (effect, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
	}
}
