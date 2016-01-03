using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lake_protagonist : MonoBehaviour {
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

	// Use this for initialization
	void Start () {
		standDirection = 1;
		//boundary
		boundaryH.xMin = -9.0f;
		boundaryH.xMax = 9.5f;
		boundaryH.yMax = -0.56f;
		boundaryH.yMin = -0.56f;

		//speed
		speed = 2.5f;
		
		//render
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, 0, 0);

		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond /(2.0f)); 
		index = index % left.Length; 



		if (moveHorizontal != 0) {
			Vector3 movement = new Vector3 (moveHorizontal, 0, 0);
			rb.velocity = movement * speed;
		} else if (moveVertical != 0) {
			Vector3 movement = new Vector3 (0, moveVertical, 0);
			rb.velocity = movement * speed;
		}
		
		rb.position=new Vector3(
			Mathf.Clamp(rb.position.x,boundaryH.xMin,boundaryH.xMax),
			Mathf.Clamp(rb.position.y,boundaryH.yMin,boundaryH.yMax),
			0.0f
			);
		
		if (moveHorizontal > 0) {//right
			spriteRenderer.sprite = right [index];
			standDirection = 0;
			
		} else if (moveHorizontal < 0) {//left
			spriteRenderer.sprite = left [index];
			standDirection = 1;
			
		} else if(moveVertical>0){//up
			spriteRenderer.sprite = up [index];
			standDirection = 2;
		}else if(moveVertical<0){//down
			spriteRenderer.sprite = down [index];
			standDirection = 3;
		}
		else {
			if (standDirection==0) {//right
				spriteRenderer.sprite = direction[ 2 ];
			}
			else if(standDirection==1){//left
				spriteRenderer.sprite = direction[ 1 ];
			}
			else if(standDirection==2){//up
				spriteRenderer.sprite = direction[ 3 ];
			}
			else if(standDirection==3){//down
				spriteRenderer.sprite = direction[ 0 ];
			}
		}
		
//		if(rb.position.x<-9.0f){
//			Application.LoadLevel(2);//go to the next scene
//		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
