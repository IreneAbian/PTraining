using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CurarPokemon : MonoBehaviour {

	public GameObject labelPrecio;

	void OnClick(){
		bool pagado = GameController.instance.PagarHospital ();
		PokemonOwnedDAO pkmowned = new PokemonOwnedDAO ();
		if (pagado) {
			PokemonOwnedDAO pokmnowned = new PokemonOwnedDAO ();
			List<PokemonOwned> listPokemon = pokmnowned.GetEquippedPokemon ().ToList ();
			for (int i = 0; i < listPokemon.Count(); i++){
				pkmowned.HealthPokemon (listPokemon[i].Id);
			}
			labelPrecio.GetComponent<UILabel> ().text = "Precio: " + GameController.instance.CalcularPrecioHospital ();
			UIController.instance.MostrarPanelJuego();
		} else {
			UIController.instance.MostrarPanelMensaje("No dispones del dinero suficiente para curar a tus pokemon");
		}
	}
}
