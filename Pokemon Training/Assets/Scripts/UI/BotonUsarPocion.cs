using UnityEngine;
using System.Collections;

public class BotonUsarPocion : MonoBehaviour {

	public bool sePuedeUsar;
	void OnClick(){
		if (sePuedeUsar) {
			UIController.instance.MostrarPanelUsarPocionEn ();
			UIController.instance.itemSeleccionado = int.Parse(transform.name);
		}
	}
}
