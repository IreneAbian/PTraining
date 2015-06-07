using SQLite4Unity3d;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonOwnedDAO{
	
	public IEnumerable<PokemonOwned> GetEquippedPokemon(){
		return DataService.instance._connection.Table<PokemonOwned> ().Where (x => x.InTeam == true);
	}

	public IEnumerable<PokemonOwned> GetNotEquippedPokemon(){
		return DataService.instance._connection.Table<PokemonOwned> ().Where (x => x.InTeam == false);
	}

	public IEnumerable<PokemonOwned> GetOwnedPokemon(){
		return DataService.instance._connection.Table<PokemonOwned>();
	}

	public void CreatePokemonOwned(int basicId){
		PokemonBasic pokemonBasic = DataService.instance._connection.Table<PokemonBasic> ().Where (x => x.Id == basicId).First();
		PokemonOwned pokemonOwned = new PokemonOwned ();
		pokemonOwned.IdBasic = basicId;
		pokemonOwned.Hp = pokemonBasic.BasicHp;
		pokemonOwned.HpTotal = pokemonBasic.BasicHp;
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
		PokemonOwnedDAO pkmdao = new PokemonOwnedDAO ();
		pokemonOwned.Id = pkmdao.GetOwnedPokemon ().ToList().Count()+1;
		DataService.instance._connection.Insert (pokemonOwned);
	}

	public void UpdatePokemon(int idPokemon, PokemonOwned newPokemon){
		PokemonOwned oldPokemon = DataService.instance._connection.Table<PokemonOwned> ().Where (x => x.Id == idPokemon).First();
		DataService.instance._connection.Delete (oldPokemon);
		newPokemon.Id = oldPokemon.Id;
		DataService.instance._connection.Insert (newPokemon);
	}

	public void HealthPokemon(int idPokemon){
		PokemonOwned pokemon = GetPokemon (idPokemon);
		int hpTotal = pokemon.HpTotal;
		DataService.instance._connection.Execute("Update PokemonOwned set Hp = ?", hpTotal);
	}

	public PokemonOwned GetPokemon(int id){
		return 	DataService.instance._connection.Table<PokemonOwned> ().Where (x => x.Id == id).FirstOrDefault();
	}

	public bool EquipPokemon(int idPokemon){
		bool equipped = true;
		List<PokemonOwned> list = DataService.instance._connection.Table<PokemonOwned> ().Where (x => x.InTeam == true).ToList();
		int equippedPokemons = list.Count ();
		if (equippedPokemons >= 3) {
			equipped = false;
		} else {
			DataService.instance._connection.Execute("Update PokemonOwned set InTeam = 1 where Id = ?",idPokemon);
		}
		return equipped;
	}

	public void UnEquipPokemon(int idPokemon){
		DataService.instance._connection.Execute("Update PokemonOwned set InTeam = 0 where Id = ?",idPokemon);
	}

	public void DeleteAllPokemon(){
		DataService.instance._connection.DeleteAll<PokemonOwned> ();
	}


}