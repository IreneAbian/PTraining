using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	public List<GameObject> paneles;

	public GameObject labelNombreDB;
	public GameObject labelOro;
	public GameObject labelPokemon;

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
		GameController.instance.PermitirMovimientoJugador ();
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
		MostrarDatosPantallaInicio ();
	}
	
	public void MostrarDatosPantallaInicio(){
		PlayerDAO player = new PlayerDAO ();
		labelOro.GetComponent<UILabel> ().text = "Oro: "+ player.GetPlayer ().Gold;
		labelNombreDB.GetComponent<UILabel> ().text = "Nombre: "+ player.GetPlayer ().Name;
		PokemonOwnedDAO pokemon = new PokemonOwnedDAO ();
		labelPokemon.GetComponent<UILabel>().text = "Pokemon: "+ pokemon.GetOwnedPokemon ().ToList().Count();
	}

	public void MostrarPanelMenu(){
		paneles [3].SetActive (true);
	}

	public void MostrarPerfilJugador(){
		EsconderPaneles ();
		paneles [4].SetActive (true);
	}

	public void MostrarPanelLibreria(){
		EsconderPaneles ();
		paneles [5].SetActive (true);
	}

	public void MostrarPanelZonaBatalla(){
		EsconderPaneles ();
		paneles [6].SetActive (true);
	}

	public void MostrarPanelHospital(){
		EsconderPaneles ();
		paneles [7].SetActive (true);
	}

	public void MostrarPanelHospitalNoDinero(){
		EsconderPaneles ();
		paneles[8].SetActive(true);
	}

	public void MostrarPanelPosada(){
		EsconderPaneles ();
		paneles [9].SetActive (true);
	}

	public void MostrarPanelZonaBatallaElegida(int pokemonElegido){
		EsconderPaneles ();
		paneles [10].SetActive (true);
		switch (pokemonElegido) {
		case 1:
			paneles[10].GetComponent<BatallaPrimerPokemon>().enabled = true;
			paneles[10].GetComponent<BatallaPrimerPokemon>().GenerarBatalla();
			break;
		case 2:
			paneles[10].GetComponent<BatallaSegundoPokemon>().enabled = true;
			paneles[10].GetComponent<BatallaSegundoPokemon>().GenerarBatalla();
			break;
		case 3:
			paneles[10].GetComponent<BatallaTercerPokemon>().enabled = true;
			paneles[10].GetComponent<BatallaTercerPokemon>().GenerarBatalla();
			break;
		}
	}

	public void MostrarPanelEquipo(){
		EsconderPaneles ();
		paneles [11].SetActive (true);
	}

	public void MostrarPanelDatosPokemon(int pokemonElegido){
		EsconderPaneles ();
		paneles [12].SetActive (true);
		switch (pokemonElegido) {
		case 1:
			paneles[12].GetComponent<MostrarDatosPrimerPokemon>().enabled = true;
			break;
		case 2:
			paneles[12].GetComponent<MostrarDatosSegundoPokemon>().enabled = true;
			break;
		case 3:
			paneles[12].GetComponent<MostrarDatosTercerPokemon>().enabled = true;
			break;
		}
	}

	public void MostrarPanelSacarPokemon(){
		EsconderPaneles ();
		paneles [13].SetActive (true);
	}


}