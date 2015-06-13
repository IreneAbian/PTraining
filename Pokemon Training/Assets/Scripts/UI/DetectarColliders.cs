using UnityEngine;
using System.Collections;

public class DetectarColliders : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		switch (other.gameObject.name) {
			case "ColliderLibreria":
				UIController.instance.MostrarPanelLibreria ();
				GameController.instance.ImpedirMovimientoJugador ();
				GameController.instance.OcultarMapa ();
				break;
			case "ColliderZonaBatalla":
				UIController.instance.MostrarPanelZonaBatalla ();
				GameController.instance.ImpedirMovimientoJugador ();
				GameController.instance.OcultarMapa ();
				break;
			case "ColliderHospital":
				UIController.instance.MostrarPanelHospital ();
				GameController.instance.ImpedirMovimientoJugador ();
				GameController.instance.OcultarMapa ();
				break;
			case "ColliderPosada":
				UIController.instance.MostrarPanelPosada ();
				GameController.instance.ImpedirMovimientoJugador ();
				GameController.instance.OcultarMapa ();
				break;
			case "ColliderTienda":
				UIController.instance.MostrarPanelTienda ();
				GameController.instance.ImpedirMovimientoJugador ();
				GameController.instance.OcultarMapa ();
				break;
			case "ColliderEntrenamiento":
				UIController.instance.MostrarPanelZonaEntrenamiento ();
				GameController.instance.ImpedirMovimientoJugador ();
				GameController.instance.OcultarMapa ();
				break;
		}
	
	}
}
