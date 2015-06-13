using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class MostrarDatosPosada : MonoBehaviour {

	public GameObject pokemon1;
	public GameObject pokemon2;
	public GameObject pokemon3;
	List<PokemonOwned> listPokemon;

	PokemonOwnedDAO pkmowned;

	void Start(){
		pkmowned = new PokemonOwnedDAO ();
		List<PokemonOwned> listPokemon = pkmowned.GetEquippedPokemon ().ToList();

	}

	void FixedUpdate(){
		listPokemon = pkmowned.GetEquippedPokemon ().ToList();

		if (listPokemon.Count () == 1) {
			pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
			pokemon2.GetComponent<UISprite> ().spriteName = "0";
			pokemon3.GetComponent<UISprite> ().spriteName = "0";
		} else if (listPokemon.Count () == 2) {
			pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
			pokemon2.GetComponent<UISprite> ().spriteName = (listPokemon [1].IdBasic) + "";
			pokemon3.GetComponent<UISprite> ().spriteName = "0";
		} else if (listPokemon.Count () == 3) {
			pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
			pokemon2.GetComponent<UISprite> ().spriteName = (listPokemon [1].IdBasic) + "";
			pokemon3.GetComponent<UISprite> ().spriteName = (listPokemon [2].IdBasic) + "";
		} else if (listPokemon.Count () == 0) {
			pokemon1.GetComponent<UISprite> ().spriteName = "0";
			pokemon2.GetComponent<UISprite> ().spriteName = "0";
			pokemon3.GetComponent<UISprite> ().spriteName = "0";
		}

	}

}
