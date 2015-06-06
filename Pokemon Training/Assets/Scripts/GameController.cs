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
		jugador.transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y-0.25f);
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
		Player playerRead = playerD.GetPlayer();
		if (precio > playerRead.Gold){
			pagado = false;
		} else {
			player.UpdateGold(playerRead.Gold - precio);
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
		return hpACurar;
	}


}