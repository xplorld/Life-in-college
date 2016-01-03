using UnityEngine;
using System.Collections;

public class UI_Option : MonoBehaviour {

	public static global_data gd;

	//public Texture button_attribute;
	//public Texture button_achievement;
	//public Texture button_task;
	//public Texture button_option;
	//public Texture[] button_menu;
	//public Texture label_HP;
	//public Texture label_clock;
	//public Texture label_place;
	public Rect button_attribute_pos;
	public Rect button_achievement_pos;
	public Rect button_task_pos;
	public Rect button_option_pos;
	public Rect button_menu_pos;
	public Rect label_HP_pos;
	public Rect label_clock_pos;
	public Rect label_place_pos;

	private float Width = Screen.width;
	private float Height = Screen.height;
	private float buttonWidth = Screen.width/4;
	private float buttonHeight = Screen.width/4*122/500;
	private float menuWidth = Screen.height/5;
	private float menuHeight = Screen.height/9;
	private float hpWidth = Screen.width/6;
	private float hpHeight = Screen.width/20;
	private float clockWidth = Screen.width/4;
	private float clockHeight = Screen.width/25;
	private float placeWidth = Screen.width/4;
	private float placeHeight = Screen.width/25;

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

	void OnGUI () {

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

		button_attribute_pos = new Rect(Width*3/8, Height*3/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_attribute_pos, "Attribute", myButtonStyle0)) {
			Debug.Log ("press button_attribute");
			Application.LoadLevel("UI_Option_Attribute");
		}


		button_achievement_pos = new Rect(Width*3/8, Height*4/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_achievement_pos, "Achievement", myButtonStyle0)) {
			Debug.Log ("press button_achievement");
			Application.LoadLevel("UI_Option_Achievement");
		}

		button_task_pos = new Rect(Width*3/8, Height*5/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_task_pos, "Task", myButtonStyle0)) {
			Debug.Log ("press button_task");
		}

		button_option_pos = new Rect(Width*3/8, Height*6/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_option_pos, "Option", myButtonStyle0)) {
			Debug.Log ("press button_option");
		}

		button_menu_pos = new Rect(Width*7/9, Height/10, menuWidth, menuHeight);
		if(GUI.Button (button_menu_pos, "Back", myButtonStyle1)) {
			Debug.Log ("press button_menu to back to other scene");
		}
	
		label_clock_pos = new Rect(Width*3/8, Height/10, clockWidth, clockHeight);
		string label_clock_print_str = "Day " + global_data.Time_Day + " " + global_data.Time_Hour + ":" + (global_data.Time_Minute<10 ? "0" : "" ) + global_data.Time_Minute;
		GUI.Button (label_clock_pos, label_clock_print_str, myButtonStyle2);

		label_place_pos = new Rect(Width*3/8, Height/6, placeWidth, placeHeight);
		string label_place_print_str = global_data.Place_Scene;
		GUI.Button (label_place_pos, label_place_print_str, myButtonStyle2);

		label_HP_pos = new Rect(Width/10, Height/10, hpWidth, hpHeight);
		string label_HP_print_str = "体力值: " + global_data.Stamina + "/" + global_data.Stamina_Max;
		GUI.Button (label_HP_pos, label_HP_print_str, myButtonStyle2);

	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
