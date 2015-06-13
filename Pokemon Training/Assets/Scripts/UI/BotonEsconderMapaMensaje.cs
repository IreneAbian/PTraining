using UnityEngine;
using System.Collections;

public class BotonEsconderMapaMensaje : MonoBehaviour {

	void OnClick(){
		UIController.instance.EsconderPanelMensaje ();
	}
}
