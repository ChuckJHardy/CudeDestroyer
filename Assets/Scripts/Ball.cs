using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 600f;

	private bool startKeyHit = false;
	private bool ballInMotion = false;
	private Rigidbody2D ball;

	void Awake () {
		ball = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		startKeyHit = Input.GetKeyDown("space");

		if (!ballInMotion && startKeyHit) {
			transform.parent = null;
			ballInMotion = true;
			ball.isKinematic = false;
			ball.AddForce(new Vector2(speed, speed));
		}
	}
}
