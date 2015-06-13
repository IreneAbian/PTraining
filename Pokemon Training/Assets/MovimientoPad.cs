using UnityEngine;
using System.Collections;

public class MovimientoPad : MonoBehaviour {

	public bool pulsado;
	void Update(){
		switch (transform.name) {
		case "ButtonUp":
			if (Input.GetButton("Fire1")){
				pulsado = true;
			} else {
				pulsado = false;
			}
			break;

		case "ButtonDown":
			if (Input.GetButton("Fire1")){
				pulsado = true;
			} else {
				pulsado = false;
			}
			break;

		case "ButtonRight":
			if (Input.GetButton("Fire1")){
				pulsado = true;
			} else {
				pulsado = false;
			}
			break;

		case "ButtonLeft":
			if (Input.GetButton("Fire1")){
				pulsado = true;
			} else {
				pulsado = false;
			}
			break;
		}
	}
}
