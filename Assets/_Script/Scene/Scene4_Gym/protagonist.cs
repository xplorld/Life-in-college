using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class protagonist : MonoBehaviour {
	//walking and moving
	public Sprite[] right;
	public Sprite[] direction;
	public float framesPerSecond;
	public float speed;
	public int standDirection;
	
	//render
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		standDirection = 0;
		
		//speed
		speed = 2.5f;
		
		//render
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	
	void FixedUpdate(){
		
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, 0, 0);
		
		
	
			//start
			if (rb.position.x < -3.8) {
				Vector3 movement = new Vector3 (1, 0, 0);
				rb.velocity = movement * speed;
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				index = index % right.Length;
				spriteRenderer.sprite = right [index];
			} else {
				spriteRenderer.sprite = direction [2];
			}

		if (headmaster.protagonist_turn_up) {
			spriteRenderer.sprite = direction [3];
		}

			
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

}
