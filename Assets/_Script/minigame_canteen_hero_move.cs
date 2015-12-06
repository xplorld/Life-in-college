using UnityEngine;
using System.Collections;

public class minigame_canteen_hero_move : MonoBehaviour {
	public float speed = 3.0f;


	void FixedUpdate() {
		// Move closer to Destination

		Vector2 force = Vector2.zero;
		if (Input.GetKey(KeyCode.UpArrow)) 
			force = Vector2.up;
		else if (Input.GetKey(KeyCode.RightArrow)) 
			force = Vector2.right;
		else if (Input.GetKey(KeyCode.DownArrow)) 
			force = - Vector2.up;
		else if (Input.GetKey(KeyCode.LeftArrow)) 
			force = - Vector2.right;


		if (force != Vector2.zero) {
			force *= speed; //speed factor
			GetComponent<Rigidbody2D> ().AddForce(force);
		}


		// Animation Parameters
		GetComponent<Animator>().SetFloat("DirX", force.x);
		GetComponent<Animator>().SetFloat("DirY", force.y);
	}

}
