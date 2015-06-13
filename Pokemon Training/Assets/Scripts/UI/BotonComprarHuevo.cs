using UnityEngine;
using System.Collections;

public class BotonComprarHuevo : MonoBehaviour {

	public bool sePuedeComprar;
	void OnClick(){
		if (sePuedeComprar) {
			EggOwnedDAO eggOwned = new EggOwnedDAO ();
			EggBasicDAO eggBasic = new EggBasicDAO ();
			PlayerDAO playerDAO = new PlayerDAO ();
			int precioItem = eggBasic.GetEggBasic (transform.name).Price;
			if (precioItem > playerDAO.GetPlayer ().Gold) {
				UIController.instance.MostrarPanelMensaje ("No dispones del oro suficiente para comprar eso");
			} else {
				playerDAO.UpdateGold (playerDAO.GetPlayer ().Gold - precioItem);
				eggOwned.CreateEggOwned (transform.name);
				UIController.instance.MostrarTiendaHuevos();
			}
		}
	}
}
