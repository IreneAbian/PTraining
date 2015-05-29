using UnityEngine;
using System.Collections;

public class AbrirMenu : MonoBehaviour {

	bool pulsado;

	void OnClick(){
		if (pulsado) {
			pulsado = false;
			UIController.instance.MostrarPanelJuego();
			GameController.instance.ImpedirMovimientoJugador();
		} else {
			pulsado = true;
			UIController.instance.MostrarPanelMenu();
			GameController.instance.ImpedirMovimientoJugador();
		}
	}
}
