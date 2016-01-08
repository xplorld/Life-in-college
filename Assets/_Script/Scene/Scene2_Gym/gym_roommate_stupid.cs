using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gym_roommate_stupid : MonoBehaviour {

	public bool isTalk;
	public Sprite[] direction;
	private SpriteRenderer spriteRenderer;
	private GameObject protagonist;
	private float distance_x ;
	private float distance_y ;
	
	//dialog
	private string[] dialog= {
		"路人丙：还是我来告诉你吧。在这么大个学校里，\n" +
		"行动是必须学会的！按下【方向键】就可以四处走动了，\n" +
		"想要和我说话，就走到我面前按【空格键】！就是这么简单有木有~\n" +
		"好了好了我还要看烟火呢~",
		"我：这个人好像有点傻。"
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
		if (gym_protagonist.roommate_stupid_turn_right) {
			spriteRenderer.sprite = direction[2];		
		}
		//talk
		if (distance_x < 0.5 && distance_x > -0.5f && (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) && distance_y < 0.5) {
			isTalk = true;
			global_data.openUI = false;
			spriteRenderer.sprite = direction[0];
			Time.timeScale = 0;
			dialogIndex ++ ;
			
			
			if(dialogIndex == 2){
				isTalk = false;
				global_data.openUI = true;
				Time.timeScale = 1;
				dialogIndex = -1;
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
