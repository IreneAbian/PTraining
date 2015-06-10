using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MostrarDatosTercerPokemon : MonoBehaviour {

	public GameObject nombre;
	public GameObject nivel;
	public GameObject descripcion;
	public GameObject stats;
	public GameObject sprite;
	
	void Update () {
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		PokemonBasicDAO pkmBasic = new PokemonBasicDAO ();
		List<PokemonOwned> lista = pkmOwned.GetEquippedPokemon ().ToList ();
		if (lista.Count () > 2) {
			nivel.GetComponent<UILabel>().text = "Nvl: "+lista[2].Level;
			nombre.GetComponent<UILabel>().text = pkmBasic.GetPokemon(lista[2].IdBasic).Name;
			descripcion.GetComponent<UILabel>().text = pkmBasic.GetPokemon(lista[2].IdBasic).Description;
			UILabel datos = stats.GetComponent<UILabel>();
			datos.text = "";
			datos.text += "\nHp: "+lista[2].Hp+"/"+lista[2].HpTotal;
			datos.text += "\nAtaque: "+lista[2].Attack;
			datos.text += "\nDefensa: "+lista[2].Defense;
			datos.text += "\nAtaque especial: "+lista[2].SpecialAttack;
			datos.text += "\nDefensa especial: "+lista[2].SpecialDefense;
			datos.text += "\nVelocidad: "+lista[2].Speed;
			datos.text += "\nAguante: "+lista[2].Happyness;
			datos.text += "\nExperiencia: "+lista[2].CurrentExperience+"/"+lista[2].ExperienceNeeded;		
		}
		sprite.GetComponent<UISprite> ().spriteName = lista[2].IdBasic + "";
	}
}
