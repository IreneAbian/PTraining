using UnityEngine;
using System.Collections;

public class BotonComprarItem : MonoBehaviour {

	public bool sePuedeComprar;
	void OnClick(){
		if (sePuedeComprar) {
			ItemsOwnedDAO itemsOwned = new ItemsOwnedDAO ();
			ItemsBasicDAO itemsBasic = new ItemsBasicDAO ();
			PlayerDAO playerDAO = new PlayerDAO ();
			int precioItem = itemsBasic.GetItemBasic (transform.name).Price;
			if (precioItem > playerDAO.GetPlayer ().Gold) {
				UIController.instance.MostrarPanelMensaje ("No dispones del oro suficiente para comprar eso");
			} else {
				playerDAO.UpdateGold (playerDAO.GetPlayer ().Gold - precioItem);
				itemsOwned.CreateItemOwned (transform.name);
				UIController.instance.MostrarPanelTienda();
			}
		}
	}
}
