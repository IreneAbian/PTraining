using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MostrarDatosTienda : MonoBehaviour {
	
	public GameObject prefabItem;
	public GameObject prefabEgg;
	public bool mostrarItems;
	public GameObject parentGrid;

	public bool actualizarTienda; 
	void Start(){
		mostrarItems = true;
		actualizarTienda = true;
	}
	
	void Update(){

		if (actualizarTienda) {
			if (mostrarItems) {
				int childs = parentGrid.transform.childCount;
				for (int i = 0; i < childs; i++) {
					Destroy (parentGrid.transform.GetChild (i).gameObject);
				}
				ItemsBasicDAO itemsBasic = new ItemsBasicDAO ();
				List<ItemsBasic> lista = itemsBasic.GetItemsBasic ().ToList ();
				for (int i = 0; i < lista.Count(); i++) {
					GameObject item = Instantiate (prefabItem) as GameObject;
					item.transform.name = lista [i].Name;
					item.GetComponentInChildren<UILabel> ().text = lista [i].Name+" Precio: "+lista[i].Price;
					item.transform.parent = parentGrid.transform;
					item.transform.localScale = new Vector3 (1, 1, 1);
				}
			} else {
				int childs = parentGrid.transform.childCount;
				for (int i = 0; i < childs; i++) {
					Destroy (parentGrid.transform.GetChild (i).gameObject);
				}
				EggBasicDAO eggBasic = new EggBasicDAO ();
				List<EggBasic> lista = eggBasic.GetEggBasicList ().ToList ();
				for (int i = 0; i < lista.Count(); i++) {
					GameObject egg = Instantiate (prefabEgg) as GameObject;
					egg.transform.name = lista [i].Category;
					egg.GetComponentInChildren<UILabel> ().text = "Huevo " + lista [i].Category+" Precio: "+lista[i].Price;
					egg.transform.parent = parentGrid.transform;
					egg.transform.localScale = new Vector3 (1, 1, 1);
				}
			}
			parentGrid.GetComponent<UIGrid> ().repositionNow = true;
			actualizarTienda = false;
		}
	}
}
