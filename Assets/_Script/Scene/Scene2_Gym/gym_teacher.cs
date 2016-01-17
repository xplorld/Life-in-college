using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gym_teacher : MonoBehaviour {
	public bool isTalk;
	public Sprite[] direction;
	private SpriteRenderer spriteRenderer;
	private GameObject protagonist;
	private float distance_x ;
	private float distance_y ;
	
	//dialog
	private string[] dialog= {
		"老师：小伙子你想帮忙救火吗？",
		"我：是啊，我能帮什么忙吗？",
		"老师：好！真是个有志向的少年!\n",
		"我听说校长今天好像会在【思远湖】边散步，\n" +
		"你赶紧去找一下他,\n" +
		"报告一下情况吧！",
		"好的，我马上就去。",
		"不过。。请问思源湖要怎么走呢？",
		"沿着这条道往西走就到啦。"
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
		if (gym_protagonist.roommate_premature_turn_right) {
			spriteRenderer.sprite = direction[2];		
		}
		//talk
		if (distance_x < 0.5 && distance_x > -0.5f && (Input.GetKeyDown (KeyCode.Space)) && distance_y < 0.5) {

			//ui
			isTalk = true;
			global_data.openUI = false;
			//direction
			spriteRenderer.sprite = direction[0];
			//pause
			Time.timeScale = 0;
			//dialog
			dialogIndex ++ ;

			if(dialogIndex == 7){
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
