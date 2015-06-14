using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	Animator anim;
//	private Vector2 touchOrigin = -Vector2.one;
	public Vector2 movement;
	public GameObject buttonUp;
	public GameObject buttonDown;
	public GameObject buttonRight;
	public GameObject buttonLeft;

		void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
		movement = Vector2.zero;

		#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

        movement = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));


		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE


		if (buttonUp.GetComponent<MovementPadUp>().pulsado){
			movement.y = 1;
		} else if (buttonDown.GetComponent<MovementPadDown>().pulsado){
			movement.y = -1;
		} else if (buttonLeft.GetComponent<MovementPadLeft>().pulsado){
			movement.x = -1;
		} else if (buttonRight.GetComponent<MovementPadRight>().pulsado){
			movement.x = 1;
		}


		//		if (Input.touchCount > 0)
//        {
//            if (Input.GetTouch(0).position.x > Screen.width / 2)
//            {
//                movement.x = 1;
//            } 
//			else if (Input.GetTouch(0).position.x < Screen.width / 2)
//            {
//                movement.x = -1;
//            }
//
//            if (Input.GetTouch(0).position.y > Screen.width / 2)
//            {
//                movement.y = 1;
//            } 
//            else if (Input.GetTouch(0).position.y < Screen.width / 2)
//            {
//                movement.y = -1;
//            }
//        }

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

