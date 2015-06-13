using UnityEngine;
using System.Collections;

public class ElegirPokemonBatalla : MonoBehaviour {

	void OnClick(){
		switch (transform.name) {
		case "BotonElegirPrimero":
			UIController.instance.MostrarPanelZonaBatallaElegida (1);
			break;
		case "BotonElegidoSegundo":
			UIController.instance.MostrarPanelZonaBatallaElegida (2);
			break;
		case "BotonElegidoTercero":
			UIController.instance.MostrarPanelZonaBatallaElegida (3);
			break;


		}
	}
}
