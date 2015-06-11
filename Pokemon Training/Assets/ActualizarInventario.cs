using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class ActualizarInventario : MonoBehaviour {

	void OnClick(){
		if (transform.parent.name == "BotonInventarioItems"){
			UIController.instance.MostrarInventarioItems();
		} else {
			UIController.instance.MostrarInventarioHuevos();
		}
	}
}