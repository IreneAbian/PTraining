using UnityEngine;
using System.Collections;

public class CrearJugador : MonoBehaviour {

	public GameObject labelNombre;

	void OnClick(){
		PlayerDAO player = new PlayerDAO ();
		player.CrearJugador (labelNombre.GetComponent<UILabel> ().text);
		UIController.instance.MostrarPanelContinuar ();
	}

}