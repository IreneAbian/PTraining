﻿using UnityEngine;
using System.Collections;

public class MovementPadRight : MonoBehaviour {

	public bool pulsado;
	
	void Update(){
		pulsado = false;
		GameObject camera = GameObject.Find ("CameraBaseMenu");
		Ray ray = camera.GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit, 100)) {
			if (hit.transform.gameObject.tag == "Right") {
				if (Input.GetButton ("Fire1")) {
					pulsado = true;
				} else {
					pulsado = false;
				}
			}
		}
	}
}
