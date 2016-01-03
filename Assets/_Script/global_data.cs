using UnityEngine;
using System.Collections;

public class global_data : MonoBehaviour {

	static global_data _instance;

	static public int Stamina;
	static public int Stamina_Max;
	static public int Learning;
	static public int Socialization;
	static public int Taste;

	static public int Relationship_Teacher;
	static public int Relationship_Principle;
	static public int Relationship_Roommate1;
	static public int Relationship_Roommate2;
	static public int Relationship_Roommate3;
	static public int Relationship_Girlfriend1;
	static public int Relationship_Girlfriend2;
	static public int Relationship_Girlfriend3;
	static public int Relationship_Girlfriend4;

	static public int Time_Day;
	static public int Time_Hour;
	static public int Time_Minute;

	static public string Place_Scene;
	static public int Place_X;
	static public int Place_Y;

	static public int Achievement_Count;
	static public int[] Achievement_Now;
	static public string[] Achievement_title;
	static public string[] Achievement_content_head;
	static public string[] Achievement_content_tail;

	static public int Gallery_Count;
	static public bool[] Gallery_Have;
	static public Texture[] Gallery_Picture;

	static public bool openBGM;
	static public bool openSCM;

	static public global_data Instance {
		get {
			Debug.Log("in get of Instance");
			if (_instance == null)
			{
				// 尝试寻找该类的实例。此处不能用GameObject.Find，因为MonoBehaviour继承自Component。
				//_instance = Object.FindObjectOfType(typeof(global_data)) as global_data;
				
				if (_instance == null)  // 如果没有找到
				{                                       
					GameObject go = new GameObject("_global_data"); // 创建一个新的GameObject
					DontDestroyOnLoad(go);  // 防止被销毁
					_instance = go.AddComponent<global_data>(); // 将实例挂载到GameObject上

					Debug.Log("init data!");

					Gallery_Count = 14;
					Gallery_Have = new bool[Gallery_Count];
					Gallery_Picture = new Texture[Gallery_Count];

					// init all Gallery_Picture

					Achievement_Count = 9;
					Achievement_Now = new int[Achievement_Count];
					Achievement_title = new string[Achievement_Count];
					Achievement_content_head = new string[Achievement_Count];
					Achievement_content_tail = new string[Achievement_Count];

					Achievement_title[0] = "持之以恒";
					Achievement_content_head[0] = "某小游戏玩过至少";
					Achievement_content_tail[0] = "20次";

					Achievement_title[1] = "神射手";
					Achievement_content_head[1] = "篮球投篮";
					Achievement_content_tail[1] = "10连中";

					Achievement_title[2] = "搓轮高手";
					Achievement_content_head[2] = "示波器拟合度调整至";
					Achievement_content_tail[2] = "95%以上";

					Achievement_title[3] = "高级吃货";
					Achievement_content_head[3] = "于食堂内不到";
					Achievement_content_tail[3] = "5秒抢到座位";
					
					Achievement_title[4] = "养生贤人";
					Achievement_content_head[4] = "睡眠总时间达到";
					Achievement_content_tail[4] = "1000小时";
					
					Achievement_title[5] = "有所专长";
					Achievement_content_head[5] = "某属性值达到";
					Achievement_content_tail[5] = "90以上";
					
					Achievement_title[6] = "不会孤独";
					Achievement_content_head[6] = "和妹子聊天次数达到";
					Achievement_content_tail[6] = "100次以上";
					
					Achievement_title[7] = "发现掉落的情书";
					Achievement_content_head[7] = "湖边某特定地点调查至少";
					Achievement_content_tail[7] = "5次";
					
					Achievement_title[8] = "获得路痴称号";
					Achievement_content_head[8] = "调查路牌超过";
					Achievement_content_tail[8] = "10次";

				}
			}
			return _instance;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
