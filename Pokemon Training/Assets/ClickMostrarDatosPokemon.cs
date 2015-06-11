using UnityEngine;
using System.Collections;

public class ClickMostrarDatosPokemon : MonoBehaviour {

	void OnClick(){
		switch (transform.parent.name) {
		case "Pokemon000":
            UIController.instance.MostrarPanelDatosPokemon(1);
			break;

		case "Pokemon001":
			UIController.instance.MostrarPanelDatosPokemon(2);
			break;

		case "Pokemon002":
			UIController.instance.MostrarPanelDatosPokemon(3);
			break;
		}
	}
}
