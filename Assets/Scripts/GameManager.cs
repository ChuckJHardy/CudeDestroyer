using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	public float restartDelay = 3f;

	public int totalLives = 3;
	public int livesLeft = 3;

	public GameObject startText;
	public GameObject bricksPrefab;
	public GameObject paddlePrefab;

	public Text livesText;

	private bool startKeyHit = false;
	private GameObject bricksClone;
	private GameObject paddleClone;

	void Start () {
		if (instance == null || instance != this) { instance = this; }

		Initialize();
	}
	
	void Initialize () {
		bricksClone = Instantiate (bricksPrefab, transform.position, Quaternion.identity) as GameObject;
		paddleClone = Instantiate (paddlePrefab, new Vector2 (0, -9), Quaternion.identity) as GameObject;
	}

	public bool StartGame() {
		startKeyHit = Input.GetKeyDown("space");

		if (startKeyHit) {
			Debug.Log ("Start Game");

			startText.SetActive(false);

			return true;
		}

		return false;
	}

	public void Lost () {
		livesLeft--;
		livesText.text = livesLeft + "/" + totalLives;

		Reset ();

		Invoke ("Initialize", restartDelay);
	}

	private void Reset () {
		Destroy (bricksClone);
		Destroy (paddleClone);
	}
}
