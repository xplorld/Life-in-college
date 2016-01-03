using UnityEngine;
using System.Collections;

public class UI_Start_Gallery : MonoBehaviour {

	public static global_data gd;

	private float Width = Screen.width;
	private float Height = Screen.height;
	/*
	private float button0CenterWidth = ;
	private float button0CenterHeight = ;
	private float button1CenterWidth = ;
	private float button1CenterHeight = ;
	private float button2CenterWidth = ;
	private float button2CenterHeight = ;
	private float button3CenterWidth = ;
	private float button3CenterHeight = ;
	*/
	private float buttonWidth = Screen.width/3;
	private float buttonHeight = Screen.height/3;
	private float Height_Adjust = 0;

	private int page = 1;
	private float buttonBackCenterWidth = Screen.width/2-100;
	private float buttonBackCenterHeight = Screen.height*9/10;
	private float buttonBackWidth = 60;
	private float buttonBackHeight = 30;
	private float buttonNextCenterWidth = Screen.width/2+100;
	private float buttonNextCenterHeight = Screen.height*9/10;
	private float buttonNextWidth = 60;
	private float buttonNextHeight = 30;
	private float buttonPageCenterWidth = Screen.width/2;
	private float buttonPageCenterHeight = Screen.height*9/10;
	private float buttonPageWidth = 60;
	private float buttonPageHeight = 30;

	public Rect button_pos;
	public Texture image_unknown;

	GUIStyle myButtonStyle0;
	GUIStyle myButtonStyle1;
	GUIStyle myButtonStyle2;
	Font myFont;

	void Awake() {
		gd = global_data.Instance;

		Debug.Log(global_data.Time_Day);
		Debug.Log(global_data.Time_Hour);
		Debug.Log(global_data.Time_Minute);
		Debug.Log(global_data.Place_Scene);
	}

	void OnGUI() {

		myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
		
		myButtonStyle0 = new GUIStyle (GUI.skin.button);
		myButtonStyle0.fontSize = 20;
		myButtonStyle0.font = myFont;
		
		
		myButtonStyle1 = new GUIStyle (GUI.skin.button);
		myButtonStyle1.fontSize = 18;
		myButtonStyle1.font = myFont;
		
		myButtonStyle2 = new GUIStyle (GUI.skin.button);
		myButtonStyle2.fontSize = 15;
		myButtonStyle2.font = myFont;

		button_pos = new Rect(Width*1/8, Height*1/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Button (button_pos,
		            global_data.Gallery_Have[page*4] ? global_data.Gallery_Picture[page*4] : image_unknown,
		            myButtonStyle2);
		
		button_pos = new Rect(Width*1/8, Height*6/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Button (button_pos,
		            global_data.Gallery_Have[page*4+1] ? global_data.Gallery_Picture[page*4+1] : image_unknown,
		            myButtonStyle2);
		
		button_pos = new Rect(Width*4/8, Height*1/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Button (button_pos,
		            global_data.Gallery_Have[page*4+2] ? global_data.Gallery_Picture[page*4+2] : image_unknown,
		            myButtonStyle2);
		
		button_pos = new Rect(Width*4/8, Height*6/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Button (button_pos,
		            global_data.Gallery_Have[page*4+3] ? global_data.Gallery_Picture[page*4+3] : image_unknown,
		            myButtonStyle2);

		button_pos = new Rect(buttonBackCenterWidth-buttonBackWidth/2, buttonBackCenterHeight-buttonBackHeight/2, buttonBackWidth, buttonBackHeight);
		GUI.Button (button_pos,
		            "上一页",
		            myButtonStyle2);
		
		button_pos = new Rect(buttonNextCenterWidth-buttonNextWidth/2, buttonNextCenterHeight-buttonNextHeight/2, buttonNextWidth, buttonNextHeight);
		GUI.Button (button_pos,
		            "下一页",
		            myButtonStyle2);
		
		button_pos = new Rect(buttonPageCenterWidth-buttonPageWidth/2, buttonPageCenterHeight-buttonPageHeight/2, buttonPageWidth, buttonPageHeight);
		GUI.Button (button_pos,
		            page + "/" + (global_data.Gallery_Count+3)/4,
		            myButtonStyle2);
		

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
