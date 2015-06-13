using UnityEngine;
using System.Collections;

public class SacarPokemon : MonoBehaviour {

    void OnClick(){
        PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO();
        int idPokemon = int.Parse(transform.name);
        if (pkmOwned.EquipPokemon (idPokemon)) {
			UIController.instance.MostrarPanelPosada ();
		} else {
			UIController.instance.MostrarPanelMensaje("Ya tienes 3 pokemon equipados");
		}
    }
}
