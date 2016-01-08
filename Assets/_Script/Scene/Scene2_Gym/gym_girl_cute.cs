using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gym_girl_cute : MonoBehaviour {

	public bool isTalk;
	public Sprite[] direction;
	private SpriteRenderer spriteRenderer;
	private GameObject protagonist;
	private float distance_x ;
	private float distance_y ;
	private int dialogPart;
	//dialog
	private string[] dialog= {
				"路人丁：啊~好可怕呀着火了~可是我的书包还在里面~呜~",
				"我要说什么?\n"+
				"1.别慌，我去想办法救火。\n"+
				"2.那书包里有什么？\n"+
				"3.真是可怜~可是我无能为力呀~"

	};
	private string[] dialog1 = {
		"我：别慌，我去想办法救火。",
		"路人丁：一定要帮我找我的书包呀~谢谢~",
		"我：好！（拜托了不要用那样萌的眼神看着我）"
	};
	private string[] dialog2 = {
		"我：那书包里有什么？",
		"路人丁：有~有~有~呜。。",
		"我：(怎么说着说着哭起来了。。。)",
		"路人丁：那里边。。有我最喜欢的胡歌手办\n" +
		"~朋友临别的时候送给我的~呜~",
		"（怎么。。最近琅琊榜这么火吗？）"
	};
	private string[] dialog3 = {
		"我：真是可怜~可是我无能为力呀~",
		"路人丁：书包~呜~",
		"我：（好像哭得更伤心了）"
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
		dialogPart = 0;

		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
		
		protagonist = GameObject.Find ("protagonist");
		
		isTalk = false;

		//get text
		NPCtext = GameObject.Find("Canvas/Text").GetComponent<Text>();
		//text style initialize
		textStyle = new GUIStyle ();
		textStyle.normal.background = null;
		textStyle.normal.textColor = new Color(1, 1, 1);
		textStyle.fontSize = 40;
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

		if(dialogPart==0&&dialogIndex==1&&(Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Alpha3))){
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				dialogPart = 1;
				dialogIndex = 0;
				NPCtext.text = dialog1[dialogIndex];
			}
			else if(Input.GetKeyDown(KeyCode.Alpha2)){
				dialogPart=2;
				dialogIndex = 0;
				NPCtext.text = dialog2[dialogIndex];
			}
			else if(Input.GetKeyDown(KeyCode.Alpha3)){
				dialogPart = 3;
				dialogIndex = 0;
				NPCtext.text = dialog3[dialogIndex];
			}
		}
		else if ((dialogIndex!=1||dialogPart!=0)&&distance_x < 2.0f && distance_x > -2.0f && (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) && distance_y < 0.5&&distance_y>-0.5f) {

			//ui
			isTalk = true;
			global_data.openUI = false;
			//face to which direction
			if(distance_x>0){
				spriteRenderer.sprite = direction[1];
			}
			else if(distance_x<0){
				spriteRenderer.sprite = direction[2];
			}
			
			Time.timeScale = 0;
			dialogIndex ++ ;
			
			if((dialogPart == 1 && dialogIndex == dialog1.Length)||(dialogPart == 2 && dialogIndex == dialog2.Length)||(dialogPart == 3 && dialogIndex == dialog3.Length)){
				isTalk = false;
				global_data.openUI = true;
				Time.timeScale = 1;
				dialogIndex = -1;
				//cost
				global_data.addMinute(5);
			}
			else{

				switch(dialogPart)
				{
				case 1: 
					NPCtext.text = dialog1[dialogIndex];	
					break;
				case 2: 
					NPCtext.text = dialog2[dialogIndex];
					break;
				case 3: 
					NPCtext.text = dialog3[dialogIndex];
					break;
				default: 
					NPCtext.text = dialog[dialogIndex];
					break;
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
