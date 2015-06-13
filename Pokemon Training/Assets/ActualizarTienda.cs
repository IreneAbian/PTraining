using UnityEngine;
using System.Collections;

public class ActualizarTienda : MonoBehaviour {
	void OnClick(){
		if (transform.name == "BotonTiendaItems"){
			UIController.instance.MostrarTiendaItems();
		} else {
			UIController.instance.MostrarTiendaHuevos();
		}
	}
}
