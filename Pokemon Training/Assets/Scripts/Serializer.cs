using UnityEngine;
using System.Collections;
using System.IO;

public class Serializer : MonoBehaviour {
	Texture2D imagen;
	byte[] real;
	void Start () {
		imagen = new Texture2D(0,0);
		PokemonBasicDAO pokm = new PokemonBasicDAO ();
		Texture2D texture = Resources.Load("Pokemon/001") as Texture2D;
//		pokm.InsertPokemon (001, Serialize (texture));
//		real = pokm.GetPokemonSprite (001);
	}

	public byte[] Serialize(Texture2D file){
		return file.EncodeToPNG();
	}

	public Texture2D Deserialize(byte[] file){
		Texture2D imagen = new Texture2D (0, 0);
		imagen.LoadImage (file);
		Debug.Log (file);
		return imagen;
	}

	void OnGUI(){
		GUILayout.BeginArea (new Rect(10, 10, Screen.width, Screen.height));
		GUILayout.Label (Deserialize (real));
		GUILayout.EndArea ();
	}
}
