using UnityEngine;
using System.Collections;

public class UI_Start : MonoBehaviour {
	
	public Texture button_Start_Game;
	public Texture button_Load_Game;
	public Texture button_Options;
	public Texture button_Gallery;
	public Texture label_Title;
	public Rect button_Start_Game_pos;
	public Rect button_Load_Game_pos;
	public Rect button_Options_pos;
	public Rect button_Gallery_pos;
	public Rect label_Title_pos;

	void OnGUI () {
		if (!button_Start_Game) {
			Debug.Log ("give me the image of button_Start_Game");
			return;
		}
		if (!button_Load_Game) {
			Debug.Log ("give me the image of button_Load_Game");
			return;
		}
		if (!button_Options) {
			Debug.Log ("give me the image of button_Options");
			return;
		}
		if (!button_Gallery) {
			Debug.Log ("give me the image of button_Gallery");
			return;
		}
		if (!label_Title) {
			Debug.Log ("give me the image of label_clock");
			return;
		}
		if (GUI.Button (button_Start_Game_pos, new GUIContent(button_Start_Game))) {
			Debug.Log ("press button_Start_Game");
		}
		if (GUI.Button (button_Load_Game_pos, new GUIContent(button_Load_Game))) {
			Debug.Log ("press button_Load_Game");
		}
		if (GUI.Button (button_Options_pos, new GUIContent(button_Options))) {
			Debug.Log ("press button_Options");
		}
		if (GUI.Button (button_Gallery_pos, new GUIContent(button_Gallery))) {
			Debug.Log ("press button_Gallery");
		}
		GUI.Label (label_Title_pos, new GUIContent(label_Title));
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
