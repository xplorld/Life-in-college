using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scene5_dom_chair : MonoBehaviour {
	public bool isTalk;
	private GameObject protagonist;
	private float distance_x ;
	private float distance_y ;
	
	//dialog
	private string[] dialog= {
		"我：看来这里就是我的床位，先收拾一下把。",
		"两个小时过去了。。。",
		"我：啊，好了，看起来收拾的差不多了呢。",
		"我：先去熟悉熟悉校园把~",
		"我：对了好像有点饿，要找到【食堂】吃饭。"
			
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
		
		protagonist = GameObject.Find ("character/protagonist");
		
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
		if (distance_x < 1.2 && distance_x > -1.2f && Input.GetKeyDown (KeyCode.Space) && distance_y < 0.5 && distance_y>-0.5f) {
			
			//ui
			isTalk = true;
			global_data.openUI = false;

			//pause
			Time.timeScale = 0;
			//dialog
			dialogIndex ++ ;
			
			
			if(dialogIndex == 5){
				isTalk = false;
				scene5_dom_protagonist.doorOpen = true;
				global_data.openUI = true;
				Time.timeScale = 1;
				dialogIndex = -1;
				//cost
				global_data.addMinute(125);
				global_data.subStamina(15);

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
