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
		labelOro.GetComponent<UILabel> ().text = "Oro: "+ player.ReadPlayer ().Gold;
		labelNombreDB.GetComponent<UILabel> ().text = "Nombre: "+ player.ReadPlayer ().Name;
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

}