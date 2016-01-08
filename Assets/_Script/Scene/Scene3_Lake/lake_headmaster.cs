using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lake_headmaster : MonoBehaviour {
	public bool isTalk;
	public Sprite[] direction;
	private SpriteRenderer spriteRenderer;
	private GameObject protagonist;
	private float distance_x ;
	private float distance_y ;
	
	//dialog
	private string[] dialog_roommate_study = {
		"校长：小伙子，你有什么事吗？" ,
		"我：请问您是校长吗？",
		"校长：小伙子你真是慧眼如炬啊，没错我就是这个学校最帅的男人——校长了。" ,
		"我：（这个蜀黍有点奇怪）",
		"校长：小伙子你有什么事么？",
		"我：哦对了，体育馆着火了，校长您快想想办法吧。",
		"校长：什么？！我的最心爱的体育馆居然着火了？",
		"我：是的，老师都在那等着您的指示呢。",
		"校长：看来只能报警了。",
		"我：！校长您真是机智！",
		"校长：哈哈哈，是不是折服于我的美貌和智慧之下了？",
		"校长：走吧，我们一起去现场吧～"
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
		global_data.openUI = true;
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
		if (distance_x < 0.5 && distance_x > -0.5f && (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) && distance_y < 0.5) {
			isTalk = true;
			global_data.openUI = false;
			spriteRenderer.sprite = direction[0];
			Time.timeScale = 0;
			dialogIndex ++ ;
			
			
			if(dialogIndex == 12){
				isTalk = false;
				global_data.openUI = true;
				Time.timeScale = 1;
				dialogIndex = -1;
				NPCtext.text = "";
				Application.LoadLevel("Scene_4_Gym");
			}
			else{
				NPCtext.text = dialog_roommate_study[dialogIndex];	
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
