using UnityEngine;
using System.Collections;

public class CameraPlayer : MonoBehaviour {

	public Transform player;
	Camera cam;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		cam.orthographicSize = (Screen.height / 100f) / 4f;

		if (player) {
			transform.position = player.position + new Vector3(0, 0, -10);
		}
	}
}
