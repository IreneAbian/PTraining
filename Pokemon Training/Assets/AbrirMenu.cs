using UnityEngine;
using System.Collections;

public class AbrirMenu : MonoBehaviour {

	bool pulsado;

	void OnClick(){
		if (pulsado) {
			pulsado = false;
			UIController.instance.MostrarPanelJuego();
		} else {
			pulsado = true;
			UIController.instance.MostrarPanelMenu();
		}
	}
}
