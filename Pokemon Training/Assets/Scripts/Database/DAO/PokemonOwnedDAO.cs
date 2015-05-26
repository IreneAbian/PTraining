using SQLite4Unity3d;
using System.Collections.Generic;
using System.Linq;

public class PokemonOwnedDAO{

	private SQLiteConnection _connection;

	public PokemonOwnedDAO(SQLiteConnection _connection){
		this._connection = _connection;
	}

	public IEnumerable<PokemonOwned> ReadEquippedPokemon(){
		return _connection.Table<PokemonOwned> ().Where (x => x.InTeam == true);
	}

	public IEnumerable<PokemonOwned> ReadNotEquippedPokemon(){
		return _connection.Table<PokemonOwned> ().Where (x => x.InTeam == false);
	}

	public void CreatePokemonOwned(int basicId){
		PokemonBasic pokemonBasic = _connection.Table<PokemonBasic> ().Where (x => x.Id == basicId).First();
		PokemonOwned pokemonOwned = new PokemonOwned ();
		pokemonOwned.IdBasic = basicId;
		pokemonOwned.Hp = pokemonBasic.BasicHp;
		pokemonOwned.Attack = pokemonBasic.BasicAttack;
		pokemonOwned.Defense = pokemonBasic.BasicDefense;
		pokemonOwned.SpecialAttack = pokemonBasic.BasicSpecialAttack;
		pokemonOwned.SpecialDefense = pokemonBasic.BasicSpecialDefense;
		pokemonOwned.Speed = pokemonBasic.BasicSpeed;
		pokemonOwned.Happyness = 100;
		pokemonOwned.CurrentExperience = 0;
		pokemonOwned.Level = 5;

		switch (pokemonBasic.GrowthRate) {
		case "Fast":
			pokemonOwned.ExperienceNeeded = (4*pokemonOwned.Level*pokemonOwned.Level*pokemonOwned.Level)/5;
			break;

		case "Medium":
			pokemonOwned.ExperienceNeeded = pokemonOwned.Level*pokemonOwned.Level*pokemonOwned.Level;
			break;

		case "Slow":
			pokemonOwned.ExperienceNeeded = (5*pokemonOwned.Level*pokemonOwned.Level*pokemonOwned.Level)/4;
			break;
		}
		pokemonOwned.InTeam = false;
		_connection.Insert (pokemonOwned);

	}

	public void UpdatePokemon(int idPokemon, PokemonOwned newPokemon){
		PokemonOwned oldPokemon = _connection.Table<PokemonOwned> ().Where (x => x.Id == idPokemon).First();
		_connection.Delete (oldPokemon);
		newPokemon.Id = oldPokemon.Id;
		_connection.Insert (newPokemon);
	}

	public bool EquipPokemon(int idPokemon){
		bool equipped = true;
		List<PokemonOwned> list = _connection.Table<PokemonOwned> ().Where (x => x.InTeam == true).ToList();
		int equippedPokemons = list.Count ();
		if (equippedPokemons >= 3) {
			equipped = false;
		} else {
			_connection.Execute("Update PokemonOwned set InTeam = true where Id =",idPokemon);
		}
		return equipped;

	}

	public void UnEquipPokemon(int idPokemon){
		_connection.Execute("Update PokemonOwned set InTeam = false where Id =",idPokemon);
	}
}