﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance = null;
	public GameObject mapa;
	PlayerDAO player;


	void Awake(){
		DataService ds = new DataService ("PT");
	}
	void Start(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy(instance);
		}

		player = new PlayerDAO ();

		if (player.ReadPlayer () == null) {
			UIController.instance.MostrarPanelNuevoJugador ();
		} else {
			UIController.instance.MostrarPanelContinuar();
		}
	}

	public void MostrarMapa(){
		mapa.SetActive (true);
	}

	public void OcultarMapa(){
		mapa.SetActive (false);
	}

}