using UnityEngine;
using System.Collections;

public class LostTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		GameManager.instance.Lost ();
	}

}