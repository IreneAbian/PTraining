using SQLite4Unity3d;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;

public class PokemonBasicDAO{

	public PokemonBasic GetPokemon(int id){
		return DataService.instance._connection.Table<PokemonBasic> ().Where (x => x.Id == id).FirstOrDefault();
	}

	public IEnumerable<PokemonBasic> GetPokemonBasics(){
		return DataService.instance._connection.Table<PokemonBasic> ().Where (x => x.IsBasic == true);
	}

	public List<PokemonBasic> GetBasicPokemonsOfType(string type){
		List<PokemonBasic> basicos = GetPokemonBasics ().ToList();
		List<PokemonBasic> adecuados = new List<PokemonBasic> ();
		for (int i = 0; i < basicos.Count(); i++) {
			if (basicos[i].Type == type){
				adecuados.Add(basicos[i]);
			}
		}
		return adecuados;
	}

	public IEnumerable<PokemonBasic> GetAllPokemon(){
		return DataService.instance._connection.Table<PokemonBasic> ();
	}


}
