using SQLite4Unity3d;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System;

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

//	public void InsertPokemon(int id, byte[] sprite){
//		DataService.instance._connection.Execute ("Insert into PokemonBasic (Id, SpriteImage) values (" + id + ", '" + Encoding.Default.GetString(sprite) + "')");
//	}
//
//	public byte[] GetPokemonSprite(int id){
//		PokemonBasic pkm = DataService.instance._connection.Table<PokemonBasic> ().Where (x => x.Id == id).First ();
//		return System.Text.Encoding.UTF8.GetBytes(pkm.SpriteImage);
//	}
}
