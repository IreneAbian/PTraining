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
		PokemonOwnedDAO pokmowned = new PokemonOwnedDAO ();
		List<PokemonOwned> lista = pokmowned.GetEquippedPokemon ().ToList();
		int hpACurar = 0;
		for (int i = 0; i < lista.Count(); i++){
			int hpLeft = lista[i].HpTotal - lista[i].Hp;
			Debug.Log(hpLeft);
			hpACurar += hpLeft;
		}
		precio.GetComponent<UILabel> ().text = "Precio: " + hpACurar;
	}


}