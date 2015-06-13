using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BotonElegirPokemonPocion : MonoBehaviour {

	void OnClick(){
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		List<PokemonOwned> lista = pkmOwned.GetEquippedPokemon ().ToList ();
		switch (transform.name) {
		case "Pokemon000":
			if (lista.Count() > 0){
				GameController.instance.UsarItem(lista[0].Id);
				UIController.instance.MostrarPanelDatosInventario();
			} else {
				UIController.instance.MostrarPanelMensaje("No hay ningun pokemon en esa posicion");
			}
			break;

		case "Pokemon001":
			if (lista.Count() > 1){
				GameController.instance.UsarItem(lista[1].Id);
				UIController.instance.MostrarPanelDatosInventario();
			} else {
				UIController.instance.MostrarPanelMensaje("No hay ningun pokemon en esa posicion");
			}
			break;

		case "Pokemon002": 
			if (lista.Count() > 2){
				GameController.instance.UsarItem(lista[2].Id);
				UIController.instance.MostrarPanelDatosInventario();
			} else {
				UIController.instance.MostrarPanelMensaje("No hay ningun pokemon en esa posicion");
			}
			break;
		}
	}
}
