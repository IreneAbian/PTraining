using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MostrarDatosEquipoHospital : MonoBehaviour {

	public GameObject pokemon1;
	public GameObject pokemon2;
	public GameObject pokemon3;

	public GameObject progressBar1;
	public GameObject progressBar2;
	public GameObject progressBar3;

	public GameObject precio;

	void Start(){
		precio.GetComponent<UILabel> ().text = "Precio: " + GameController.instance.CalcularPrecioHospital ();

		PokemonOwnedDAO pkmowned = new PokemonOwnedDAO ();
		List<PokemonOwned> listPokemon = pkmowned.GetEquippedPokemon ().ToList();
		if (listPokemon.Count () == 1) {

			pokemon1.GetComponent<UISprite>().spriteName = (listPokemon[0].IdBasic)+"";
			progressBar1.GetComponent<UISprite>().fillAmount = (listPokemon[0].Hp / listPokemon[0].HpTotal);

		} else if (listPokemon.Count () == 2) {

			pokemon1.GetComponent<UISprite>().spriteName = (listPokemon[0].IdBasic)+"";
			progressBar1.GetComponent<UISprite>().fillAmount = (listPokemon[0].Hp / listPokemon[0].HpTotal);

			pokemon2.GetComponent<UISprite>().spriteName = (listPokemon[1].IdBasic)+"";
			progressBar2.GetComponent<UISprite>().fillAmount = (listPokemon[1].Hp / listPokemon[1].HpTotal);
			
		} else if (listPokemon.Count () == 3) {

			pokemon1.GetComponent<UISprite>().spriteName = (listPokemon[0].IdBasic)+"";		
			progressBar1.GetComponent<UISprite>().fillAmount = (listPokemon[0].Hp / listPokemon[0].HpTotal);

			pokemon2.GetComponent<UISprite>().spriteName = (listPokemon[1].IdBasic)+"";
			progressBar2.GetComponentInParent<UISlider>().sliderValue = listPokemon[1].HpTotal;
			progressBar2.GetComponent<UISprite>().fillAmount = listPokemon[1].Hp;

			pokemon3.GetComponent<UISprite>().spriteName = (listPokemon[2].IdBasic)+"";
			progressBar3.GetComponentInParent<UISlider>().sliderValue = listPokemon[2].HpTotal;
			progressBar3.GetComponent<UISprite>().fillAmount = listPokemon[2].Hp;
		}
	}


}