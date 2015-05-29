using UnityEngine;
using System.Collections;

public class DetectarColliders : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name.Equals("ColliderLibreria")){
			UIController.instance.MostrarPanelLibreria();
			GameController.instance.ImpedirMovimientoJugador();
			GameController.instance.OcultarMapa();
		}
	
	}
}
