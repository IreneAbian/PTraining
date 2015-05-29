using UnityEngine;
using System.Collections;

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

		if (player.ReadPlayer () == null) {
			UIController.instance.MostrarPanelNuevoJugador ();
		} else {
			UIController.instance.MostrarPanelContinuar();
		}
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

}