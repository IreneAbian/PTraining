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
			foreach (PokemonOwned pok in listPokemon) {
				pkmowned.HealthPokemon (pok.Id);
			}
			labelPrecio.GetComponent<UILabel> ().text = "Precio: " + GameController.instance.CalcularPrecioHospital ();
		} else {
			UIController.instance.MostrarPanelHospitalNoDinero();
		}
	}
}
