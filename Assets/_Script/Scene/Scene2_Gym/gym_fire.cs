using UnityEngine;
using System.Collections;

public class gym_fire : MonoBehaviour {
	public Sprite[] fire;
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % fire.Length;
		spriteRenderer.sprite = fire[index];
	}
}
