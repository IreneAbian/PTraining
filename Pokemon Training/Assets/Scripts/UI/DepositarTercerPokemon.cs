using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DepositarTercerPokemon : MonoBehaviour {
	
	void OnClick(){
		PokemonOwnedDAO pkmowned = new PokemonOwnedDAO();
		List<PokemonOwned> lista = pkmowned.GetEquippedPokemon ().ToList();
		if (lista.Count > 2) {
			pkmowned.UnEquipPokemon (lista [2].Id);
		}
	}
	
}