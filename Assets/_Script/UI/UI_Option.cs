using UnityEngine;
using System.Collections;
using System.IO;

public class UI_Option : MonoBehaviour {

	public string at = "Embed";

	GUIStyle myButtonStyle0;
	GUIStyle myButtonStyle1;
	GUIStyle myButtonStyle2;
	GUIStyle myBackgroundStyle;
	GUIStyle myFrontgroundStyle;
	Font myFont;

	void Save_Game() {

		Debug.Log ("save data for this game");

		StreamWriter sw = File.CreateText("save.txt");

		sw.WriteLine (global_data.Stamina);
		sw.WriteLine (global_data.Stamina_Max);
		sw.WriteLine (global_data.Learning);
		sw.WriteLine (global_data.Socialization);
		sw.WriteLine (global_data.Taste);

		sw.WriteLine (global_data.Relationship_Teacher);
		sw.WriteLine (global_data.Relationship_Principle);
		sw.WriteLine (global_data.Relationship_Roommate1);
		sw.WriteLine (global_data.Relationship_Roommate2);
		sw.WriteLine (global_data.Relationship_Roommate3);
		sw.WriteLine (global_data.Relationship_Girlfriend1);
		sw.WriteLine (global_data.Relationship_Girlfriend2);
		sw.WriteLine (global_data.Relationship_Girlfriend3);
		sw.WriteLine (global_data.Relationship_Girlfriend4);

		sw.WriteLine (global_data.minigame_count);
		sw.WriteLine (global_data.ball_shoot_count);
		sw.WriteLine (global_data.oscilloscope_count);

		sw.WriteLine (global_data.Time_Day);
		sw.WriteLine (global_data.Time_Hour);
		sw.WriteLine (global_data.Time_Minute);

		sw.WriteLine (global_data.Place_Scene);
		sw.WriteLine (global_data.Place_X);
		sw.WriteLine (global_data.Place_Y);

		for (int i=0; i!=global_data.Achievement_Count; ++i)
			sw.WriteLine (global_data.Achievement_Now [i]);

		sw.WriteLine (global_data.openBGM);
		sw.WriteLine (global_data.openSCM);

		sw.WriteLine (global_data.current_scene);
		sw.Close();

	}

	void Load_Game() {
		
		Debug.Log ("load data for old game");
		
		if (File.Exists ("save.txt")) {
			StreamReader sr = File.OpenText("save.txt");
			
			global_data.Stamina = int.Parse(sr.ReadLine());
			global_data.Stamina_Max = int.Parse(sr.ReadLine());
			global_data.Learning = int.Parse(sr.ReadLine());
			global_data.Socialization = int.Parse(sr.ReadLine());
			global_data.Taste = int.Parse(sr.ReadLine());
			
			global_data.Relationship_Teacher = int.Parse(sr.ReadLine());
			global_data.Relationship_Principle = int.Parse(sr.ReadLine());
			global_data.Relationship_Roommate1 = int.Parse(sr.ReadLine());
			global_data.Relationship_Roommate2 = int.Parse(sr.ReadLine());
			global_data.Relationship_Roommate3 = int.Parse(sr.ReadLine());
			global_data.Relationship_Girlfriend1 = int.Parse(sr.ReadLine());
			global_data.Relationship_Girlfriend2 = int.Parse(sr.ReadLine());
			global_data.Relationship_Girlfriend3 = int.Parse(sr.ReadLine());
			global_data.Relationship_Girlfriend4 = int.Parse(sr.ReadLine());

			global_data.minigame_count = int.Parse(sr.ReadLine());
			global_data.ball_shoot_count =  int.Parse(sr.ReadLine());
			global_data.oscilloscope_count =  int.Parse(sr.ReadLine());

			
			global_data.Time_Day = int.Parse(sr.ReadLine());
			global_data.Time_Hour = int.Parse(sr.ReadLine());
			global_data.Time_Minute = int.Parse(sr.ReadLine());
			
			global_data.Place_Scene = sr.ReadLine();
			global_data.Place_X = int.Parse(sr.ReadLine());
			global_data.Place_Y = int.Parse(sr.ReadLine());
			
			for(int i=0;i!=global_data.Achievement_Count;++i) global_data.Achievement_Now[i] = int.Parse(sr.ReadLine());
			
			global_data.openBGM = bool.Parse(sr.ReadLine());
			global_data.openSCM = bool.Parse(sr.ReadLine());

			global_data.current_scene = sr.ReadLine();

			Application.LoadLevel(global_data.current_scene);

			sr.Close();
			Debug.Log ("load finish");
		} else {
			Debug.Log ("No old game can be load.");
		}
	}

