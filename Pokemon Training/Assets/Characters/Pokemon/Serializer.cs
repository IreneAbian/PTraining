﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Serializer : MonoBehaviour {
	BinaryFormatter bf;
	Sprite imagen;
	void Start () {
		PokemonBasicDAO pokm = new PokemonBasicDAO ();
		DirectoryInfo direc = new DirectoryInfo ("./Assets/Characters/Pokemon");
		FileInfo[] lista = direc.GetFiles ("*.gif");	
		bf = new BinaryFormatter ();	 		  
		Serialize (lista [1]);
	}

	public byte[] Serialize(FileInfo file){
		byte[] img;
		using(MemoryStream ms = new MemoryStream()){
			bf.Serialize(ms, file);
			img = ms.ToArray();
		}
		Debug.Log (img);
		return img;
	}

	public Sprite Deserialize(byte[] list){
		using(MemoryStream ms = new MemoryStream()){
			bf.Deserialize((Stream) list);
			imagen = (Sprite) ms.Read ();
		}
	}

	void OnGUI(){
		GUILayout.BeginArea (new Rect (30, 30, Screen.width, Screen.height));
		GUILayout.Label (imagen);
		GUILayout.EndArea ();
	}



}
