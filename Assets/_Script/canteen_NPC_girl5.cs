using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class canteen_NPC_girl5 : MonoBehaviour {
	//dialogue contents
	private string[] dialog={
		"小萌:哇！小马你快看！这里的荷花池好漂亮呀！",
		"小马：噢。",
		"小萌：诶同学你也是来看荷花池的嘛？",
		"我：\n是的，我听说这里的荷花池很漂亮，所以也想来看看。（Y）\n不是的，我只是想去吃饭，恰巧经过这而已。（N）",
		"小萌：真的吗？！小马你看，不只我一个人这么听说吧。同学你真懂得欣赏！",
		"小萌：是吗？真遗憾，那你快去吃饭吧。"
	};
	//current index
	private int index = -1 ;
	//GUI TEXT
	public Text NPCtext;

	//talk icon
	public Texture TalkIcon;
	//if show the talkicon
	public bool isTalk=false;
	private float distance_x;
	private GameObject girl;
	private GameObject protagonist;
	// Use this for initialization
	void Start () {
		NPCtext = GameObject.Find("Canvas/Text").GetComponent<Text>();
		girl = GameObject.Find("girl_5");
		protagonist = GameObject.Find ("protagonist");
	}
	void FixedUpdate(){
		Rigidbody2D rb_girl = girl.GetComponent<Rigidbody2D> ();
		Rigidbody2D rb_protagonist = protagonist.GetComponent<Rigidbody2D> ();
		distance_x = rb_girl.position.x - rb_protagonist.position.x;
	}
	// Update is called once per frame
	void Update () {

			if(Input.GetKeyDown(KeyCode.Space)&&distance_x<=3&&index!=3){//if input == space
				isTalk=true;
				Time.timeScale=0;//Pause
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
					if(index<dialog .Length){

						index=index+1;
				
						NPCtext.text=dialog[index];

					}
					else {
						index=-1;
						isTalk=false;
						Time.timeScale=1;//Resume user can walk
					}
				}
			}
			else if(index==3&&(Input.GetKeyDown(KeyCode.Y)||Input.GetKeyDown(KeyCode.N))){//Choose Y or N and end the dialogue
			 
				if(Input.GetKeyDown(KeyCode.Y)){

					index=4;

					NPCtext.text=dialog[index];

					index=dialog .Length;

				
					
				}
				else if(Input.GetKeyDown(KeyCode.N)){

					index=5;
					NPCtext.text=dialog[index];
					index=dialog .Length;
					

					
				}
			
			}

	}
	void OnGUI(){
		if (isTalk) {
			Cursor.visible=false;
			Rect backgroundRect=new Rect(Screen.width*(0.5f)/10,
			            	   		Screen.height*6/11,
			         	    	     Screen.width*9/10,
			                             Screen.height*(4.5f)/11
				);
			Rect textRect=new Rect(Screen.width*(0.5f)/10+40,
			                             Screen.height*6/11+60,
			                             Screen.width*9/10-40,Screen.height*(4.5f)/11-60);
			GUI.DrawTexture(backgroundRect,TalkIcon);
			GUI.Label(textRect,NPCtext.text);
		}
	}
}
