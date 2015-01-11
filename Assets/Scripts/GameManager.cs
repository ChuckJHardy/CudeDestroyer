using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject startText;

	public static GameManager instance = null;
	private bool startKeyHit = false;

	void Start () {
		if (instance == null || instance != this) { instance = this; }
	}
	
	void Update () {
	
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
}
