using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		Destroy (gameObject);
		GameManager.instance.CheckGameStatus ();
		GameManager.instance.UpdateStore ();
	}

}
