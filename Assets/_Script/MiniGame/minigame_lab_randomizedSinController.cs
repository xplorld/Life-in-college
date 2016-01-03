using UnityEngine;
using System.Collections;

public class minigame_lab_randomizedSinController : MonoBehaviour {
	public minigame_lab_sinRenderer sinRenderer;
	// Use this for initialization
	void Start () {
		float frequency = Random.Range ((float)0.5, (float)0.9);
		float amplitude = Random.Range ((float)0.5, (float)0.9);
		sinRenderer.frequency = frequency;
		sinRenderer.amplitude = amplitude;
	}

}
