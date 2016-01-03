using UnityEngine;
using System.Collections;
using System.IO;

public class UI_Start : MonoBehaviour {

	public static global_data gd;

	//public Texture button_Start_Game;
	//public Texture button_Load_Game;
	//public Texture button_Options;
	//public Texture button_Gallery;
	//public Texture label_Title;
	public Rect button_Start_Game_pos;
	public Rect button_Load_Game_pos;
	public Rect button_Options_pos;
	public Rect button_Gallery_pos;
	public Rect label_Title_pos;

	private float Width = Screen.width;
	private float Height = Screen.height;
	private float buttonWidth = Screen.width/4;
	private float buttonHeight = Screen.width/4*122/500;
	private float titleWidth = Screen.width/2;
	private float titleHeight = Screen.width/10;
	//private float hpWidth = Screen.width/6;
	//private float hpHeight = Screen.width/20;
	//private float clockWidth = Screen.width/4;
	//private float clockHeight = Screen.width/25;
	//private float placeWidth = Screen.width/4;
	//private float placeHeight = Screen.width/25;

	GUIStyle myButtonStyle;
	GUIStyle myButtonStyle2;
	
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

			sr.Close();
			Debug.Log ("load finish");
		} else {
			Debug.Log ("No old game can be load.");
		}
	}

	void OnGUI () {

		// Create style for a button
		myButtonStyle = new GUIStyle (GUI.skin.button);
		myButtonStyle.fontSize = 50;
		
		// Load and set Font
		Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
		myButtonStyle.font = myFont;
		
		// Set color for selected and unselected buttons
		myButtonStyle.normal.textColor = Color.white;
		myButtonStyle.hover.textColor = Color.white;
		
		// use style in button
		//bool testButtonTwo = GUI.Button(new Rect(10,10,50,50), "test", myButtonStyle);

		// Create style for a button
		myButtonStyle2 = new GUIStyle (GUI.skin.button);
		myButtonStyle2.fontSize = 20;
		
		// Load and set Font
		myButtonStyle2.font = myFont;
		
		// Set color for selected and unselected buttons
		myButtonStyle2.normal.textColor = Color.white;
		myButtonStyle2.hover.textColor = Color.white;
		
		// use style in button
		//bool testButtonTwo = GUI.Button(new Rect(10,10,50,50), "test", myButtonStyle);

		button_Start_Game_pos = new Rect(Width*3/8, Height*3/8, buttonWidth, buttonHeight);
		if (GUI.Button (button_Start_Game_pos, "Start Game", myButtonStyle2)) {
			Debug.Log ("press button_Start_Game");
			Start_Game();
		}
		button_Load_Game_pos = new Rect(Width*3/8, Height*4/8, buttonWidth, buttonHeight);
		if (GUI.Button (button_Load_Game_pos, "Load Game", myButtonStyle2)) {
			Debug.Log ("press button_Load_Game");
			Load_Game();
		}
		button_Options_pos = new Rect(Width*3/8, Height*5/8, buttonWidth, buttonHeight);
		if (GUI.Button (button_Options_pos, "Options", myButtonStyle2)) {
			Debug.Log ("press button_Options");
		}
		button_Gallery_pos = new Rect(Width*3/8, Height*6/8, buttonWidth, buttonHeight);
		if (GUI.Button (button_Gallery_pos, "Gallery", myButtonStyle2)) {
			Debug.Log ("press button_Gallery");
		}
		label_Title_pos = new Rect(Width/4, Height/10, titleWidth, titleHeight);
		GUI.Button (label_Title_pos, "Life in College", myButtonStyle);
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
