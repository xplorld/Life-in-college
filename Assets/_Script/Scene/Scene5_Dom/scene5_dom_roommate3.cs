using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scene5_dom_roommate3 : MonoBehaviour {
	public bool isTalk;
	public Sprite[] direction;
	private SpriteRenderer spriteRenderer;
	private GameObject protagonist;
	private float distance_x ;
	private float distance_y ;
	
	//dialog
	private string[] dialog= {
		"熟男：你好，我叫“熟男”，非常高兴。。",
		"熟男：什么？！你这个小不点怎么也会在这个寝室！",
		"我：什么小不点！我还想问你怎么会在这呢！",
		"熟男：哼，这不是很明显么，我住在这啊。",
		"熟男：你看，这里有我的床，我的椅子，还有我的钢琴。",
		"我：不会吧。。你难道是我室友？",
		"熟男：什么？你居然是我室友？",
		"我：你要不要这么嫌弃的样子！",
		"熟男：好吧好吧，我叫“熟男”，以后就带带你好了。",
		"我：我叫“猪脚”，我才不要你带呢！",
		"熟男：好好好，我要弹钢琴了，你去见见其他的室友把。"
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
		if (distance_x < 0.8 && distance_x > -0.8f && Input.GetKeyDown (KeyCode.Space) && distance_y < 1) {
			
			//ui
			isTalk = true;
			global_data.openUI = false;
			//direction
			spriteRenderer.sprite = direction[0];
			//pause
			Time.timeScale = 0;
			//dialog
			dialogIndex ++ ;
			
			
			if(dialogIndex == 11){
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
