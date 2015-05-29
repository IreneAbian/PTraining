using UnityEngine;
using System.Collections;

public class ReiniciarPartida : MonoBehaviour {

	void OnClick(){
		PlayerDAO player = new PlayerDAO ();
		player.DeletePlayer ();
		UIController.instance.MostrarPanelNuevoJugador ();
	}

}
