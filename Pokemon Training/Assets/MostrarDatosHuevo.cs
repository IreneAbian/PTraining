using UnityEngine;
using System.Collections;

public class MostrarDatosHuevo : MonoBehaviour {

	public GameObject nombre;
	public GameObject descripcion;
	public GameObject stats;
	public GameObject sprite;

	void Update(){
		EggOwnedDAO eggOwned = new EggOwnedDAO ();
		EggOwned owned = eggOwned.GetEquippedEgg ();
		nombre.GetComponent<UILabel> ().text = "Huevo " + owned.Category;
		descripcion.GetComponent<UILabel> ().text = "Un huevo de tipo " + owned.Category;
		stats.GetComponent<UILabel> ().text = "Ciclos: " + owned.CurrentCycles + "/" + owned.TotalCycles;
		sprite.GetComponent<UISprite> ().spriteName = "Egg";
	}
}
