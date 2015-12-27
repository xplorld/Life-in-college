 using UnityEngine;
using System.Collections;

public class minigame_lab_sinRenderer : MonoBehaviour {
	public int vertexNumber = 100;
	public float lineWidth = 0.2f;
	public Vector2 startPoint = new Vector2 (0, 0);
	public Vector2 endPoint = new Vector2 (1, 0);
	public float frequency = 1;
	public float amplitude = 1;
	public Color lineColor {
		set {
			lineRenderer.SetColors (value, value);
		}
	}
	private LineRenderer lineRenderer;
	private float period = 2;
	void Start() {
		lineRenderer = GetComponent<LineRenderer> ();
		lineColor = Color.green;
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetVertexCount(vertexNumber);
		lineRenderer.SetWidth (lineWidth, lineWidth);
	}
	void Update() {
		float dx = (endPoint.x - startPoint.x) / vertexNumber;
		float dy = (endPoint.y - startPoint.y) / vertexNumber;
		float x = startPoint.x;
		float y = startPoint.y;
		float t0 = Time.time * 2 * Mathf.PI / period;
		float dt = (2 * Mathf.PI * frequency * 5) / vertexNumber; //5 is magic for visual effect
		for (int i = 0; i < vertexNumber; ++i) {
			Vector3 pos = new Vector3(i*dx + x, amplitude * 2 * Mathf.Sin(i*dt + t0) + i*dy + y, 0); //2 is magic for visual effect
			lineRenderer.SetPosition(i, pos);
		}
	}
}