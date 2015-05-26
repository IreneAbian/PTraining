using SQLite4Unity3d;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EggOwnedDAO{

	private SQLiteConnection _connection;

	public EggOwnedDAO(SQLiteConnection _connection){
		this._connection = _connection;

	}

	public EggOwned CreateEggOwned(string category){
		int[] options = new int[10]; 
        PokemonBasicDAO pbasic = new PokemonBasicDAO(_connection);
		List<PokemonBasic> list;
		EggOwned egg = new EggOwned ();
		if (category.Equals("Random")) {
			list = pbasic.GetPokemonBasics().ToList();
		} else {
			list = pbasic.GetBasicPokemonsOfType(category).ToList();
		}
		for (int i = 0; i < 10; i++){
			options[i] = Random.Range(0, list.Count);
		}
		egg.Options = options;
		egg.Category = category;
		egg.CurrentCycles = 0;
		egg.TotalCycles = 21;
		egg.Equipped = false;
		_connection.Insert (egg);
		return egg;
	}

	public EggOwned ReadEquippedEgg(){
		return _connection.Table<EggOwned> ().Where (x => x.Equipped == true).First();
	}

	public IEnumerable<EggOwned> ReadEggsOwned(){
		return _connection.Table<EggOwned> ();
	}

	public void DeleteEggOwned(int id){
		_connection.Execute ("Delete from EggOwned where Id = ?", id);
	}

	public void UpdateEggOwned(int idEgg, EggOwned newEggOwned){
		_connection.Execute ("Update EggOwned set CurrentCycles = " + newEggOwned.CurrentCycles + " where Id = ?", idEgg);
	}

	public void EquipEgg(int id){
		if (ReadEquippedEgg() != null) {
			ReadEquippedEgg().Equipped = false;
		}
		_connection.Execute ("Update EggOwned set Equipped = true where id = ?", id);

	}
}