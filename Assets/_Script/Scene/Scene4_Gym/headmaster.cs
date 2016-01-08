using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class headmaster : MonoBehaviour {
	public static bool girl_cute_turn_down;
	public static bool protagonist_turn_up;

	//walking and moving
	public Sprite[] left;
	public Sprite[] right;
	public Sprite[] up;
	public Sprite[] down;
	public Sprite[] direction;
	public float framesPerSecond;
	public float speed;
	public int standDirection;
	
	//render
	private SpriteRenderer spriteRenderer;
	
	//dialog
	private string[] dialog = {
		"老师：校长！您来了～",
		"老师：刚刚消防队员才走，已经把火灭了。",
		"我：啊，总算是大火扑灭了，我们也可以报道了~",
		"校长：年轻人，这场大火的扑灭少不了你的功劳啊，谢谢你啊。",
		"妹子【萌】：我的书包也找到了！谢谢你呀！",
		"我：不不，都是靠机智的校长。",
		"校长：不过呢，这个状况看来是没法报道了" ,
		"校长：你们要不先回去把，等明天体育馆修复好了再来吧。" ,
		"我和众人：好的" ,
		"我：（明天就能修复好？R U kidding me?)" ,
		"我：（早就听说校长是个神一样的人物，果然名不虚传啊)" ,
		"我：（还是先去看看新室友们把^_^)"
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
		girl_cute_turn_down = false;
		protagonist_turn_up = false;

		standDirection = 0;
		
		//initialize if is walk or talk
		isTalk = false;
		isWalk = false;
		global_data.openUI = false;
		//text style initialize
		textStyle = new GUIStyle ();
		textStyle.normal.background = null;
		textStyle.normal.textColor = new Color(1, 1, 1);
		textStyle.fontSize = 40;
		
		//get text
		NPCtext = GameObject.Find("Canvas/Text").GetComponent<Text>();
		
		//speed
		speed = 2.5f;
		
		//render
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	
	void FixedUpdate(){

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, 0, 0);

			//start
			if (rb.position.x < -2.5) {
				Vector3 movement = new Vector3 (1, 0, 0);
				rb.velocity = movement * speed;
				int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
				index = index % left.Length;
				spriteRenderer.sprite = right [index];
			} else {
				spriteRenderer.sprite = direction [2];
				NPCtext.text = dialog [dialogIndex];
				isTalk = true;
				global_data.openUI = false;
			}
			//talk at the beginning
			if (isTalk) {
				if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
					dialogIndex++;
					if (dialogIndex == 4) {
						girl_cute_turn_down = true;
					} else if (dialogIndex == 5) {
						protagonist_turn_up = true;
					} else if (dialogIndex == 6) {
						spriteRenderer.sprite = direction[3];
					} else if (dialogIndex == 12) {
						isTalk = false;
						global_data.openUI = true;
						standDirection = 1;
						dialogIndex = 0;
						Application.LoadLevel("Scene_5_Dom");
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
