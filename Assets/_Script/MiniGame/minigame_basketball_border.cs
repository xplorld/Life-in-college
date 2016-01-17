using UnityEngine;
using System.Collections;

public class minigame_basketball_border : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D other) {
		Application.LoadLevel ("Scene_6_Gym");
	}
}
