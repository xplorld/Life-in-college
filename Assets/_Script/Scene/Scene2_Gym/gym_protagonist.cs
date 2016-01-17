using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gym_protagonist : MonoBehaviour {
	//static variables would be called
	public static bool roommate_premature_turn_right;
	public static bool roommate_study_turn_right;
	public static bool roommate_stupid_turn_right;

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
		"我：哇！这就是体育馆啊！\n大白天的还放焰火啊~好漂亮~",
		"路人甲：大白天做什么白日梦呢，\n没看见是着火了吗？",
		"我：啊啊?今天不是还在下雨吗？",
		"路人乙：下雨又不代表就不能着火，\n" +
		"看来这位同学你是没有做过GRE的Argument写作吧，\n" +
		"说出来的话都是illogical的。\n" +
		"我对你将来的英语水平考试非常之担心啊。",
		"我：（这两个人都是谁啊=。=）",
		"我：看来是真的着火了！考虑怎么帮忙救火吧!\n",
		"我：可是我要怎么移动呢?",
		"路人丙：哎呀！来到了新环境，连动都不会动了？\n",
		"我：诶？",
		"路人丙：还是我来告诉你吧。在这么大个学校里，\n" +
		"行动是必须学会的！",
		"路人丙：按下【方向键】就可以四处走动了。",
		"路人丙：想要和我说话，就走到我面前按【空格键】！",
		"路人丙：就是这么简单有木有~\n" ,
		"路人丙：好了好了我还要看烟火呢~",
		"我：（原来还有人跟我一样傻也以为这是烟火)\n" ,
		"我：(不不不，看起来他应该比我要傻一点）"
	};

	//current index
	private int dialogIndex = 0 ;
	//GUI TEXT
	public Text NPCtext;
	private GUIStyle textStyle;
	//talk icon
	public Texture TalkIcon;
	//if is talking and is walking
	public bool isTalk;
	public static bool isWalk;

	// Use this for initialization
	void Start () {
		//boundary
		boundaryH.xMin = -9.5f;
		boundaryH.xMax = 10.5f;
		boundaryH.yMax = -1.0f;
		boundaryH.yMin = -2.0f;

		//initialize if is walk or talk
		isTalk = false;
		isWalk = false;
		global_data.openUI = false;
		//text style initialize
		textStyle = new GUIStyle ();
		textStyle.normal.background = null;
		textStyle.normal.textColor = new Color(1, 1, 1);
		textStyle.fontSize = 30;

		//some trigger point initialize
		roommate_premature_turn_right = false;

		//get text
		NPCtext = GameObject.Find("Canvas/Text").GetComponent<Text>();

		//speed
		speed = 2.5f;

		//render
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;

		//save scene
		global_data.current_scene = "Scene_2_Gym_Start";
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

			if(rb.position.x<-9.0f){
				global_data.addMinute(20);
				global_data.subStamina(1);
				global_data.Place_Scene = "思远湖";
				Application.LoadLevel("Scene_3_Lake");//go to the next scene
			}


		} else {
			//start
			if (rb.position.x > 6) {
				Vector3 movement = new Vector3 (-1, 0, 0);
				rb.velocity = movement * speed;
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				index = index % left.Length;
				spriteRenderer.sprite = left [index];
			} else {
				spriteRenderer.sprite = direction [3];
				NPCtext.text = dialog [dialogIndex];
				isTalk = true;
				global_data.openUI = false;
			}
			//talk at the beginning
			if (isTalk) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					dialogIndex++;
					if (dialogIndex == 1) {
						roommate_premature_turn_right = true;
					} else if (dialogIndex == 3) {
						roommate_study_turn_right = true;
					} else if (dialogIndex == 7) {
						roommate_stupid_turn_right = true;
					} else if (dialogIndex == 16) {
						isWalk = true;
						isTalk = false;
						global_data.openUI = true;
						standDirection = 1;
						roommate_premature_turn_right = false;
						roommate_study_turn_right = false;
						roommate_stupid_turn_right = false;
						dialogIndex = 0;
					}

				}
			}

		}
	}

	// Update is called once per frame
	void Update () {
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
