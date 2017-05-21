using UnityEngine;
using System.Collections;

public class CameraResize: MonoBehaviour {

	public float orthographicSize = 5;
	public float aspect = 1.33333f;
	private Camera _camera;

	// Use this for initialization
	void Start () {
	
		_camera = Camera.main;

		Camera.main.projectionMatrix = Matrix4x4.Ortho (
			-orthographicSize * aspect, orthographicSize * aspect,
			-orthographicSize, orthographicSize,
			_camera.nearClipPlane, _camera.farClipPlane);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
