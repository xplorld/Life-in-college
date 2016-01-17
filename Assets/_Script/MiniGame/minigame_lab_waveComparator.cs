using UnityEngine;
using System.Collections;

public class minigame_lab_waveComparator : MonoBehaviour {
	public minigame_lab_sinRenderer wave1;
	public minigame_lab_sinRenderer wave2;
	void Update () {
		if (Mathf.Abs(wave1.amplitude - wave2.amplitude) < 0.01 && Mathf.Abs(wave1.frequency - wave2.frequency) < 0.01) {
			//tuning succeed!
			wave1.lineColor = Color.red;
			wave2.lineColor = Color.red;
			Application.LoadLevel("Scene_6_Lab");
		}
	}
}