	void UI_Option_Menu() {

		Rect button_attribute_pos;
		Rect button_achievement_pos;
		Rect button_task_pos;
		Rect button_option_pos;
		Rect button_save_pos;
		Rect button_load_pos;
		Rect button_menu_pos;
		Rect label_HP_pos;
		Rect label_clock_pos;
 		Rect label_place_pos;
		
 		float Width = Screen.width;
 		float Height = Screen.height;
 		float buttonWidth = Screen.width/4;
 		float buttonHeight = Screen.width/4*122/500;
 		float menuWidth = Screen.height/5;
 		float menuHeight = Screen.height/9;
 		float hpWidth = Screen.width/6;
 		float hpHeight = Screen.width/20;
 		float clockWidth = Screen.width/4;
 		float clockHeight = Screen.width/25;
 		float placeWidth = Screen.width/4;
 		float placeHeight = Screen.width/25;
		float adjust_w = 100;

		GUI.Label (new Rect (-10, -10, Width + 10, Height + 10), "", myBackgroundStyle);

		button_attribute_pos = new Rect(Width*1/8+adjust_w, Height*3/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_attribute_pos, "Attribute", myButtonStyle0)) {
			Debug.Log ("press button_attribute");
			at = "Attribute";
		}

		button_achievement_pos = new Rect(Width*5/8-adjust_w, Height*3/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_achievement_pos, "Achievement", myButtonStyle0)) {
			Debug.Log ("press button_achievement");
			at = "Achievement";
		}

		button_save_pos = new Rect(Width*1/8+adjust_w, Height*4/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_save_pos, "Save", myButtonStyle0)) {
			Debug.Log ("press button_save");
			Save_Game();
		}
		
		button_load_pos = new Rect(Width*5/8-adjust_w, Height*4/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_load_pos, "Load", myButtonStyle0)) {
			Debug.Log ("press button_load");
			Load_Game();
		}
	
		button_task_pos = new Rect(Width*1/8+adjust_w, Height*5/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_task_pos, "Task", myButtonStyle0)) {
			Debug.Log ("press button_task");
		}
		
		button_option_pos = new Rect(Width*5/8-adjust_w, Height*5/8, buttonWidth, buttonHeight);
		if(GUI.Button (button_option_pos, "Option", myButtonStyle0)) {
			Debug.Log ("press button_option");
			at = "Option";
		}

		button_menu_pos = new Rect(Width*7/9, Height/10, menuWidth, menuHeight);
		if(GUI.Button (button_menu_pos, "Back", myButtonStyle1)) {
			Debug.Log ("press button_menu to back to other scene");
			at = "Embed";
		}
		
		label_clock_pos = new Rect(Width*3/8, Height/10, clockWidth, clockHeight);
		string label_clock_print_str = "Day " + global_data.Time_Day + " " + global_data.Time_Hour + ":" + (global_data.Time_Minute<10 ? "0" : "" ) + global_data.Time_Minute;
		GUI.Label (label_clock_pos, label_clock_print_str, myButtonStyle2);
		
		label_place_pos = new Rect(Width*3/8, Height/6, placeWidth, placeHeight);
		string label_place_print_str = global_data.Place_Scene;
		GUI.Label (label_place_pos, label_place_print_str, myButtonStyle2);
		
		label_HP_pos = new Rect(Width/10, Height/10, hpWidth, hpHeight);
		string label_HP_print_str = "Stamina: " + global_data.Stamina + "/" + global_data.Stamina_Max;
		GUI.Label (label_HP_pos, label_HP_print_str, myButtonStyle2);

	}

	void UI_Option_Attribute() {

 		float Width = Screen.width;
 		float Height = Screen.height;
 		float buttonWidth = Screen.width/3;
 		float buttonHeight = Screen.height*2/15;
 		float Height_Adjust = 0;
		
		Rect button_pos;

		if (GUI.Button (new Rect (-10, -10, Width + 10, Height + 10), "", myBackgroundStyle)) {
			at = "Menu";
		}

		button_pos = new Rect(Width*1/8, Height*3/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Label (button_pos,
		            "体力" + "\n" +
		            global_data.Stamina_Max,
		            myButtonStyle2);
		
		button_pos = new Rect(Width*1/8, Height*5/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Label (button_pos,
		            "学习" + "\n" +
		            global_data.Learning,
		            myButtonStyle2);
		
		button_pos = new Rect(Width*4/8, Height*3/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Label (button_pos,
		            "社交" + "\n" +
		            global_data.Socialization,
		            myButtonStyle2);
		
		button_pos = new Rect(Width*4/8, Height*5/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Label (button_pos,
		            "品味" + "\n" +
		            global_data.Taste,
		            myButtonStyle2);

	}
	void checkAchievements () {
		global_data.Achievement_Now [0] = Mathf.Min(20,global_data.minigame_count * 4);
		global_data.Achievement_Now [1] =  Mathf.Min(20,global_data.ball_shoot_count * 10);
		global_data.Achievement_Now [2] = global_data.oscilloscope_count > 0 ? 20 : 0;

	}
	void UI_Option_Achievement() {

 		float Width = Screen.width;
 		float Height = Screen.height;
 		float buttonWidth = Screen.width/3;
 		float buttonHeight = Screen.height*2/15;
 		float Height_Adjust = 0;
		
		Rect button_pos;

		if (GUI.Button (new Rect (-10, -10, Width + 10, Height + 10), "", myBackgroundStyle)) {
			at = "Menu";
		}

		checkAchievements ();

		for(int i=0;i!=5;++i) {
			
			button_pos = new Rect(Width*1/8, Height*(1+2*i)/13-Height_Adjust, buttonWidth, buttonHeight);
			
			if (global_data.Achievement_Now[i] == -1) {
				GUI.Label (button_pos,
				            (global_data.Achievement_hide[i] ? "???\n" : (global_data.Achievement_title[i] + "（尚未启动）\n")) +
				            (global_data.Achievement_hide[i] ? "???" : (global_data.Achievement_content_head[i] + global_data.Achievement_content_tail[i])),
				            myButtonStyle2);
			} else if (global_data.Achievement_Now[i] < 20) {
				GUI.Label (button_pos,
				            global_data.Achievement_title[i] + "（进行中）\n" +
//				            (global_data.Achievement_hide[i] ? "???" : (global_data.Achievement_content_head[i] + global_data.Achievement_Now[i] + "/" + global_data.Achievement_content_tail[i])),
				           (global_data.Achievement_hide[i] ? "???" : (global_data.Achievement_content_head[i] + global_data.Achievement_content_tail[i])),
				            myButtonStyle2);
			} else {
				GUI.Label (button_pos,
				            global_data.Achievement_title[i] + "（完成）\n" +
				            global_data.Achievement_content_head[i] + global_data.Achievement_content_tail[i],
				            myButtonStyle2);
			}
			
		}
		
		for(int i=5;i!=global_data.Achievement_Count;++i) {
			
			button_pos = new Rect(Width*4/8, Height*(1+2*(i-5))/13-Height_Adjust, buttonWidth, buttonHeight);
			
			if (global_data.Achievement_Now[i] == -1) {
				GUI.Label (button_pos,
				            (global_data.Achievement_hide[i] ? "???\n" : (global_data.Achievement_title[i] + "（尚未启动）\n")) +
				            (global_data.Achievement_hide[i] ? "???" : (global_data.Achievement_content_head[i] + global_data.Achievement_content_tail[i])),
				            myButtonStyle2);
			} else if (global_data.Achievement_Now[i] < 20) {
				GUI.Label (button_pos,
				            global_data.Achievement_title[i] + "（进行中）\n" +
				            (global_data.Achievement_hide[i] ? "???" : (global_data.Achievement_content_head[i] + global_data.Achievement_Now[i] + "/" + global_data.Achievement_content_tail[i])),
				            myButtonStyle2);
			} else {
				GUI.Label (button_pos,
				            global_data.Achievement_title[i] + "（完成）\n" +
				            global_data.Achievement_content_head[i] + global_data.Achievement_content_tail[i],
				            myButtonStyle2);
			}
			
		}

	}

	void UI_Option_Embed() {

		Rect button_menu_pos;
		Rect label_HP_pos;
		Rect label_clock_pos;
		Rect label_place_pos;
		
 		float Width = Screen.width;
 		float Height = Screen.height;
 		float menuWidth = Screen.height/5;
 		float menuHeight = Screen.height/9;
 		float hpWidth = Screen.width/6;
 		float hpHeight = Screen.width/20;
 		float clockWidth = Screen.width/4;
 		float clockHeight = Screen.width/25;
 		float placeWidth = Screen.width/4;
 		float placeHeight = Screen.width/25;

		button_menu_pos = new Rect(Width*7/9, Height/10, menuWidth, menuHeight);
		if(GUI.Button (button_menu_pos, "Menu", myButtonStyle1)) {
			Debug.Log ("press button_menu to back to other scene");
			Debug.Log ("at = " + at);
			at = "Menu";
		}
		
		label_clock_pos = new Rect(Width*3/8, Height/10, clockWidth, clockHeight);
		string label_clock_print_str = "Day " + global_data.Time_Day + " " + global_data.Time_Hour + ":" + (global_data.Time_Minute<10 ? "0" : "" ) + global_data.Time_Minute;
		GUI.Label (label_clock_pos, label_clock_print_str, myButtonStyle2);
		
		label_place_pos = new Rect(Width*3/8, Height/6, placeWidth, placeHeight);
		string label_place_print_str = global_data.Place_Scene;
		GUI.Label (label_place_pos, label_place_print_str, myButtonStyle2);

		label_HP_pos = new Rect(Width/10, Height/10, hpWidth, hpHeight);
		string label_HP_print_str = "Stamina: " + global_data.Stamina + "/" + global_data.Stamina_Max;
		GUI.Label (label_HP_pos, label_HP_print_str, myButtonStyle2);

	}

	void UI_Option_Option() {

		float Width = Screen.width;
		float Height = Screen.height;

		GUI.Label (new Rect (-10, -10, Width + 10, Height + 10), "", myBackgroundStyle);

		if (global_data.openBGM == true) {
			if (GUI.Button (getPos (200,200,100,40), "关掉音乐", myButtonStyle0)) {
				global_data.openBGM = false;
			}
		} else {
			if (GUI.Button (getPos (200,200,100,40), "开启音乐", myButtonStyle0)) {
				global_data.openBGM = true;
			}
		}
		
		if (global_data.openSCM == true) {
			if (GUI.Button (getPos (200,300,100,40), "关掉音效", myButtonStyle0)) {
				global_data.openSCM = false;
			}
		} else {
			if (GUI.Button (getPos (200,300,100,40), "开启音效", myButtonStyle0)) {
				global_data.openSCM = true;
			}
		}

		if (GUI.Button (new Rect (-10, -10, Width + 10, Height + 10), "", myFrontgroundStyle)) {
			at = "Menu";
		}

	}

	Rect getPos(float myCenterWidth, float myCenterHeight, float myWidth, float myHeight) {
		return new Rect (myCenterWidth - myWidth / 2, myCenterHeight - myHeight / 2, myWidth, myHeight);
	}

	void OnGUI () {

		if (global_data.openUI == false)
			return;

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

		myBackgroundStyle = new GUIStyle (GUI.skin.button);
		myFrontgroundStyle = new GUIStyle (GUI.skin.label);

		string st = "";
		switch (at) {
		case "Embed":
			st += "Embed, ";
			UI_Option_Embed();
			break;
		case "Menu":
			st += "Menu, ";
			UI_Option_Menu();
			break;
		case "Attribute":
			st += "Attr, ";
			UI_Option_Attribute();
			break;
		case "Achievement":
			st += "Achi, ";
			UI_Option_Achievement();
			break;
		case "Option":
			st += "Option, ";
			UI_Option_Option();
			break;
		default:
			st += "default!";
			Debug.Log ("default!!!");
			break;
		}
		Debug.Log (st);
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
