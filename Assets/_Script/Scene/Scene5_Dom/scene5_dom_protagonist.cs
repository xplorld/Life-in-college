using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scene5_dom_protagonist : MonoBehaviour {

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
	
	//dialog
	private string[] dialog = {
		"我：哇塞，这就是寝室呀。" ,
		"我：虽然条件不是很好的样子，但是很温馨的样子诶~~~",
		"我：等等，为什么他们几个也在？"
	};
	
	//current index
	private int dialogIndex;
	//GUI TEXT
	public Text NPCtext;
	private GUIStyle textStyle;
	//talk icon
	public Texture TalkIcon;
	//if is talking and is walking
	public bool isTalk;
	public static bool isWalk;
	public static bool doorOpen;
	// Use this for initialization
	void Start () {
		//boundary
		boundaryH.xMin = -5.3f;
		boundaryH.xMax = 3.5f;
		boundaryH.yMax = -0.6f;
		boundaryH.yMin = -2.8f;
		
		//initialize if is walk or talk
		isTalk = false;
		isWalk = false;
		global_data.openUI = false;
		doorOpen = false;
		//text style initialize
		textStyle = new GUIStyle ();
		textStyle.normal.background = null;
		textStyle.normal.textColor = new Color(1, 1, 1);
		textStyle.fontSize = 30;
				
		//get text
		NPCtext = GameObject.Find("Canvas/Text").GetComponent<Text>();
		dialogIndex = 0;
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
		
		
		if (isWalk) {
			//free to move
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

			if(doorOpen&&rb.position.x>-0.97f&&rb.position.x<0.03f&&rb.position.y>-0.8f){
				global_data.addMinute(20);
				global_data.subStamina(1);
				global_data.Place_Scene = "寝室楼";
				global_data.domBuilding = 2;
				Application.LoadLevel("Scene_6_DomBuilding");//go to the next scene
			}
			
			
		} else {
			//start
				NPCtext.text = dialog [dialogIndex];
				isTalk = true;
				global_data.openUI = false;

			//talk at the beginning
			if (isTalk) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					dialogIndex++;
					if (dialogIndex == 3) {
						isWalk = true;
						isTalk = false;
						global_data.openUI = true;
						standDirection = 3;
						dialogIndex = 0;
					} 
					
				}
			}
			
		}
	}
	

	
	void OnGUI() {
		Rect backgroundRect=new Rect(Screen.width*(0.5f)/10,
		                             Screen.height*6/11,
		                             Screen.width*9/10,
		                             Screen.height*(4.5f)/11
		                             );
		Rect textRect=new Rect(Screen.width*(0.5f)/10+40,
		                       Screen.height*6/11+60,
		                       Screen.width*9/10-40,Screen.height*(4.5f)/11-60);
		
		if (isTalk) {//talk at start 
			GUI.DrawTexture(backgroundRect,TalkIcon);
			GUI.Label(textRect,NPCtext.text.ToString(),textStyle);
		}
	}
}
