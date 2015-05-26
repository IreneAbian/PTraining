using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
public class UIController : MonoBehaviour {
	DataService ds;
	// Use this for initialization
	void Start () {
		ds = new DataService ("PT");
		ds.CreateDB ();
	}
	
	void OnGUI(){
		List<GrowthRates> list = new GrowthRatesDAO (DataService.instance._connection).getGrowthRates().ToList();
		GUILayout.BeginArea (new Rect(10, 10, Screen.width, Screen.height));
		GUILayout.Label (list.Count()+""+list.Count()+""+list.Count()+""+list.Count()+""+list.Count()+""+list.Count()+""+list.Count()+"");
		GUILayout.EndArea ();
	}
}
