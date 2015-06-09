using UnityEngine;
using System.Collections;

public class AjustarCollidersBotones : MonoBehaviour {

	void Start () {
		BoxCollider collider = GetComponent<BoxCollider> ();
		UISprite sprite = gameObject.GetComponentInChildren<UISprite> ();
		collider.size = sprite.transform.localScale;
	}

}
