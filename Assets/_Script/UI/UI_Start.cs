using UnityEngine;
using System.Collections;
using System.IO;

public class UI_Start : MonoBehaviour {

	public static global_data gd;

 	string at = "Menu";
	int gallery_page = 1;
	int gallery_now = -1;

	GUIStyle myTitleStyle;
	GUIStyle myButtonStyle0;
	GUIStyle myButtonStyle1;
	GUIStyle myButtonStyle2;
	GUIStyle myBackgroundStyle;
	GUIStyle myFrontgroundStyle;
	Font myFont;

	void Awake() {
		gd = global_data.Instance;
		Debug.Log(global_data.Time_Day);
		Debug.Log(global_data.Time_Hour);
		Debug.Log(global_data.Time_Minute);
		Debug.Log(global_data.Place_Scene);
	}

	void Start_Game() {

		Debug.Log ("init data for new game");

		global_data.Stamina = 95;
		global_data.Stamina_Max = 95;
		global_data.Learning = 95;
		global_data.Socialization = 95;
		global_data.Taste = 95;

		global_data.Relationship_Teacher = 0;
		global_data.Relationship_Principle = 0;
		global_data.Relationship_Roommate1 = 0;
		global_data.Relationship_Roommate2 = 0;
		global_data.Relationship_Roommate3 = 0;
		global_data.Relationship_Girlfriend1 = 0;
		global_data.Relationship_Girlfriend2 = 0;
		global_data.Relationship_Girlfriend3 = 0;
		global_data.Relationship_Girlfriend4 = 0;

		global_data.Time_Day = 1;
		global_data.Time_Hour = 15;
		global_data.Time_Minute = 0;

		global_data.Place_Scene = "综合体育馆";
		global_data.Place_X = -1;
		global_data.Place_Y = -1;

		for(int i=0;i!=global_data.Achievement_Count;++i) global_data.Achievement_Now[i]=-1;

		global_data.openBGM = true;
		global_data.openSCM = true;
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

			global_data.Time_Day = int.Parse(sr.ReadLine());
			global_data.Time_Hour = int.Parse(sr.ReadLine());
			global_data.Time_Minute = int.Parse(sr.ReadLine());

			global_data.Place_Scene = sr.ReadLine();
			global_data.Place_X = int.Parse(sr.ReadLine());
			global_data.Place_Y = int.Parse(sr.ReadLine());

			for(int i=0;i!=global_data.Achievement_Count;++i) global_data.Achievement_Now[i] = int.Parse(sr.ReadLine());

			global_data.openBGM = bool.Parse(sr.ReadLine());
			global_data.openSCM = bool.Parse(sr.ReadLine());

			sr.Close();
			Debug.Log ("load finish");
		} else {
			Debug.Log ("No old game can be load.");
		}
	}

	void UI_Start_Menu() {

		Rect button_Start_Game_pos;
 		Rect button_Load_Game_pos;
 		Rect button_Gallery_pos;
		
 		float Width = Screen.width;
 		float Height = Screen.height;
 		float buttonWidth = Screen.width/4;
 		float buttonHeight = Screen.width/4*122/500;
 		float titleWidth = Screen.width/2;
 		float titleHeight = Screen.width/10;

		button_Start_Game_pos = new Rect(Width*2/8, Height*5/8, buttonWidth, buttonHeight);
		if (GUI.Button (button_Start_Game_pos, "Start Game", myButtonStyle1)) {
			Debug.Log ("press button_Start_Game");
			Start_Game();
			Application.LoadLevel("Scene_1_Gate");
		}
		button_Load_Game_pos = new Rect(Width*3/8, Height*6/8, buttonWidth, buttonHeight);
		if (GUI.Button (button_Load_Game_pos, "Load Game", myButtonStyle1)) {
			Debug.Log ("press button_Load_Game");
			Load_Game();
		}
		button_Gallery_pos = new Rect(Width*4/8, Height*7/8, buttonWidth, buttonHeight);
		if (GUI.Button (button_Gallery_pos, "Gallery", myButtonStyle1)) {
			Debug.Log ("press button_Gallery");
			at = "Gallery";
			gallery_page = 0;
		}
	}

	void UI_Start_Gallery() {

 		float Width = Screen.width;
 		float Height = Screen.height;

 		Texture image_unknown = (Texture2D)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/_Image/gallery/问号.jpg", typeof(Texture2D));

		if (gallery_now != -1) {
			if (GUI.Button (getPos (Width / 2, Height / 2, Width + 5, Height + 5),
			                global_data.Gallery_Have [gallery_now] ? global_data.Gallery_Picture [gallery_now] : image_unknown,
			                myBackgroundStyle)) {
				gallery_now = -1;
			}
			return;

		} else {

			GUI.Label (getPos (Width/2,Height/2,Width+5,Height+5), "", myBackgroundStyle);
			
			float adjust_w = 300 * 0.618f;
			float adjust_h = 300 * 0.382f;
			float button_w = 500 * 0.618f;
			float button_h = 500 * 0.382f;
			if (gallery_page * 4 < global_data.Gallery_Count) {
				if (GUI.Button (getPos (Width/2-adjust_w,Height/2-adjust_h,button_w,button_h),
				                global_data.Gallery_Have[gallery_page*4] ? global_data.Gallery_Picture[gallery_page*4] : image_unknown,
				                myButtonStyle2)) {
					gallery_now = gallery_page * 4;
				}
			}
			if (gallery_page * 4 + 1 < global_data.Gallery_Count) {
				if (GUI.Button (getPos (Width/2-adjust_w,Height/2+adjust_h,button_w,button_h),
				                global_data.Gallery_Have[gallery_page*4+1] ? global_data.Gallery_Picture[gallery_page*4+1] : image_unknown,
				                myButtonStyle2)) {
					gallery_now = gallery_page * 4 + 1;
				}
			}
			if (gallery_page * 4 + 2 < global_data.Gallery_Count) {
				if (GUI.Button (getPos (Width/2+adjust_w,Height/2-adjust_h,button_w,button_h),
				                global_data.Gallery_Have[gallery_page*4+2] ? global_data.Gallery_Picture[gallery_page*4+2] : image_unknown,
				                myButtonStyle2)) {
					gallery_now = gallery_page * 4 + 2;
				}
			}
			if (gallery_page * 4 + 3 < global_data.Gallery_Count) {
				if (GUI.Button (getPos (Width/2+adjust_w,Height/2+adjust_h,button_w,button_h),
				                global_data.Gallery_Have[gallery_page*4+3] ? global_data.Gallery_Picture[gallery_page*4+3] : image_unknown,
				                myButtonStyle2)) {
					gallery_now = gallery_page * 4 + 3;
				}
			}
			
			if (GUI.Button (getPos (Width/2-100,Height*9/10,60,30), "上一页", myButtonStyle2)) {
				if(gallery_page > 0) {
					gallery_page = gallery_page - 1;
				}
				Debug.Log ("in Back gallery_page, gallery_page = " + gallery_page);
			}
			if (GUI.Button (getPos (Width/2+100,Height*9/10,60,30), "下一页", myButtonStyle2)) {
				if(gallery_page < (global_data.Gallery_Count+3)/4 - 1) {
					gallery_page = gallery_page + 1;
				}
				Debug.Log ("in Next gallery_page, gallery_page = " + gallery_page);
			}
			Debug.Log ("after Label, gallery_page = " + gallery_page);
			GUI.Label (getPos (Width/2,Height*9/10,60,30), (gallery_page+1) + "/" + (global_data.Gallery_Count+3)/4, myButtonStyle2);
			
			if (GUI.Button (getPos (Width / 2, Height / 2, Width + 5, Height + 5), "", myFrontgroundStyle)) {
				at = "Menu";
			}

		}


	}

	Rect getPos(float myCenterWidth, float myCenterHeight, float myWidth, float myHeight) {
		return new Rect (myCenterWidth - myWidth / 2, myCenterHeight - myHeight / 2, myWidth, myHeight);
	}

	void OnGUI () {

		// Create style for a button
		myTitleStyle = new GUIStyle (GUI.skin.button);
		myTitleStyle.fontSize = 50;
		
		// Load and set Font
		Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
		myTitleStyle.font = myFont;
		
		// Set color for selected and unselected buttons
		myTitleStyle.normal.textColor = Color.white;
		myTitleStyle.hover.textColor = Color.white;
		
		// use style in button
		//bool testButtonTwo = GUI.Button(new Rect(10,10,50,50), "test", myTitleStyle);

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

		switch (at) {
		case "Menu":
			UI_Start_Menu();
			break;
		case "Gallery":
			UI_Start_Gallery();
			break;
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
