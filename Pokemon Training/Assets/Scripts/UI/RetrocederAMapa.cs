using UnityEngine;
using System.Collections;

public class RetrocederAMapa : MonoBehaviour {

	void OnClick(){
		UIController.instance.MostrarPanelJuego ();
		GameController.instance.RetrocederJugador ();
	}
}
