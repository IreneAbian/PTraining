using SQLite4Unity3d;
using System.Collections.Generic;

public class PokemonBasicDAO{

	public PokemonBasic GetPokemon(int id){
		return DataService.instance._connection.Table<PokemonBasic> ().Where (x => x.Id == id).First();
	}

	public IEnumerable<PokemonBasic> GetPokemonBasics(){
		return DataService.instance._connection.Table<PokemonBasic> ().Where (x => x.IsBasic == true);
	}

	public IEnumerable<PokemonBasic> GetBasicPokemonsOfType(string type){
		return DataService.instance._connection.Table<PokemonBasic> ().Where (x => x.Type == type);
	}

}
