using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MostrarDatosZonaBatalla : MonoBehaviour {

	public GameObject primerNombre;
	public GameObject segundoNombre;
	public GameObject tercerNombre;

	public GameObject progressBar1;
	public GameObject progressBar2;
	public GameObject progressBar3;

	public GameObject pokemon1;
	public GameObject pokemon2;
	public GameObject pokemon3;

	void Update(){
		PokemonOwnedDAO pkmowned = new PokemonOwnedDAO ();
		List<PokemonOwned> listPokemon = pkmowned.GetEquippedPokemon ().ToList();
		if (listPokemon.Count () == 1) {
			
			float amountFirst = (listPokemon[0].Hp * 100)/listPokemon[0].HpTotal;
			pokemon1.GetComponent<UISprite>().spriteName = (listPokemon[0].IdBasic)+"";
			GameObject fore = progressBar1.transform.FindChild("ForegroundBar000").gameObject;
			fore.GetComponent<UISprite>().fillAmount = (amountFirst/100);
			
			GameObject fore2 = progressBar2.transform.FindChild("ForegroundBar001").gameObject;
			fore2.GetComponent<UISprite>().fillAmount = 0;
			
			GameObject fore3 = progressBar3.transform.FindChild("ForegroundBar002").gameObject;
			fore3.GetComponent<UISprite>().fillAmount = 0;
			
		} else if (listPokemon.Count () == 2) {
			
			float amountFirst = (listPokemon[0].Hp * 100)/listPokemon[0].HpTotal;
			pokemon1.GetComponent<UISprite>().spriteName = (listPokemon[0].IdBasic) + "";
			GameObject fore = progressBar1.transform.FindChild("ForegroundBar000").gameObject;
			fore.GetComponent<UISprite>().fillAmount = (amountFirst/100);
			
			float amountSecond = (listPokemon[1].Hp * 100) / listPokemon[1].HpTotal;
			pokemon2.GetComponent<UISprite>().spriteName = (listPokemon[1].IdBasic)+"";
			GameObject fore2 = progressBar2.transform.FindChild("ForegroundBar001").gameObject;
			fore2.GetComponent<UISprite>().fillAmount = (amountSecond/100);
			
			GameObject fore3 = progressBar3.transform.FindChild("ForegroundBar002").gameObject;
			fore3.GetComponent<UISprite>().fillAmount = 0;
			
		} else if (listPokemon.Count () == 3) {
			
			float amountFirst = (listPokemon[0].Hp * 100)/listPokemon[0].HpTotal;
			pokemon1.GetComponent<UISprite>().spriteName = (listPokemon[0].IdBasic) + "";
			GameObject fore = progressBar1.transform.FindChild("ForegroundBar000").gameObject;
			fore.GetComponent<UISprite>().fillAmount = (amountFirst/100);
			
			float amountSecond = (listPokemon[1].Hp * 100) / listPokemon[1].HpTotal;
			pokemon2.GetComponent<UISprite>().spriteName = (listPokemon[1].IdBasic)+"";
			GameObject fore2 = progressBar2.transform.FindChild("ForegroundBar001").gameObject;
			fore2.GetComponent<UISprite>().fillAmount = (amountSecond/100);
			
			float amountThird = ((listPokemon[2].Hp * 100) / listPokemon[2].HpTotal);
			pokemon3.GetComponent<UISprite>().spriteName = (listPokemon[2].IdBasic)+"";
			GameObject fore3 = progressBar3.transform.FindChild("ForegroundBar002").gameObject;
			fore3.GetComponent<UISprite>().fillAmount = (amountThird/100);
			
		} else if (listPokemon.Count() == 0) {
			pokemon1.GetComponent<UISprite>().spriteName = "0";
			pokemon2.GetComponent<UISprite>().spriteName = "0";
			pokemon3.GetComponent<UISprite>().spriteName = "0";
			
			GameObject fore = progressBar1.transform.FindChild("ForegroundBar000").gameObject;
			fore.GetComponent<UISprite>().fillAmount = 0;
			
			GameObject fore2 = progressBar2.transform.FindChild("ForegroundBar001").gameObject;
			fore2.GetComponent<UISprite>().fillAmount = 0;
			
			GameObject fore3 = progressBar3.transform.FindChild("ForegroundBar002").gameObject;
			fore3.GetComponent<UISprite>().fillAmount = 0;
		}
}
}
