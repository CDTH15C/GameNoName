using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombo : MonoBehaviour {

	public bool canCombo1 = false,canCombo2 =false, canCombo3=false, canCombo4=false,canCombo5=false, canCombo6=false;
	public GameObject ice, firePheonix, waterShark, combo1Effect, fireSpear;

	private Animator anim;
	private PlayerController playerCtrl;
	private float timer;
	private bool isAttacking;
	private bool isCombo2, isCombo3, isCombo4, isCombo5, isCombo6, canMakeCombo;

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

		canMakeCombo = playerCtrl.grounded && !isCombo3 && !isAttacking && !isCombo4 && !isCombo2 && !isCombo5 && !isCombo6;

		if (Input.GetKeyDown (KeyCode.X) && canMakeCombo && canCombo1) {
			anim.SetTrigger ("MakeCombo");
			StartCoroutine(combo1 ());
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			if (Input.GetKeyDown (KeyCode.C) && canMakeCombo && canCombo3) {
				anim.SetTrigger ("MakeCombo");
				StartCoroutine (combo3 ());
			}
		}

		if ((Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && !Input.GetKey(KeyCode.UpArrow) && canMakeCombo && canCombo4) {
			if (Input.GetKeyDown (KeyCode.C) && canMakeCombo) {
				anim.SetTrigger ("MakeCombo");
				StartCoroutine (combo4 ());
			}
		}

		if (Input.GetKeyDown (KeyCode.Z) && canMakeCombo && !(Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && canCombo5) {
			anim.SetTrigger ("MakeCombo");
			StartCoroutine(combo5 ());
		}

		if ((Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && !Input.GetKey(KeyCode.UpArrow) && canMakeCombo && canCombo6) {
			if (Input.GetKeyDown (KeyCode.Z) && canMakeCombo) {
				anim.SetTrigger ("MakeCombo");
				StartCoroutine (combo6 ());
			}
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
		anim.SetBool ("isCombo6", isCombo6);
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
		Instantiate (ice, transform.position - new Vector3(0f * transform.localScale.x, -2.1f, -0.1f), Quaternion.identity);
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

	IEnumerator combo6()
	{
		isCombo6 = true;
		playerCtrl.canControl = false;
		playerCtrl.setDefault ();

		yield return new WaitForSeconds (0.3f);
		Instantiate (fireSpear, transform.position - new Vector3(1.5f * transform.localScale.x, -0.3f, 0), Quaternion.identity);

		yield return new WaitForSeconds (0.2f);

		isCombo6 = false;
		playerCtrl.canControl = true;
	}


}
