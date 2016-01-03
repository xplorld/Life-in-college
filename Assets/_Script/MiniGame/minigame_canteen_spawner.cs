using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class minigame_canteen_spawner : MonoBehaviour {
	public GameObject enemy;
	public float spawnTime = 2;
	public GameObject table;
	private List<Collider2D> freeseats;
//	private Dictionary<Collider2D,bool> occupied;
	// Use this for initialization
	void Start () {
		freeseats = new List<Collider2D> (table.GetComponentsInChildren<Collider2D> ());
		InvokeRepeating ("addEnemy", 0, spawnTime);
	}
	
	void addEnemy(){
		if (freeseats.Count == 0) {
			CancelInvoke();
			return;
		}

		Renderer renderer = GetComponent<Renderer> ();
		var y1 = renderer.bounds.max.y;
		var y2 = renderer.bounds.min.y;
		var x = transform.position.x + renderer.bounds.size.x/2;
		// Randomly pick a point within the spawn object
		var spawnPoint = new Vector2 (x,Random.Range(y1, y2));

		// Create an enemy at the 'spawnPoint' position
		GameObject newEnemy = (GameObject)Instantiate(enemy, spawnPoint, Quaternion.identity);
		AstarAI ai = newEnemy.GetComponent<AstarAI> ();
		ai.target = getRandomFreeSeat ();
		return;
	}

	Transform getRandomFreeSeat() {
		int i = Random.Range (0, freeseats.Count);
		Collider2D seat = freeseats [i];
		freeseats.RemoveAt (i);
		return seat.transform;
	}
	void onGUI() {
	}
}
