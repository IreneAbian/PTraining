using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MostrarDatosSacarPokemon : MonoBehaviour {

	public GameObject prefabSacarPokemon;
	public bool actualizarLista;
	public GameObject parentGrid;


	void Start(){
		actualizarLista = true;
	}

	void Update(){

		if (actualizarLista){
		int childs = parentGrid.transform.childCount;
		for (int i = 0; i < childs; i++){
			Destroy(parentGrid.transform.GetChild(i).gameObject);
		}

        PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO();
        PokemonBasicDAO pkmBasic = new PokemonBasicDAO();
        List<PokemonOwned> lista = pkmOwned.GetNotEquippedPokemon().ToList();

        for (int i = 0; i < lista.Count(); i++){
        	GameObject pokemon = Instantiate(prefabSacarPokemon) as GameObject;
        	pokemon.transform.name = "Pokemon"+lista[i].Id;
        	pokemon.GetComponentInChildren<UISprite>().spriteName = lista[i].IdBasic+"";
        	PokemonBasic basic = pkmBasic.GetPokemon(lista[i].IdBasic);
        	pokemon.GetComponentInChildren<UILabel>().text = basic.Name+" Nivel "+lista[i].Level;
        	pokemon.transform.parent = parentGrid.transform;
			pokemon.transform.localScale = new Vector3(1,1,1);
        }
		parentGrid.GetComponent<UIGrid>().repositionNow = true;
		actualizarLista = false;
		}
	}


}