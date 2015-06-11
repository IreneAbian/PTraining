using UnityEngine;
using System.Collections;

public class SacarPokemon : MonoBehaviour {

    void OnClick(){
        PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO();
        string nameObject = transform.parent.name;
        int idPokemon = int.Parse(nameObject.Substring(nameObject.Length - 3));
        if (pkmOwned.EquipPokemon(idPokemon))
        {
            UIController.instance.MostrarPanelPosada();
        }
        else
        {
            Debug.Log("Por alguna razón no puedes sacar al pokemon");
        }

    }
}
