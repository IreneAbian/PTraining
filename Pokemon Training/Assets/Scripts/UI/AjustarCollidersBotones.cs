using UnityEngine;
using System.Collections;

public class AjustarCollidersBotones : MonoBehaviour {

	void Start () {
		BoxCollider collider = GetComponent<BoxCollider> ();
		GameObject background = transform.FindChild ("Background").gameObject;
		UISprite sprite = background.GetComponent<UISprite> ();
		collider.size = sprite.transform.localScale;
	}

}
