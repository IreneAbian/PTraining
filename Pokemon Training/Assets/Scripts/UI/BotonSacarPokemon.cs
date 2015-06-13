using UnityEngine;
using System.Collections;

public class BotonSacarPokemon : MonoBehaviour {

	void OnClick(){
		UIController.instance.MostrarPanelSacarPokemon ();
	}
}
