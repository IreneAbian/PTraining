using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 movement;
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		movement = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
		Debug.Log("Soy un comentario. Si, sin "//". Y punto.");
		#endif

		if (movement != Vector2.zero) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat("input_x", movement.x);
			anim.SetFloat("input_y", movement.y);
		} else {
			anim.SetBool ("isWalking", false);
		}

		rb.MovePosition (rb.position + movement * Time.deltaTime);
	}
}

