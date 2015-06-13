using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MostrarDatosSegundoPokemon : MonoBehaviour {

	public GameObject nombre;
	public GameObject descripcion;
	public GameObject stats;
	public GameObject sprite;
	
	void Update () {
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		PokemonBasicDAO pkmBasic = new PokemonBasicDAO ();
		List<PokemonOwned> lista = pkmOwned.GetEquippedPokemon ().ToList ();
		nombre.GetComponent<UILabel>().text = pkmBasic.GetPokemon(lista[1].IdBasic).Name;
		descripcion.GetComponent<UILabel>().text = pkmBasic.GetPokemon(lista[1].IdBasic).Description;
		UILabel datos = stats.GetComponent<UILabel>();
		datos.text = "";
		datos.text += "Nvl: "+lista[1].Level;
		datos.text += "\nHp: "+lista[1].Hp+"/"+lista[1].HpTotal;
		datos.text += "\nAtaque: "+lista[1].Attack;
		datos.text += "\nDefensa: "+lista[1].Defense;
		datos.text += "\nAtaque especial: "+lista[1].SpecialAttack;
		datos.text += "\nDefensa especial: "+lista[1].SpecialDefense;
		datos.text += "\nVelocidad: "+lista[1].Speed;
		datos.text += "\nAguante: "+lista[1].CurrentHappyness+"/"+lista[1].Happyness;
		datos.text += "\nExperiencia: "+lista[1].CurrentExperience+"/"+lista[1].ExperienceNeeded;		
		sprite.GetComponent<UISprite> ().spriteName = lista [1].IdBasic + "";
	}


}
