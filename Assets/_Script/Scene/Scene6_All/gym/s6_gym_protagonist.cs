﻿using UnityEngine;
using System.Collections;

public class s6_gym_protagonist : MonoBehaviour {

	
	//walking and moving
	public Sprite[] left;
	public Sprite[] right;
	public Sprite[] up;
	public Sprite[] down;
	public Sprite[] direction;
	public float framesPerSecond;
	public float speed;
	public int standDirection;
	public BoundaryHorizontal boundaryH;
	
	//render
	private SpriteRenderer spriteRenderer;
	
	//current index
	//	private int dialogIndex = 0 ;
	//GUI TEXT
	//	public Text NPCtext;
	//	private GUIStyle textStyle;
	//talk icon
	//	public Texture TalkIcon;
	//if is talking and is walking
	public bool isTalk;
	public static bool isWalk;
	
	//set position at the beginning
	public bool setPos;
	
	// Use this for initialization
	void Start () {
		//boundary
		boundaryH.xMin = -9.5f;
		boundaryH.xMax = 10.5f;
		boundaryH.yMax = -1.0f;
		boundaryH.yMin = -2.0f;
		
		//initialize if is walk or talk
		isTalk = false;
		isWalk = true;
		global_data.openUI = true;
		//speed
		speed = 2.5f;
		
		//render
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		
		setPos = true;

		//save scene
		global_data.current_scene = "Scene_6_Gym";
		
	}
	
	void FixedUpdate(){
		
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, 0, 0);
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		//set position
		if (setPos) {
			if (global_data.gym == 1) {
				rb.position = new Vector3 (
					8.7f,
					-1.3f,
					0.0f
					);
				standDirection = 1;
			} else if (global_data.gym == 0) {
				rb.position = new Vector3 (
					-9.1f,
					-1.3f,
					0.0f
					);
				standDirection = 0;
			}
			setPos = false;
		} else {
			if (isWalk) {
				//free to move
				
				
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond / (2.0f)); 
				index = index % left.Length; 
				
				if (moveHorizontal != 0) {
					Vector3 movement = new Vector3 (moveHorizontal, 0, 0);
					rb.velocity = movement * speed;
				} else if (moveVertical != 0) {
					Vector3 movement = new Vector3 (0, moveVertical, 0);
					rb.velocity = movement * speed;
				}
				
				rb.position = new Vector3 (
					Mathf.Clamp (rb.position.x, boundaryH.xMin, boundaryH.xMax),
					Mathf.Clamp (rb.position.y, boundaryH.yMin, boundaryH.yMax),
					0.0f
					);
				
				if (moveHorizontal > 0) {//right
					spriteRenderer.sprite = right [index];
					standDirection = 0;
					
				} else if (moveHorizontal < 0) {//left
					spriteRenderer.sprite = left [index];
					standDirection = 1;
					
				} else if (moveVertical > 0) {//up
					spriteRenderer.sprite = up [index];
					standDirection = 2;
				} else if (moveVertical < 0) {//down
					spriteRenderer.sprite = down [index];
					standDirection = 3;
				} else {
					if (standDirection == 0) {//right
						spriteRenderer.sprite = direction [2];
					} else if (standDirection == 1) {//left
						spriteRenderer.sprite = direction [1];
					} else if (standDirection == 2) {//up
						spriteRenderer.sprite = direction [3];
					} else if (standDirection == 3) {//down
						spriteRenderer.sprite = direction [0];
					}
				}

				if(rb.position.x<-9.3f){
					global_data.addMinute(20);
					global_data.subStamina(1);
					global_data.Place_Scene = "思远湖";
					global_data.lake = 1;
					Application.LoadLevel("Scene_6_Lake");//go to the next scene
				}
				
				if (rb.position.x > 9.2f) {
					global_data.addMinute (20);
					global_data.subStamina (1);
					global_data.Place_Scene = "实验楼";
					global_data.lab = 1;
					Application.LoadLevel ("Scene_6_Lab");//go to the next scene
				}
				if (rb.position.x > -1.0f && rb.position.x < 1.0f && rb.position.y > -1.1f) {
					global_data.addMinute(20);
					global_data.subStamina(3);
					global_data.Place_Scene = "体育馆";
					Application.LoadLevel("Minigame_basketball");
				}
			} 
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
