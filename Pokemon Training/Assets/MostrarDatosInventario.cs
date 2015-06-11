using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MostrarDatosInventario : MonoBehaviour {

	public GameObject prefabOwnedItem;
	public GameObject prefabOwnedEgg;
	public bool mostrarItems;
	public GameObject parentGrid;

	void Start(){
		mostrarItems = true;
	}

	void Update(){

		if (mostrarItems){
			ItemsOwnedDAO itemsOwned = new ItemsOwnedDAO();
			List<ItemsOwned> lista = itemsOwned.GetItemsOwned().ToList();
			for (int i = 0; i < lista.Count(); i++){
				GameObject item = Instantiate(prefabOwnedItem) as GameObject;
				item.transform.name = "Item"+lista[i].Id;
				item.GetComponentInChildren<UILabel>().text = lista[i].NameBasic;
				item.transform.parent = parentGrid.transform;
			}
		} else {
			EggOwnedDAO eggOwned = new EggOwnedDAO();
			List<EggOwned> lista = eggOwned.ReadEggsOwned().ToList();
			for (int i = 0; i < lista.Count(); i++){
				GameObject egg = Instantiate(prefabOwnedEgg) as GameObject;
				egg.transform.name = "Egg"+lista[i].Id;
				egg.GetComponentInChildren<UILabel>().text = "Huevo " + lista[i].Category;
				egg.transform.parent = parentGrid.transform;
			}
		}
	}

}