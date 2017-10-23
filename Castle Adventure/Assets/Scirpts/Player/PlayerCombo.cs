using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombo : MonoBehaviour {

	public GameObject ice, firePheonix, waterShark, combo1Effect;

	private Animator anim;
	private PlayerController playerCtrl;
	private float timer;
	private bool isAttacking;
	private bool isCombo2, isCombo3, isCombo4, isCombo5, canMakeCombo;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerCtrl = GetComponent<PlayerController> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		canMakeCombo = playerCtrl.grounded && !isCombo3 && !isAttacking && !isCombo4 && !isCombo2 && !isCombo5;

		if (Input.GetKeyDown (KeyCode.X) && canMakeCombo) {
			anim.SetTrigger ("MakeCombo");
			StartCoroutine(combo1 ());
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			if (Input.GetKeyDown (KeyCode.C) && canMakeCombo) {
				anim.SetTrigger ("MakeCombo");
				StartCoroutine (combo3 ());
			}
		}

		if ((Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && !Input.GetKey(KeyCode.UpArrow) && canMakeCombo) {
			if (Input.GetKeyDown (KeyCode.C) && canMakeCombo) {
				anim.SetTrigger ("MakeCombo");
				StartCoroutine (combo4 ());
			}
		}

		if (Input.GetKeyDown (KeyCode.Z) && canMakeCombo) {
			anim.SetTrigger ("MakeCombo");
			StartCoroutine(combo5 ());
		}

		setAnimation ();

	}

	void setAnimation()
	{
		anim.SetBool ("isAttacking", isAttacking);
		//anim.SetBool ("isCombo2", isCombo2);
		anim.SetBool ("isCombo3", isCombo3);
		anim.SetBool ("isCombo4", isCombo4);
		anim.SetBool ("isCombo5", isCombo5);
	}

	IEnumerator combo1()
	{
		isAttacking = true;
		playerCtrl.canControl = false;
		playerCtrl.setDefault();
		Instantiate (combo1Effect, transform.position - new Vector3(2f * transform.localScale.x, -0.2f, 0), Quaternion.identity);

		yield return new WaitForSeconds (0.5f);

		isAttacking = false;
		playerCtrl.canControl = true;
	}


	IEnumerator combo2()
	{
		isCombo2 = true;
		playerCtrl.canControl = false;
		playerCtrl.setDefault();

		yield return new WaitForSeconds (0.5f);

		isCombo2 = false;
		playerCtrl.canControl = true;
	}

	IEnumerator combo3()
	{
		isCombo3 = true;
		playerCtrl.canControl = false;
		playerCtrl.setDefault ();

		yield return new WaitForSeconds (0.3f);
		Instantiate (ice, transform.position - new Vector3(0.5f * transform.localScale.x, 0.5f, 0), Quaternion.identity);
		Rigidbody2D player = playerCtrl.gameObject.GetComponent<Rigidbody2D> ();
		player.velocity = new Vector2 (player.velocity.x, 11f);

		yield return new WaitForSeconds (0.4f);

		isCombo3 = false;
		playerCtrl.canControl = true;
	}

	IEnumerator combo4()
	{
		isCombo4 = true;
		playerCtrl.canControl = false;
		playerCtrl.setDefault ();

		yield return new WaitForSeconds (0.3f);

		Rigidbody2D player = playerCtrl.gameObject.GetComponent<Rigidbody2D> ();
		player.velocity = new Vector2 (-15 * transform.localScale.x, player.velocity.y);

		yield return new WaitForSeconds (0.2f);

		Instantiate (waterShark, transform.position - new Vector3(1f * transform.localScale.x, -0.5f, -0.1f), Quaternion.identity);

		//yield return new WaitForSeconds (0f);

		//playerCtrl.setDefault ();
		//yield return new WaitForSeconds (0.1f);
		isCombo4 = false;
		playerCtrl.canControl = true;
	}

	IEnumerator combo5()
	{
		isCombo5 = true;
		playerCtrl.canControl = false;
		playerCtrl.setDefault ();

		yield return new WaitForSeconds (0.5f);
		Instantiate (firePheonix, transform.position - new Vector3(1f * transform.localScale.x, -1.8f, -0.1f), Quaternion.identity);
		yield return new WaitForSeconds (0.2f);
		playerCtrl.canControl = true;
		isCombo5 = false;
	}

}
