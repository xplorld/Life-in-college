using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scene5_dom_roommate2 : MonoBehaviour {
	public bool isTalk;
	public Sprite[] direction;
	private SpriteRenderer spriteRenderer;
	private GameObject protagonist;
	private float distance_x ;
	private float distance_y ;
	
	//dialog
	private string[] dialog= {
		"我：又是你呀，你怎么会在这里？",
		"傻蛋：客官说的这是什么话，这里是我的寝室，我当然会在这里啦。",
		"我：客官什么鬼。。你难道是小二么。",
		"傻蛋：非也非也，在下姓“傻”单名一个“蛋”。",
		"我：（这名字倒是挺适合他的）",
		"我：等等，你说这是你的寝室？这么说你是我的室友？",
		"傻蛋：哎呀，没想到我们这么有缘分哪，那以后可得多多关照了~",
		"我：不敢当。。我叫“猪脚”，以后大家一起玩耍把~",
		"我：（奇怪我怎么也这么说话了）"

	};
	//current index
	private int dialogIndex ;
	//GUI TEXT
	public Text NPCtext;
	private GUIStyle textStyle;
	//talk icon
	public Texture TalkIcon;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		
		protagonist = GameObject.Find ("protagonist");
		
		isTalk = false;
		//get text
		NPCtext = GameObject.Find("Canvas/Text").GetComponent<Text>();
		//text style initialize
		textStyle = new GUIStyle ();
		textStyle.normal.background = null;
		textStyle.normal.textColor = new Color(1, 1, 1);
		textStyle.fontSize = 30;
		//index
		dialogIndex = -1;
	}
	
	void FixedUpdate(){
		Rigidbody2D rb_protagonist = protagonist.GetComponent<Rigidbody2D> ();
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		distance_x = rb.position.x - rb_protagonist.position.x;
		distance_y = rb.position.y - rb_protagonist.position.y;
	}
	// Update is called once per frame
	void Update () {
		//talk
		if (distance_x < 1.2 && distance_x > -1.2f && Input.GetKeyDown (KeyCode.Space) && distance_y < 0.5 ) {
			
			//ui
			isTalk = true;
			global_data.openUI = false;
			//direction
			spriteRenderer.sprite = direction[2];
			//pause
			Time.timeScale = 0;
			//dialog
			dialogIndex ++ ;
			
			
			if(dialogIndex == 9){
				isTalk = false;
				global_data.openUI = true;
				Time.timeScale = 1;
				dialogIndex = -1;
				//cost
				global_data.addMinute(5);
			}
			else{
				NPCtext.text = dialog[dialogIndex];	
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
