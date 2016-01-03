using UnityEngine;
using System.Collections;

public class minigame_basketball_border : MonoBehaviour {
	private bool collided;
	void onGUI() {
		if (collided) {
			Rect r = new Rect (0, 0, (Screen.width / 2), Screen.height / 2);
			GUI.Box (r, "Busketball ran away!");
		}
	}
	void OnTriggerEnter2D(Collider2D co) {
		collided = true;

	}
}
