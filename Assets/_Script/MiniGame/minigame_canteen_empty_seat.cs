using UnityEngine;
using System.Collections;

public class minigame_canteen_empty_seat: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "hero") {
			Rigidbody2D rigid = co.GetComponent<Rigidbody2D> ();
			rigid.MovePosition (transform.position);
			rigid.velocity = Vector2.zero;
			Application.LoadLevel("Scene_6_Canteen");
		} else {
//			Destroy(co.GetComponent<GameObject>());
			GetComponent<Collider2D>().enabled = false;
		}
	}
}
