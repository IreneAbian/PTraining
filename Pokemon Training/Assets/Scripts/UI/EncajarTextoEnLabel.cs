using UnityEngine;
using System.Collections;

public class EncajarTextoEnLabel : MonoBehaviour {

	void Start () {
		GetComponent<UILabel> ().lineWidth = Screen.width + 150;
	}
}
