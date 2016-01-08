using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class start_dialog : MonoBehaviour {
	private string[] dialog = {
		"我：哇~这就是大学啊~马上就要迎来我的大学生活了",
		"我：不知道在这四年里我会拿到多少的GPA，参加多少个社团，\n",
		"我：遇到多少个好基友，邂逅多少女生呢，好期待呢~",
		"妹子－高冷：怎么大白天就有人做梦，应该去附近的五院看看去。",
		"我：咦，好像听到有人在说话？" ,
		"我：差不多该去报道了。我记得是在旧体育馆是吧~"

	};
	private int dialogIndex;
	//GUI TEXT
	public Text NPCtext;
	private GUIStyle textStyle;
	//talk icon
	public Texture TalkIcon;
	//talk flag
	private bool isTalk;

	// Use this for initialization
	void Start () {
		isTalk = true;
		dialogIndex = -1;
		//get text
		NPCtext = GameObject.Find("Canvas/Text").GetComponent<Text>();
		//text style initialize
		textStyle = new GUIStyle ();
		textStyle.normal.background = null;
		textStyle.normal.textColor = new Color(1, 1, 1);
		textStyle.fontSize = 40;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {
			dialogIndex ++ ;
			if(dialogIndex == 6){
				Application.LoadLevel("Scene_2_Gym_Start");
				Debug.Log("loadlevel:1");
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
