using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scene5_dom_roommate1 : MonoBehaviour {//study
	public bool isTalk;
	public Sprite[] direction;
	private SpriteRenderer spriteRenderer;
	private GameObject protagonist;
	private float distance_x ;
	private float distance_y ;
	
	//dialog
	private string[] dialog= {
		"我：你好。。",
		"学霸：嘘。。等我刷完这一本书。",
		"我：哦哦，好吧。（那得过多久）",
		"过了十分钟...",
		"学霸：好了刷完了，怎么有什么事么？",
		"学霸：诶你不是那个没学过GRE的菜鸡么。",
		"我：。。。我竟无言以对。",
		"学霸：你来找我是要学英语么？",
		"我：我只是想知道你为什么在这而已。",
		"学霸：Oh!It's so obvious, this is my room.",
		"我：你也是我室友么？（看来有大腿抱了）",
		"学霸：看起来是的，我的名字是“学霸”",
		"我：哦哦，我的名字是“猪脚”，以后也请多多关照了！",
		"学霸：好的，那我继续去刷题了，还有十本书今天之内要刷完。",
		"我：（太可怕了。。）"
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
		if (distance_x < 1.2f && distance_x > -1.2f && Input.GetKeyDown (KeyCode.Space) && distance_y < 0.5f&& distance_y>-0.5f) {
			
			//ui
			isTalk = true;
			global_data.openUI = false;
			//direction
			spriteRenderer.sprite = direction[2];
			//pause
			Time.timeScale = 0;
			//dialog
			dialogIndex ++ ;
			
			
			if(dialogIndex == 15){
				isTalk = false;
				global_data.openUI = true;
				Time.timeScale = 1;
				dialogIndex = -1;
				//cost
				global_data.addMinute(15);
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
