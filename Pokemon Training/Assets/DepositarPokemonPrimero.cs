using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DepositarPokemonPrimero : MonoBehaviour {

	void OnClick(){
		PokemonOwnedDAO pkmowned = new PokemonOwnedDAO();
		List<PokemonOwned> lista = pkmowned.GetEquippedPokemon ().ToList();
		pkmowned.UnEquipPokemon (lista [0].Id);
	}


}