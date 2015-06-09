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

            float amountFirst = ((listPokemon[0].Hp * 100) / listPokemon[0].HpTotal) / 100;
			pokemon1.GetComponent<UISprite>().spriteName = (listPokemon[0].IdBasic)+"";
			progressBar1.GetComponent<UISprite>().fillAmount = (amountFirst);

		} else if (listPokemon.Count () == 2) {

            float amountFirst = ((listPokemon[0].Hp * 100) / listPokemon[0].HpTotal) / 100;
            pokemon1.GetComponent<UISprite>().spriteName = (listPokemon[0].IdBasic) + "";
            progressBar1.GetComponent<UISprite>().fillAmount = (amountFirst);

            float amountSecond = ((listPokemon[1].Hp * 100) / listPokemon[1].HpTotal) / 100;
			pokemon2.GetComponent<UISprite>().spriteName = (listPokemon[1].IdBasic)+"";
			progressBar2.GetComponent<UISprite>().fillAmount = (amountSecond);
			
		} else if (listPokemon.Count () == 3) {

            float amountFirst = ((listPokemon[0].Hp * 100) / listPokemon[0].HpTotal) / 100;
            pokemon1.GetComponent<UISprite>().spriteName = (listPokemon[0].IdBasic) + "";
            progressBar1.GetComponent<UISprite>().fillAmount = (amountFirst);

            float amountSecond = ((listPokemon[1].Hp * 100) / listPokemon[1].HpTotal) / 100;
            pokemon2.GetComponent<UISprite>().spriteName = (listPokemon[1].IdBasic) + "";
            progressBar2.GetComponent<UISprite>().fillAmount = (amountSecond);

            float amountThird = ((listPokemon[2].Hp * 100) / listPokemon[2].HpTotal) / 100;
			pokemon3.GetComponent<UISprite>().spriteName = (listPokemon[2].IdBasic)+"";
			progressBar3.GetComponent<UISprite>().fillAmount = amountThird;

        } else if (listPokemon.Count() == 0) {
            pokemon1.GetComponent<UISprite>().spriteName = "0";
            pokemon2.GetComponent<UISprite>().spriteName = "0";
            pokemon3.GetComponent<UISprite>().spriteName = "0";
            progressBar1.GetComponent<UISprite>().fillAmount = 0;
            progressBar2.GetComponent<UISprite>().fillAmount = 0;
            progressBar3.GetComponent<UISprite>().fillAmount = 0;
        }
	}


}