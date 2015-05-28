using UnityEngine;
using System.Collections;
using System.Linq;

public class DatosPantallaInicio : MonoBehaviour {
	public GameObject labelNombre;
	public GameObject labelOro;
	public GameObject labelPokemon;
	
	void Start () {
		PlayerDAO player = new PlayerDAO ();
		labelOro.GetComponent<UILabel> ().text = "Oro: "+ player.ReadPlayer ().Gold;
		labelNombre.GetComponent<UILabel> ().text = "Nombre: "+ player.ReadPlayer ().Name;
		PokemonOwnedDAO pokemon = new PokemonOwnedDAO ();
		labelPokemon.GetComponent<UILabel>().text = "Pokemon: "+ pokemon.GetOwnedPokemon ().ToList().Count();
	}

	void OnClick(){
		UIController.instance.MostrarPanelJuego ();
	}

}
