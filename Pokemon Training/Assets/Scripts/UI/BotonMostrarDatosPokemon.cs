using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BotonMostrarDatosPokemon : MonoBehaviour {

	void OnClick(){
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		EggOwnedDAO eggOwned = new EggOwnedDAO ();
		switch (transform.parent.name) {
		case "Pokemon000":
			if (pkmOwned.GetEquippedPokemon().ToList().Count() > 0){
          	  UIController.instance.MostrarPanelDatosPokemon(1);
			} else {
				UIController.instance.MostrarPanelMensaje("No tienes ningun pokemon equipado ahi");
			}
			break;
		case "Pokemon001":
			if (pkmOwned.GetEquippedPokemon().ToList().Count() > 1){
				UIController.instance.MostrarPanelDatosPokemon(2);
			} else {
				UIController.instance.MostrarPanelMensaje("No tienes ningun pokemon equipado ahi");
			}
			break;
		case "Pokemon002":
			if (pkmOwned.GetEquippedPokemon().ToList().Count() > 2){
				UIController.instance.MostrarPanelDatosPokemon(3);
			} else {
				UIController.instance.MostrarPanelMensaje("No tienes ningun pokemon equipado ahi");
			}
			break;
		case "Huevo":
			if (eggOwned.GetEquippedEgg() != null){
				UIController.instance.MostrarPanelDatosPokemon(4);
			} else {
				UIController.instance.MostrarPanelMensaje("No tienes ningun huevo equipado");
			}
			break;
		}

	}
}
