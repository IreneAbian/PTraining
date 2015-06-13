using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MostrarDatosZonaBatalla : MonoBehaviour {

	public GameObject primerNombre;
	public GameObject segundoNombre;
	public GameObject tercerNombre;

	public GameObject primeraProgressBar;
	public GameObject segundaProgressBar;
	public GameObject tercerProgressBar;

	public GameObject pokemon1;
	public GameObject pokemon2;
	public GameObject pokemon3;

	void Start(){
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		PokemonBasicDAO pkmBasic = new PokemonBasicDAO ();
		List<PokemonOwned> listPokemon = pkmOwned.GetEquippedPokemon ().ToList();
		if (listPokemon.Count () == 1) {

            float amountFirst = ((listPokemon[0].Hp * 100) / listPokemon[0].HpTotal) / 100;
			pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
			PokemonBasic basico = pkmBasic.GetPokemon(listPokemon[0].Id);
			primerNombre.GetComponent<UILabel>().text = basico.Name+" Nvl "+listPokemon[0].Level;
            primeraProgressBar.GetComponent<UISprite>().fillAmount = (amountFirst);

		} else if (listPokemon.Count () == 2) {

            int resultFirst = ((listPokemon[0].Hp * 100) / listPokemon[0].HpTotal);
			float amountFirst = resultFirst / 100;
			pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
			PokemonBasic basico = pkmBasic.GetPokemon(listPokemon[0].IdBasic);
			primerNombre.GetComponent<UILabel>().text = basico.Name+" Nvl: "+listPokemon[0].Level;
            primeraProgressBar.GetComponent<UISprite>().fillAmount = amountFirst;

            int resultSecond = ((listPokemon[1].Hp * 100) / listPokemon[1].HpTotal);
			float amountSecond = resultSecond / 100;

			pokemon2.GetComponent<UISprite> ().spriteName = (listPokemon [1].IdBasic) + "";
			PokemonBasic segundoBasico = pkmBasic.GetPokemon(listPokemon[1].IdBasic);
			segundoNombre.GetComponent<UILabel>().text = segundoBasico.Name+" Nvl: "+listPokemon[1].Level;
            segundaProgressBar.GetComponent<UISprite>().fillAmount = amountSecond;

		} else if (listPokemon.Count () == 3) {

            float amountFirst = ((listPokemon[0].Hp * 100) / listPokemon[0].HpTotal) / 100;
			pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
			PokemonBasic basico = pkmBasic.GetPokemon(listPokemon[0].IdBasic);
			primerNombre.GetComponent<UILabel>().text = basico.Name+" Nvl: "+listPokemon[0].Level;
            primeraProgressBar.GetComponent<UISprite>().fillAmount = (amountFirst);

            float amountSecond = ((listPokemon[1].Hp * 100) / listPokemon[1].HpTotal) / 100;
			pokemon2.GetComponent<UISprite> ().spriteName = (listPokemon [1].IdBasic) + "";
			PokemonBasic segundoBasico = pkmBasic.GetPokemon(listPokemon[1].IdBasic);
			segundoNombre.GetComponent<UILabel>().text = segundoBasico.Name+" Nvl: "+listPokemon[1].Level;
            segundaProgressBar.GetComponent<UISprite>().fillAmount = amountSecond;

            float amountThird = ((listPokemon[2].Hp * 100) / listPokemon[2].HpTotal) / 100;
			pokemon3.GetComponent<UISprite> ().spriteName = (listPokemon [2].IdBasic) + "";
			PokemonBasic tercerBasico = pkmBasic.GetPokemon(listPokemon[2].IdBasic);
			tercerNombre.GetComponent<UILabel>().text = tercerBasico.Name+" Nvl: "+listPokemon[2].Level;
            tercerProgressBar.GetComponent<UISprite>().fillAmount = amountThird; 
		} 

	}

}
