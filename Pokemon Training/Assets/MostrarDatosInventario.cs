using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MostrarDatosInventario : MonoBehaviour {

	public GameObject prefabOwnedItem;
	public GameObject prefabOwnedEgg;
	public bool mostrarItems;
	public GameObject parentGrid;
	public bool actualizarInventario;

	void Start(){
		mostrarItems = true;
		actualizarInventario = true;
	}

	void Update(){
		if (actualizarInventario) {
			if (mostrarItems) {
				int childs = parentGrid.transform.childCount;
				for (int i = 0; i < childs; i++) {
					Destroy (parentGrid.transform.GetChild (i).gameObject);
				}
				ItemsOwnedDAO itemsOwned = new ItemsOwnedDAO ();
				List<ItemsOwned> lista = itemsOwned.GetItemsOwned ().ToList ();
				for (int i = 0; i < lista.Count(); i++) {
					GameObject item = Instantiate (prefabOwnedItem) as GameObject;
					item.transform.name = "Item" + lista [i].Id;
					item.GetComponentInChildren<UILabel> ().text = lista [i].NameBasic;
					item.transform.parent = parentGrid.transform;
					item.transform.localScale = new Vector3 (1, 1, 1);
				}
			} else {
				int childs = parentGrid.transform.childCount;
				for (int i = 0; i < childs; i++) {
					Destroy (parentGrid.transform.GetChild (i).gameObject);
				}
				EggOwnedDAO eggOwned = new EggOwnedDAO ();
				List<EggOwned> lista = eggOwned.ReadEggsOwned ().ToList ();
				for (int i = 0; i < lista.Count(); i++) {
					GameObject egg = Instantiate (prefabOwnedEgg) as GameObject;
					egg.transform.name = "Egg" + lista [i].Id;
					egg.GetComponentInChildren<UILabel> ().text = "Huevo " + lista [i].Category;
					egg.transform.parent = parentGrid.transform;
					egg.transform.localScale = new Vector3 (1, 1, 1);
				}
			}
			parentGrid.GetComponent<UIGrid> ().repositionNow = true;
			actualizarInventario = false;
		}
	}

}