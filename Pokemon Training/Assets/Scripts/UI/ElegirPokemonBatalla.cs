using UnityEngine;
using System.Collections;

public class ElegirPokemonBatalla : MonoBehaviour {

	void OnClick(){
		switch (transform.name) {
		case "BotonElegirPrimero":
			UIController.instance.MostrarPanelZonaBatallaElegida (1);
			break;
		case "BotonElegirSegundo":
			UIController.instance.MostrarPanelZonaBatallaElegida (2);
			break;
		case "BotonElegirTercero":
			UIController.instance.MostrarPanelZonaBatallaElegida (3);
			break;
		}
	}
}
