using UnityEngine;
using System.Collections;

public class ActualizarInventario : MonoBehaviour {

	void OnClick(){
		if (transform.name == "BotonInventarioItems"){
			UIController.instance.MostrarInventarioItems();
		} else {
			UIController.instance.MostrarInventarioHuevos();
		}
	}
}