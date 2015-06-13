using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MostrarDatosPrimerPokemon : MonoBehaviour {

	public GameObject nombre;
	public GameObject descripcion;
	public GameObject stats;
	public GameObject sprite;

	void Update () {
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		PokemonBasicDAO pkmBasic = new PokemonBasicDAO ();
		List<PokemonOwned> lista = pkmOwned.GetEquippedPokemon ().ToList ();
		nombre.GetComponent<UILabel>().text = pkmBasic.GetPokemon(lista[0].IdBasic).Name;
		descripcion.GetComponent<UILabel>().text = pkmBasic.GetPokemon(lista[0].IdBasic).Description;
		UILabel datos = stats.GetComponent<UILabel>();
		datos.text = "";
		datos.text += "Nvl: "+lista[0].Level;
		datos.text += "\nHp: "+lista[0].Hp+"/"+lista[0].HpTotal;
		datos.text += "\nAtaque: "+lista[0].Attack;
		datos.text += "\nDefensa: "+lista[0].Defense;
		datos.text += "\nAtaque especial: "+lista[0].SpecialAttack;
		datos.text += "\nDefensa especial: "+lista[0].SpecialDefense;
		datos.text += "\nVelocidad: "+lista[0].Speed;
		datos.text += "\nAguante: "+lista[0].CurrentHappyness+"/"+lista[0].Happyness;
		datos.text += "\nExperiencia: "+lista[0].CurrentExperience+"/"+lista[0].ExperienceNeeded;		
		sprite.GetComponent<UISprite> ().spriteName = lista [0].IdBasic + "";
	}


}
