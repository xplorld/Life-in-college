using UnityEngine;
using System.Collections;

public class girl_cute : MonoBehaviour {

	//direction
	public Sprite[] direction;

	//render
	private SpriteRenderer spriteRenderer;
	
	// Use this for initialization
	void Start () {
		//render
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	
	void FixedUpdate(){
		
		if (headmaster.girl_cute_turn_down) {
			spriteRenderer.sprite = direction [0];
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

}
