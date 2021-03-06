﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	public float restartDelay = 1f;

	public int totalLives = 3;
	public int scorePerBrick = 5;
	public int livesLeft = 3;
	public int currentScore = 0;

	public GameObject startText;
	public GameObject bricksPrefab;
	public GameObject paddlePrefab;

	public GameObject tryAgainText;
	public GameObject winnerText;
	public GameObject loserText;

	public Button resetButton;

	public Text livesText;
	public Text scoreText;
	public Text finalScoreText;

	private bool startKeyHit = false;
	private GameObject bricksClone;
	private GameObject paddleClone;

	void Start () {
		if (instance == null || instance != this) { instance = this; }

		Initialize();
	}

	void Initialize () {
		bricksClone = Instantiate (bricksPrefab, new Vector2 (-3, 0), Quaternion.identity) as GameObject;
		paddleClone = Instantiate (paddlePrefab, new Vector2 (0, -9), Quaternion.identity) as GameObject;

		tryAgainText.SetActive(false);

		resetButton.onClick.AddListener(() => { Reset (); });
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

	public void UpdateStore () {
		currentScore += (scorePerBrick * livesLeft);
		scoreText.text = currentScore.ToString ();
	}

	public void CheckGameStatus () {
		GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

		Debug.Log ("Bricks Count" + bricks.Length);

		if (livesLeft > 0 && bricks.Length == 0) {
			winnerText.SetActive(true);
		}
	}

	public void Lost () {
		livesLeft--;
		livesText.text = livesLeft + "/" + totalLives;

		Clean ();

		if (livesLeft == 0) {
			loserText.SetActive(true);

			finalScoreText.text = "Final Score: " + currentScore.ToString ();
			finalScoreText.gameObject.SetActive(true);

			resetButton.gameObject.SetActive(true);
		} else {
			tryAgainText.SetActive(true);
			Invoke ("Initialize", restartDelay);
		}
	}

	public void Clean () {
		Destroy (bricksClone);
		Destroy (paddleClone);
	}

	public void Reset () {
		Application.LoadLevel (Application.loadedLevel);
	}
}
