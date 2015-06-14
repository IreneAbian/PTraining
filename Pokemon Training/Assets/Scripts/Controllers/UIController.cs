using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	public List<GameObject> paneles;

	public GameObject labelNombre;
	public GameObject labelOro;
	public GameObject labelPokemon;

	public GameObject labelMensaje;
	public int itemSeleccionado;

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
		paneles [1].GetComponentInChildren<AbrirMenu> ().pulsado = false;
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
		labelNombre.GetComponent<UILabel> ().text = "Nombre: "+ player.GetPlayer ().Name;
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

	public void MostrarPanelMensaje(string mensaje){
		paneles[8].SetActive(true);
		labelMensaje.GetComponent<UILabel> ().text = mensaje;
	}

	public void EsconderPanelMensaje (){
		paneles [8].SetActive (false);
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
		case 4:
			paneles[12].GetComponent<MostrarDatosHuevo>().enabled = true;
			break;

		}
	}

	public void MostrarPanelSacarPokemon(){
		EsconderPaneles ();
        paneles[13].GetComponent<MostrarDatosSacarPokemon>().actualizarLista = true;
		paneles [13].SetActive (true);
	}

    public void MostrarPanelDatosInventario(){
        EsconderPaneles();
        paneles[14].SetActive(true);
        MostrarInventarioItems();
    }

    public void MostrarInventarioHuevos(){
        paneles[14].GetComponent<MostrarDatosInventario>().mostrarItems = false;
		paneles[14].GetComponent<MostrarDatosInventario>().actualizarInventario = true;
    }

    public void MostrarInventarioItems(){
        paneles[14].GetComponent<MostrarDatosInventario>().mostrarItems = true;
		paneles[14].GetComponent<MostrarDatosInventario>().actualizarInventario = true;
    }

    public void MostrarPanelTienda(){
        EsconderPaneles();
        paneles[15].SetActive(true);
		MostrarTiendaItems ();
    }

    public void MostrarTiendaItems(){
		paneles[15].GetComponent<MostrarDatosTienda>().mostrarItems = true;
		paneles[15].GetComponent<MostrarDatosTienda>().actualizarTienda = true;
	}

    public void MostrarTiendaHuevos(){
		paneles[15].GetComponent<MostrarDatosTienda>().mostrarItems = false;
		paneles[15].GetComponent<MostrarDatosTienda>().actualizarTienda = true;
    }

	public void MostrarPanelZonaEntrenamiento(){
		EsconderPaneles ();
		paneles [16].SetActive (true);
	}

	public void MostrarPanelUsarPocionEn(){
		paneles [14].SetActive (false);
		paneles [17].SetActive (true);
	}

	public void OcultarPanelUsarPocionEn(){
		paneles [17].SetActive (false);
	}

}