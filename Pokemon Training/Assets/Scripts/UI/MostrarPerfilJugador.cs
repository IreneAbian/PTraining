using UnityEngine;
using System.Collections;
using System.Linq;

public class MostrarPerfilJugador : MonoBehaviour {

	public GameObject labelNombre;
	public GameObject labelOro;
	public GameObject labelPokemon;
	public GameObject labelHuevos;

	void Update(){
		PlayerDAO player = new PlayerDAO ();
		PokemonOwnedDAO pk = new PokemonOwnedDAO ();
		EggOwnedDAO egg = new EggOwnedDAO ();
		Player p = player.GetPlayer ();
		labelNombre.GetComponent<UILabel>().text = "Perfil de " + p.Name;
		labelOro.GetComponent<UILabel>().text = "Oro: " + p.Gold;
		labelPokemon.GetComponent<UILabel> ().text = "Pokemon: " + pk.GetOwnedPokemon ().ToList().Count();
		labelHuevos.GetComponent<UILabel> ().text = "Huevos: " + egg.GetNotEquippedEggs ().ToList().Count();
	}

	void OnClick(){
		UIController.instance.MostrarPanelJuego ();
		UIController.instance.MostrarPanelMenu ();
	}
}
