using UnityEngine;
using System.Collections;

public class MovimientoPadUp : MonoBehaviour {

	public bool pulsado;
	void Update () {
		if (Input.GetButton("Fire1")){
			pulsado = true;
		} else {
			pulsado = false;
		}
	}
}
