using SQLite4Unity3d;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EggOwnedDAO{

	public EggOwned CreateEggOwned(string category){
		int[] options = new int[10]; 
        PokemonBasicDAO pbasic = new PokemonBasicDAO();
		List<PokemonBasic> list;
		EggOwned egg = new EggOwned ();
		if (category.Equals("Random")) {
			list = pbasic.GetPokemonBasics().ToList();
		} else {
			list = pbasic.GetBasicPokemonsOfType(category);
		}
		for (int i = 0; i < 10; i++){
			int resultado = Random.Range(0, list.Count);
			options[i] = list[resultado].Id;
		}

		egg.Option1 = options [0];
		egg.Option2 = options [1];
		egg.Option3 = options [2];
		egg.Option4 = options [3];
		egg.Option5 = options [4];
		egg.Option6 = options [5];
		egg.Option7 = options [6];
		egg.Option8 = options [7];
		egg.Option9 = options [8];
		egg.Option10 = options [9];

		egg.Category = category;
		egg.CurrentCycles = 0;
		egg.TotalCycles = 21;
		egg.Equipped = false;
		DataService.instance._connection.Insert (egg);
		return egg;
	}

	public EggOwned GetEquippedEgg(){
		return DataService.instance._connection.Table<EggOwned> ().Where (x => x.Equipped == true).FirstOrDefault();
	}

	public IEnumerable<EggOwned> ReadEggsOwned(){
		return DataService.instance._connection.Table<EggOwned> ().Where (x => x.Equipped == false);

	}

	public void DeleteEggOwned(int id){
		DataService.instance._connection.Execute ("Delete from EggOwned where Id = ?", id);
	}

	public void AumentarCiclo(int idEgg){
		EggOwned eggOwned = GetEquippedEgg ();
		int cycles = eggOwned.CurrentCycles++;
		if (cycles >= eggOwned.TotalCycles) {
			PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO();
			int random = Random.Range(0, 10);
			switch (random){
			case 0: 
				pkmOwned.CreatePokemonOwned(eggOwned.Option1);
				break;
			case 1: 
				pkmOwned.CreatePokemonOwned(eggOwned.Option2);

				break;
			case 2: 
				pkmOwned.CreatePokemonOwned(eggOwned.Option3);

				break;
			case 3: 
				pkmOwned.CreatePokemonOwned(eggOwned.Option4);

					break;
			case 4: 
				pkmOwned.CreatePokemonOwned(eggOwned.Option5);

					break;
			case 5: 
				pkmOwned.CreatePokemonOwned(eggOwned.Option6);

					break;
			case 6: 
				pkmOwned.CreatePokemonOwned(eggOwned.Option7);

					break;
			case 7: 
				pkmOwned.CreatePokemonOwned(eggOwned.Option8);

					break;
			case 8:
				pkmOwned.CreatePokemonOwned(eggOwned.Option9);
				break;
			case 9:
			case 10:
				pkmOwned.CreatePokemonOwned(eggOwned.Option10);
				break;

			}
			DeleteEggOwned(idEgg);
		} else {
			DataService.instance._connection.Execute ("Update EggOwned set CurrentCycles = " + cycles + " where Id = ?", idEgg);
		}

	}

	public void EquipEgg(int id){
		if (GetEquippedEgg() != null) {
			GetEquippedEgg().Equipped = false;
		}
		DataService.instance._connection.Execute ("Update EggOwned set Equipped = true where Id = ?", id);
	}

	public void DeleteAllEggs(){
		DataService.instance._connection.DeleteAll<PokemonOwned>();
	}
}