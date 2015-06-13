using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MostrarDatosEquipo : MonoBehaviour {

	public GameObject primerNombre;
	public GameObject segundoNombre;
	public GameObject tercerNombre;
	public GameObject huevo;
	
	public GameObject pokemon1;
	public GameObject pokemon2;
	public GameObject pokemon3;
	public GameObject huevoSprite;

	void Start(){
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		PokemonBasicDAO pkmBasic = new PokemonBasicDAO ();
		EggOwnedDAO eggOwned = new EggOwnedDAO ();
		List<PokemonOwned> listPokemon = pkmOwned.GetEquippedPokemon ().ToList ();
		if (listPokemon.Count () == 1) {
			
			pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
			PokemonBasic basico = pkmBasic.GetPokemon (listPokemon [0].Id);
			Debug.Log (basico);
			primerNombre.GetComponent<UILabel> ().text = basico.Name + " Nvl " + listPokemon [0].Level;

		} else if (listPokemon.Count () == 2) {
			
			pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
			PokemonBasic basico = pkmBasic.GetPokemon (listPokemon [0].IdBasic);
			primerNombre.GetComponent<UILabel> ().text = basico.Name + " Nvl: " + listPokemon [0].Level;
			
			pokemon2.GetComponent<UISprite> ().spriteName = (listPokemon [1].IdBasic) + "";
			PokemonBasic segundoBasico = pkmBasic.GetPokemon (listPokemon [1].IdBasic);
			segundoNombre.GetComponent<UILabel> ().text = segundoBasico.Name + " Nvl: " + listPokemon [1].Level;
			
		} else if (listPokemon.Count () == 3) {
			pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
			PokemonBasic basico = pkmBasic.GetPokemon (listPokemon [0].IdBasic);
			primerNombre.GetComponent<UILabel> ().text = basico.Name + " Nvl: " + listPokemon [0].Level;
			
			pokemon2.GetComponent<UISprite> ().spriteName = (listPokemon [1].IdBasic) + "";
			PokemonBasic segundoBasico = pkmBasic.GetPokemon (listPokemon [1].IdBasic);
			segundoNombre.GetComponent<UILabel> ().text = segundoBasico.Name + " Nvl: " + listPokemon [1].Level;
			
			pokemon3.GetComponent<UISprite> ().spriteName = (listPokemon [2].IdBasic) + "";
			PokemonBasic tercerBasico = pkmBasic.GetPokemon (listPokemon [2].IdBasic);
			tercerNombre.GetComponent<UILabel> ().text = tercerBasico.Name + " Nvl: " + listPokemon [2].Level;
			
		} 

		if (eggOwned.GetEquippedEgg () != null) {
			huevo.GetComponent<UILabel> ().text = "Huevo " + eggOwned.GetEquippedEgg ().Category;
			huevoSprite.GetComponent<UISprite>().spriteName = "Egg";
			huevoSprite.GetComponent<UISprite>().transform.localScale = new Vector3(200, 200, 1);
		} else {
			huevoSprite.GetComponent<UISprite>().spriteName = "0";
		}
	
	}
}
