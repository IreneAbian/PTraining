using UnityEngine;
using System.Collections;
using System.Linq;
using SQLite4Unity3d;

public class CrearJugador : MonoBehaviour {

	public GameObject labelNombre;

	void OnClick(){
		PlayerDAO player = new PlayerDAO ();
		PokemonOwnedDAO pkmdao = new PokemonOwnedDAO ();
		EggOwnedDAO eggowned = new EggOwnedDAO ();
		ItemsOwnedDAO itemsdaos = new ItemsOwnedDAO ();
		itemsdaos.DeleteAllItems ();
		eggowned.DeleteAllEggs ();
		pkmdao.DeleteAllPokemon ();
		player.CrearJugador (labelNombre.GetComponent<UILabel> ().text);
		UIController.instance.MostrarPanelContinuar ();
	}


}