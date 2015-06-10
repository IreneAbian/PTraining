using UnityEngine;
using System.Collections;

public class ClickMostrarDatosPokemon : MonoBehaviour {

	void OnClick(){
		switch (transform.parent.name) {
		case "Pokemon000":
			UIController.instance.MostrarPanelDatosPokemon(1);
			Debug.Log("Mostrando datos primer pokemon");

			break;

		case "Pokemon001":
			Debug.Log("Mostrando datos segundo pokemon");
			UIController.instance.MostrarPanelDatosPokemon(2);

			break;

		case "Pokemon002":
			Debug.Log("Mostrando datos tercer pokemon");
			UIController.instance.MostrarPanelDatosPokemon(3);

			break;
		}
	}
}
