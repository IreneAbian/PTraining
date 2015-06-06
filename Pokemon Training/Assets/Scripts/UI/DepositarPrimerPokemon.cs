using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DepositarPrimerPokemon : MonoBehaviour {

	void OnClick(){
		PokemonOwnedDAO pkmowned = new PokemonOwnedDAO();
		List<PokemonOwned> lista = pkmowned.GetEquippedPokemon ().ToList();
		if (lista.Count() > 0) {
			pkmowned.UnEquipPokemon (lista [0].Id);
		}
	}


}