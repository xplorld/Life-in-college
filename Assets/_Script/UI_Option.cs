using UnityEngine;
using System.Collections;

public class UI_Option : MonoBehaviour {

	public Texture button_attribute;
	public Texture button_achievement;
	public Texture button_task;
	public Texture button_option;
	public Texture[] button_menu;
	public Texture label_HP;
	public Texture label_clock;
	public Rect button_attribute_pos;
	public Rect button_achievement_pos;
	public Rect button_task_pos;
	public Rect button_option_pos;
	public Rect button_menu_pos;
	public Rect label_HP_pos;
	public Rect label_clock_pos;
	private int button_menu_open = 0;

	void OnGUI () {
		if (!button_attribute) {
			Debug.Log ("give me the image of button_attribute");
			return;
		}
		if (!button_achievement) {
			Debug.Log ("give me the image of button_achievement");
			return;
		}
		if (!button_task) {
			Debug.Log ("give me the image of button_task");
			return;
		}
		if (!button_option) {
			Debug.Log ("give me the image of button_option");
			return;
		}
		if (!button_menu[0] || !button_menu[1]) {
			Debug.Log ("give me the image of button_menu");
			return;
		}
		if (!label_HP) {
			Debug.Log ("give me the image of label_HP");
			return;
		}
		if (!label_clock) {
			Debug.Log ("give me the image of label_clock");
		}
		if (GUI.Button (button_attribute_pos, new GUIContent(button_attribute))) {
			Debug.Log ("press button_attribute");
		}
		if (GUI.Button (button_achievement_pos, new GUIContent(button_achievement))) {
			Debug.Log ("press button_achievement");
		}
		if (GUI.Button (button_task_pos, new GUIContent(button_task))) {
			Debug.Log ("press button_task");
		}
		if (GUI.Button (button_option_pos, new GUIContent(button_option))) {
			Debug.Log ("press button_option");
		}
		if (GUI.Button (button_menu_pos, new GUIContent (button_menu[button_menu_open]))) {
			button_menu_open = 1 - button_menu_open;
			Debug.Log ("press button_menu");
		}
		GUI.Label (label_HP_pos, new GUIContent (label_HP));
		GUI.Label (label_clock_pos, new GUIContent(label_clock));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
