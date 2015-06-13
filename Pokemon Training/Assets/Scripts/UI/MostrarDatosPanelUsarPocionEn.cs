using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
	 

public class MostrarDatosPanelUsarPocionEn : MonoBehaviour {

	public GameObject sprite1;
	public GameObject sprite2;
	public GameObject sprite3;

	void Update(){
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		List<PokemonOwned> lista = pkmOwned.GetEquippedPokemon ().ToList ();
		if (lista.Count () == 1) {
			sprite1.GetComponent<UISprite>().spriteName = lista[0].IdBasic+"";
		} else if (lista.Count () == 2) {
			sprite1.GetComponent<UISprite>().spriteName = lista[0].IdBasic+"";
			sprite2.GetComponent<UISprite>().spriteName = lista[1].IdBasic+"";
		} else if (lista.Count () == 3) {
			sprite1.GetComponent<UISprite>().spriteName = lista[0].IdBasic+"";
			sprite2.GetComponent<UISprite>().spriteName = lista[1].IdBasic+"";
			sprite3.GetComponent<UISprite>().spriteName = lista[2].IdBasic+"";
		} else if (lista.Count () == 0) {
			sprite1.GetComponent<UISprite>().spriteName = "0";
			sprite2.GetComponent<UISprite>().spriteName = "0";
			sprite3.GetComponent<UISprite>().spriteName = "0";
		}
	}

}
