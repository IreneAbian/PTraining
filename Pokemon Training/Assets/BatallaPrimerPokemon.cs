using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BatallaPrimerPokemon : MonoBehaviour {

	public GameObject texto;
	
	public GameObject sprite1;
	public GameObject sprite2;

	private UILabel label;

	public bool miTurno;

	void Start(){
		label = texto.GetComponent<UILabel> ();
		label.text =  ("Empieza la batalla");

		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		PlayerDAO player = new PlayerDAO ();
		List<PokemonOwned> lista = pkmOwned.GetEquippedPokemon ().ToList ();
		PokemonOwned owned = lista [0];
		PokemonOwned enemy = pkmOwned.GenerarAleatorio ();

		while (enemy.Level != owned.Level) {
			enemy.LevelUp ();
		}
		if (enemy.Speed >= owned.Speed) {
			miTurno = false;
		}
		Debug.Log ("Pokemon enemigo: " + enemy);
		Debug.Log ("Mi pokemon: " + owned);
		sprite1.GetComponent<UISprite> ().spriteName = owned.IdBasic + "";
		sprite2.GetComponent<UISprite> ().spriteName = enemy.IdBasic + "";

		for (int i = 0; i < 20; i++) {
			if (enemy.Hp > 0 && owned.Hp > 0) {
				if (miTurno) {
					int dano = owned.Attack - enemy.Defense/2;
					enemy.Hp -= dano;
					miTurno = false;
					label.text = label.text + "\nMi turno. Aliado infringe " + dano + " puntos de daño. Hp actual del enemigo: " + enemy.Hp;
				} else {
					int dano = enemy.Attack - owned.Defense/2;
					owned.Hp -= dano;
					miTurno = true;
					label.text = label.text + "\nTurno del enemigo. Enemigo infringe " + dano + " puntos de daño. Hp actual del aliado: " + owned.Hp;
				}
			}


		}
		if (owned.Hp < 1) {
			label.text = label.text + "\n\nBatalla perdida, pierdes " + enemy.Hp + " de oro";
			player.UpdateGold (player.GetPlayer ().Gold - enemy.Hp);
		} else {
			label.text = label.text + "\n\nBatalla ganada, ganas " + owned.Hp + " de oro";
			player.UpdateGold (player.GetPlayer ().Gold + owned.Hp);
		}
	}
	
}
