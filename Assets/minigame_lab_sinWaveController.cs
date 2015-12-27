using UnityEngine;
using System.Collections;

public class minigame_lab_sinWaveController : MonoBehaviour {
	public bool amplitudeOrFreq = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float percentage = GetComponent<RadialSlider> ().percentage;
		minigame_lab_sinRenderer sinRenderer = GetComponentInParent<minigame_lab_sinRenderer> ();
		if (amplitudeOrFreq) {
			sinRenderer.amplitude = percentage;
		} else {
			sinRenderer.frequency = percentage;
		}
	}
}
