using SQLite4Unity3d;
using System.Collections.Generic;

public class PokemonBasicDAO{

	private SQLiteConnection _connection;

	public PokemonBasicDAO(SQLiteConnection _connection){
		this._connection = _connection;
	}
	
	public PokemonBasic GetPokemon(int id){
		return _connection.Table<PokemonBasic> ().Where (x => x.Id == id);
	}

	public IEnumerable<PokemonBasic> GetPokemonBasics(){
		return _connection.Table<PokemonBasic> ().Where (x => x.IsBasic == true);
	}

	public IEnumerable<PokemonBasic> GetBasicPokemonsOfType(string type){
		return _connection.Table<PokemonBasic> ().Where (x => x.Type == type);
	}

}
