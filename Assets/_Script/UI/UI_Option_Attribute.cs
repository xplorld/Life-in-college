using UnityEngine;
using System.Collections;

public class UI_Option_Attribute : MonoBehaviour {

	public static global_data gd;

	private float Width = Screen.width;
	private float Height = Screen.height;
	private float buttonWidth = Screen.width/3;
	private float buttonHeight = Screen.height*2/15;
	private float Height_Adjust = 0;

	public Rect button_pos;

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

		Debug.Log (global_data.Achievement_content_tail [0]);

		button_pos = new Rect(Width*1/8, Height*3/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Button (button_pos,
		            "体力" + "\n" +
		            global_data.Stamina_Max,
		            myButtonStyle2);

		button_pos = new Rect(Width*1/8, Height*5/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Button (button_pos,
		            "学习" + "\n" +
		            global_data.Learning,
		            myButtonStyle2);

		button_pos = new Rect(Width*4/8, Height*3/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Button (button_pos,
		            "社交" + "\n" +
		            global_data.Socialization,
		            myButtonStyle2);

		button_pos = new Rect(Width*4/8, Height*5/13-Height_Adjust, buttonWidth, buttonHeight);
		GUI.Button (button_pos,
		            "品味" + "\n" +
		            global_data.Taste,
		            myButtonStyle2);

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
