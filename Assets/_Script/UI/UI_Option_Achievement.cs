using UnityEngine;
using System.Collections;

public class UI_Option_Achievement : MonoBehaviour {

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

		for(int i=0;i!=5;++i) {
			
			button_pos = new Rect(Width*1/8, Height*(1+2*i)/13-Height_Adjust, buttonWidth, buttonHeight);

			if (global_data.Achievement_Now[i] == -1) {
				GUI.Button (button_pos,
				            global_data.Achievement_title[i] + "（尚未启动）\n" +
				            global_data.Achievement_content_head[i] + global_data.Achievement_content_tail[i],
				            myButtonStyle2);
			} else if (global_data.Achievement_Now[i] < 20) {
				GUI.Button (button_pos,
				            global_data.Achievement_title[i] + "（进行中）\n" +
				            global_data.Achievement_content_head[i] + global_data.Achievement_Now[i] + "/" + global_data.Achievement_content_tail[i],
				            myButtonStyle2);
			} else {
				GUI.Button (button_pos,
				            global_data.Achievement_title[i] + "（完成）\n" +
				            global_data.Achievement_content_head[i] + global_data.Achievement_content_tail[i],
				            myButtonStyle2);
			}

		}

		for(int i=5;i!=global_data.Achievement_Count;++i) {
			
			button_pos = new Rect(Width*4/8, Height*(1+2*(i-5))/13-Height_Adjust, buttonWidth, buttonHeight);

			if (global_data.Achievement_Now[i] == -1) {
				GUI.Button (button_pos,
				            global_data.Achievement_title[i] + "（尚未启动）\n" +
				            global_data.Achievement_content_head[i] + global_data.Achievement_content_tail[i],
				            myButtonStyle2);
			} else if (global_data.Achievement_Now[i] < 20) {
				GUI.Button (button_pos,
				            global_data.Achievement_title[i] + "（进行中）\n" +
				            global_data.Achievement_content_head[i] + global_data.Achievement_Now[i] + "/" + global_data.Achievement_content_tail[i],
				            myButtonStyle2);
			} else {
				GUI.Button (button_pos,
				            global_data.Achievement_title[i] + "（完成）\n" +
				            global_data.Achievement_content_head[i] + global_data.Achievement_content_tail[i],
				            myButtonStyle2);
			}
			
		}

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
