using UnityEngine;
using System.Collections;

public class BotonEquiparHuevo : MonoBehaviour {

	public bool sePuedeEquipar;
	void OnClick(){
		if (sePuedeEquipar) {
			EggOwnedDAO eggOwned = new EggOwnedDAO ();
			if (eggOwned.GetEquippedEgg () != null) {
				UIController.instance.MostrarPanelMensaje ("Ya tienes un huevo equipado\n Hasta que no eclosione no podras equiparte otro");
			} else {
				UIController.instance.MostrarPanelMensaje ("Te has equipado el huevo");
				eggOwned.EquipEgg (int.Parse (transform.name));
			}
		}
	}
}
