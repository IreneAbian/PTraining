using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MostrarDatosZonaEntrenamiento : MonoBehaviour {

	public GameObject nombreHuevo;
	public GameObject nombre1;
	public GameObject nombre2;
	public GameObject nombre3;

	public GameObject spriteHuevo;
	public GameObject pokemon1;
	public GameObject pokemon2;
	public GameObject pokemon3;

	public GameObject barraHuevo;
	public GameObject progressBar1;
	public GameObject progressBar2;
	public GameObject progressBar3;

	public GameObject barraExperiencia1;
	public GameObject barraExperiencia2;
	public GameObject barraExperiencia3;

	bool actualizarDatos;

	int steps;
	float loLim = 0.005f;
	float hiLim = 0.1f;
	float fHigh = 10.0f;
	float curAcc = 0f;
	float fLow = 0.1f;
	float avgAcc = 0.0f;

	void Start(){
		actualizarDatos = true;
		avgAcc = Input.acceleration.magnitude;
		steps = 0;
	}
	void Update(){
		PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
		List<PokemonOwned> listPokemon = pkmOwned.GetEquippedPokemon ().ToList ();
		PokemonBasicDAO pkmBasic = new PokemonBasicDAO ();
		EggOwnedDAO eggOwned = new EggOwnedDAO ();
		if (actualizarDatos) {
			if (listPokemon.Count () == 1) {

				float amountFirst = (listPokemon [0].CurrentHappyness * 100) / listPokemon [0].Happyness;
				nombre1.GetComponent<UILabel>().text = pkmBasic.GetPokemon(listPokemon[0].IdBasic).Name;
				pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";

				GameObject fore = progressBar1.transform.FindChild ("ForegroundBar000").gameObject;
				fore.GetComponent<UISprite> ().fillAmount = (amountFirst / 100);
			
				float amountExp = (listPokemon[0].CurrentExperience * 100)/ listPokemon[0].ExperienceNeeded;
				GameObject foreExp = barraExperiencia1.transform.Find("ForeExp000").gameObject;
				foreExp.GetComponent<UISprite>().fillAmount = (amountExp/100);
			} else if (listPokemon.Count () == 2) {
			
				float amountFirst = (listPokemon [0].CurrentHappyness * 100) / listPokemon [0].Happyness;
				nombre1.GetComponent<UILabel>().text = pkmBasic.GetPokemon(listPokemon[0].IdBasic).Name;
				pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
				GameObject fore = progressBar1.transform.FindChild ("ForegroundBar000").gameObject;
				fore.GetComponent<UISprite> ().fillAmount = (amountFirst / 100);
			
				float amountExp = (listPokemon[0].CurrentExperience * 100)/ listPokemon[0].ExperienceNeeded;
				GameObject foreExp = barraExperiencia1.transform.Find("ForeExp000").gameObject;
				foreExp.GetComponent<UISprite>().fillAmount = (amountExp/100);

				float amountSecond = ((listPokemon [1].CurrentHappyness * 100) / listPokemon [1].Happyness);
				nombre2.GetComponent<UILabel>().text = pkmBasic.GetPokemon(listPokemon[1].IdBasic).Name;
				pokemon2.GetComponent<UISprite> ().spriteName = (listPokemon [1].IdBasic) + "";
				GameObject fore2 = progressBar2.transform.FindChild ("ForegroundBar001").gameObject;
				fore2.GetComponent<UISprite> ().fillAmount = (amountSecond / 100);
			
				float amountExp2 = (listPokemon[1].CurrentExperience*100)/listPokemon[1].ExperienceNeeded;
				GameObject foreExp2 = barraExperiencia2.transform.Find ("ForeExp001").gameObject;
				foreExp2.GetComponent<UISprite>().fillAmount = amountExp2/100;

			} else if (listPokemon.Count () == 3) {
			
				float amountFirst = (listPokemon [0].CurrentHappyness * 100) / listPokemon [0].Happyness;
				nombre1.GetComponent<UILabel>().text = pkmBasic.GetPokemon(listPokemon[0].IdBasic).Name;
				pokemon1.GetComponent<UISprite> ().spriteName = (listPokemon [0].IdBasic) + "";
				GameObject fore = progressBar1.transform.FindChild ("ForegroundBar000").gameObject;
				fore.GetComponent<UISprite> ().fillAmount = (amountFirst / 100);
			
				float amountExp = (listPokemon[0].CurrentExperience * 100)/ listPokemon[0].ExperienceNeeded;
				GameObject foreExp = barraExperiencia1.transform.Find("ForeExp000").gameObject;
				foreExp.GetComponent<UISprite>().fillAmount = (amountExp/100);

				float amountSecond = ((listPokemon [1].CurrentHappyness * 100) / listPokemon [1].Happyness);
				nombre2.GetComponent<UILabel>().text = pkmBasic.GetPokemon(listPokemon[1].IdBasic).Name;
				pokemon2.GetComponent<UISprite> ().spriteName = (listPokemon [1].IdBasic) + "";
				GameObject fore2 = progressBar2.transform.FindChild ("ForegroundBar001").gameObject;
				fore2.GetComponent<UISprite> ().fillAmount = (amountSecond / 100);
			
				float amountExp2 = (listPokemon[1].CurrentExperience*100)/listPokemon[1].ExperienceNeeded;
				GameObject foreExp2 = barraExperiencia2.transform.Find ("ForeExp001").gameObject;
				foreExp2.GetComponent<UISprite>().fillAmount = amountExp2/100;

				float amountThird = ((listPokemon [2].CurrentHappyness * 100) / listPokemon [2].Happyness);
				nombre3.GetComponent<UILabel>().text = pkmBasic.GetPokemon(listPokemon[2].IdBasic).Name;
				pokemon3.GetComponent<UISprite> ().spriteName = (listPokemon [2].IdBasic) + "";
				GameObject fore3 = progressBar3.transform.FindChild ("ForegroundBar002").gameObject;
				fore2.GetComponent<UISprite> ().fillAmount = (amountThird / 100);
			
				float amountExp3 = (listPokemon[2].CurrentExperience*100)/listPokemon[2].ExperienceNeeded;
				GameObject foreExp3 = barraExperiencia3.transform.Find("ForeExp002").gameObject;
				foreExp3.GetComponent<UISprite>().fillAmount = amountExp3/100;

			} else if (listPokemon.Count () == 0) {
				pokemon1.GetComponent<UISprite> ().spriteName = "0";
				pokemon2.GetComponent<UISprite> ().spriteName = "0";
				pokemon3.GetComponent<UISprite> ().spriteName = "0";
			}
			actualizarDatos = false;
			if (eggOwned.GetEquippedEgg() != null){
				EggOwned egg = eggOwned.GetEquippedEgg();
				nombreHuevo.GetComponent<UILabel>().text = "Huevo "+egg.Category;
				float amountEgg = ((egg.CurrentCycles * 100) / egg.TotalCycles);
				GameObject fore = barraHuevo.transform.FindChild ("Foreground").gameObject;
				fore.GetComponent<UISprite>().fillAmount = amountEgg / 100;
				spriteHuevo.GetComponent<UISprite>().transform.localScale = new Vector3(150, 150, 0);
			} else {
				spriteHuevo.GetComponent<UISprite>().spriteName = "0";
			}
		}
	}

	void FixedUpdate(){
		curAcc = Mathf.Lerp (curAcc, Input.acceleration.magnitude, fHigh);
		avgAcc = Mathf.Lerp (avgAcc, Input.acceleration.magnitude, fLow);
		float delta = curAcc - avgAcc;
		if (delta > hiLim){
			steps++;
		}

		if (steps > 100) {
			actualizarDatos = true;

			PokemonOwnedDAO pkmOwned = new PokemonOwnedDAO ();
			List<PokemonOwned> listPokemon = pkmOwned.GetEquippedPokemon ().ToList ();
			PlayerDAO playerDAO = new PlayerDAO();
			EggOwnedDAO eggOwned = new EggOwnedDAO();
			for (int i = 0; i < listPokemon.Count(); i++){
				listPokemon[i].CurrentHappyness -= 10;
				listPokemon[i].CurrentExperience += 15;
				if (listPokemon[i].CurrentExperience > listPokemon[i].ExperienceNeeded){
					listPokemon[i].LevelUp();
					playerDAO.UpdateGold(playerDAO.GetPlayer().Gold + (listPokemon[i].Level*5)); 
				}
				pkmOwned.UpdatePokemon(listPokemon[i].Id, listPokemon[i]);

			}
			if (eggOwned.GetEquippedEgg() != null){
				eggOwned.AumentarCiclo();
			}
			steps = 0;
		}
	}
}
