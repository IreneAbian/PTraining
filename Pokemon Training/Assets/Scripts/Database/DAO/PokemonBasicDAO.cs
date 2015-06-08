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

	public IEnumerable<PokemonBasic> GetBasicPokemonsOfType(string type){
		return DataService.instance._connection.Table<PokemonBasic> ().Where (x => x.Type == type);
	}

	public IEnumerable<PokemonBasic> GetAllPokemon(){
		return DataService.instance._connection.Table<PokemonBasic> ();
	}


}
