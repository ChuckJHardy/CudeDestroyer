using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float speed = 1f;
	public float boundary = 15f;
	private float xPostion;

	void Update () {
		xPostion = transform.position.x + Input.GetAxis("Horizontal") * speed;

		transform.position = new Vector2(
			Mathf.Clamp(xPostion, -boundary, boundary), 
			transform.position.y
		);
	}
}
