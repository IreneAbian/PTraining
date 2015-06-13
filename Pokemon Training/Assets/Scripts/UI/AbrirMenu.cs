using UnityEngine;
using System.Collections;

public class AbrirMenu : MonoBehaviour {

	public bool pulsado;

	void OnClick(){
		if (pulsado) {
			pulsado = false;
			UIController.instance.MostrarPanelJuego();
			GameController.instance.PermitirMovimientoJugador();
		} else {
			pulsado = true;
			UIController.instance.MostrarPanelMenu();
			GameController.instance.ImpedirMovimientoJugador();
		}
	}
}
