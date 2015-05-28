using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
public class UIController : MonoBehaviour {

	public List<GameObject> paneles;

	public static UIController instance = null;

	void Start(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy(instance);
		}
	}

	public void MostrarPanelJuego(){
		EsconderPaneles ();
		paneles [1].SetActive (true);
		GameController.instance.MostrarMapa ();
	}

	public void EsconderPaneles(){
		foreach (GameObject  pan in paneles) {
			pan.SetActive(false);
		}
	}

	public void MostrarPanelNuevoJugador(){
		EsconderPaneles ();
		paneles [2].SetActive (true);
	}

	public void MostrarPanelContinuar(){
		EsconderPaneles ();
		paneles [0].SetActive (true);
	}
}