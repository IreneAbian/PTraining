using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DataService ds = DataService ("PT");
		ds.CreateDB ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
