using UnityEngine;
using System.Collections;

public class DetectarPulsaciones : MonoBehaviour {
	Vector2 movementPlayer;

	void Update(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		movementPlayer = new Vector2 (0, 0);
		if (Physics.Raycast (ray, out hit, 100)) {
			if (hit.collider.gameObject.name.Equals("ButtonUp")){
				Debug.Log("Pulsado boton: arriba");
				movementPlayer = new Vector2(0, 1);
			} else if (hit.collider.gameObject.name.Equals("ButtonDown")){
				Debug.Log("Pulsado boton: abajo");
				movementPlayer = new Vector2(0, -1);

			} else if(hit.collider.gameObject.name.Equals("ButtonLeft")){
				Debug.Log("Pulsado boton: izq");
				movementPlayer = new Vector2(-1, 0);

			} else if(hit.collider.gameObject.name.Equals("ButtonRight")){
				Debug.Log("Pulsado boton: derecha");
				movementPlayer = new Vector2(1, 0);
			}
		}
		GameController.instance.jugador.GetComponent<PlayerMovement> ().movement = movementPlayer;
	}
}
