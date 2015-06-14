using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameController : MonoBehaviour {

	public static GameController instance = null;
	public GameObject mapa;
	PlayerDAO player;
	public GameObject jugador;

	void Awake(){
		DataService ds = new DataService ("PT");
	}

	void Start(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy(instance);
		}

		player = new PlayerDAO ();

		if (player.GetPlayer () == null) {
			UIController.instance.MostrarPanelNuevoJugador ();
		} else {
			UIController.instance.MostrarPanelContinuar();
		}
		ImpedirMovimientoJugador ();
	}

	public void MostrarMapa(){
		mapa.SetActive (true);
		jugador.SetActive (true);
	}

	public void OcultarMapa(){
		mapa.SetActive (false);
		jugador.SetActive (false);
	}

	public void RetrocederJugador(){
		jugador.transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y-0.05f);
	}

	public void ImpedirMovimientoJugador(){
		jugador.GetComponent<PlayerMovement> ().enabled = false;
	}

	public void PermitirMovimientoJugador(){
		jugador.GetComponent<PlayerMovement> ().enabled = true;
	}

	public bool PagarHospital(){
		int precio = CalcularPrecioHospital ();
		bool pagado = true;
		PlayerDAO playerD = new PlayerDAO();
		if (precio > playerD.GetPlayer().Gold){
			pagado = false;
		} else {
			player.UpdateGold(playerD.GetPlayer().Gold - precio);
		}
		return pagado;
	}

	public int CalcularPrecioHospital(){
		PokemonOwnedDAO pokmowned = new PokemonOwnedDAO ();
		List<PokemonOwned> lista = pokmowned.GetEquippedPokemon ().ToList();
		int hpACurar = 0;
		for (int i = 0; i < lista.Count(); i++){
			int hpLeft = lista[i].HpTotal - lista[i].Hp;
			hpACurar += hpLeft;
		}
		return Mathf.FloorToInt(hpACurar/5);
	}

	public int CalcularExperienciaNecesaria(PokemonOwned pokemonOwned){
		PokemonBasicDAO pkmBasic = new PokemonBasicDAO ();
		int exp = 0;

		switch (pkmBasic.GetPokemon(pokemonOwned.IdBasic).GrowthRate) {
		case "Fast":
			exp = Mathf.FloorToInt((4*pokemonOwned.Level*pokemonOwned.Level*pokemonOwned.Level)/5);
			break;
			
		case "Medium":
			exp = Mathf.FloorToInt(pokemonOwned.Level*pokemonOwned.Level*pokemonOwned.Level);
			break;
			
		case "Slow":
			exp = Mathf.FloorToInt((5*pokemonOwned.Level*pokemonOwned.Level*pokemonOwned.Level)/4);
			break;
		}

		return exp;
	}

	public void UsarItem(int id){
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		ItemsOwnedDAO itemsOwned = new ItemsOwnedDAO ();
		PokemonOwned seleccionado = pkmOwned.GetPokemon (id);
		ItemsOwned itemSelected = itemsOwned.GetItemOwned (UIController.instance.itemSeleccionado);
		int happynessFinal;
		switch (itemSelected.NameBasic) {
		case "Pocion Aguante 20":
			happynessFinal = seleccionado.CurrentHappyness+20;
			if (happynessFinal > seleccionado.Happyness){
				seleccionado.CurrentHappyness = seleccionado.Happyness;
			} else {
				seleccionado.CurrentHappyness += 20;
			}
			pkmOwned.UpdatePokemon(seleccionado);
			itemsOwned.DeleteItemOwned(itemSelected.Id);
		break;
		case "Pocion Aguante 40":
			happynessFinal = seleccionado.CurrentHappyness+40;
			if (happynessFinal > seleccionado.Happyness){
				seleccionado.CurrentHappyness = seleccionado.Happyness;
			} else {
				seleccionado.CurrentHappyness += 40;
			}
			pkmOwned.UpdatePokemon(seleccionado);
			itemsOwned.DeleteItemOwned(itemSelected.Id);
			break;
		}
	}

}