using UnityEngine;
using System.Collections;

public class BotonAbrirInventario : MonoBehaviour {

	void OnClick(){
		UIController.instance.MostrarPanelDatosInventario ();
	}
}
