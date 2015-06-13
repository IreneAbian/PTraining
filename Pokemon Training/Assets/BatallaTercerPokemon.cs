using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BatallaTercerPokemon : MonoBehaviour {

	public GameObject texto;	
	public GameObject sprite1;
	public GameObject sprite2;

	public GameObject datosPrimero;
	public GameObject datosSegundo;

	private bool miTurno;
	
	public void GenerarBatalla(){
		UILabel label = texto.GetComponent<UILabel> ();
		label.text = "";

		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		PokemonBasicDAO pkmBasic = new PokemonBasicDAO ();
		PlayerDAO player = new PlayerDAO ();
		List<PokemonOwned> lista = pkmOwned.GetEquippedPokemon ().ToList ();
		PokemonOwned owned = lista [2];
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
		datosPrimero.GetComponent<UILabel> ().text = pkmBasic.GetPokemon (owned.IdBasic).Name;
		datosSegundo.GetComponent<UILabel> ().text = pkmBasic.GetPokemon (enemy.IdBasic).Name;

		while (enemy.Hp > 0 && owned.Hp > 0) {
			if (miTurno) {
				int dano = owned.Attack - enemy.Defense/2;
				if (dano < 0){
					dano = 0;
				}
				enemy.Hp -= dano;
				miTurno = false;
				label.text = label.text + "\nMi turno. Aliado infringe " + dano + " puntos de daño. Hp actual del enemigo: " + enemy.Hp;
			} else {
				int dano = enemy.Attack - owned.Defense/2;
				if (dano < 0){
					dano = 0;
				}
				owned.Hp -= dano;
				miTurno = true;
				label.text = label.text + "\nTurno del enemigo. Enemigo infringe " + dano + " puntos de daño. Hp actual del aliado: " + owned.Hp;
			}
		}
		
		if (owned.Hp < 1) {
			pkmOwned.UpdatePokemonHealth(owned.Id, owned.Hp);
			label.text = label.text + "\n\nBatalla perdida, pierdes " + enemy.Hp + " de oro";
			player.UpdateGold (player.GetPlayer ().Gold - enemy.Hp);
		} else {
			pkmOwned.UpdatePokemonHealth(owned.Id, owned.Hp);
			label.text = label.text + "\n\nBatalla ganada, ganas " + owned.Hp + " de oro";
			player.UpdateGold (player.GetPlayer ().Gold + owned.Hp);
		}
	}
}
