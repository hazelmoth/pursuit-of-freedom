using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CourseManager : MonoBehaviour {

	[SerializeField] GameObject window;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnWindowButton () {
		window.SetActive (false);
		Time.timeScale = 1f;
	}

	public static void OnShipCrashed (GameObject ship) {
		ship.transform.position = Vector3.zero;
		ship.transform.rotation = Quaternion.identity;
		ship.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		ship.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
	}

	public static void OnShipFinished () {
		GameStatus.sectionsPassed++;
		if (GameStatus.sectionsPassed == 1)
			SceneManager.LoadScene ("checkpoint");
		else if (GameStatus.sectionsPassed == 2) {
			SceneManager.LoadScene ("checkpoint 2");
		}
		else if (GameStatus.sectionsPassed == 3) {
			SceneManager.LoadScene ("checkpoint 3");
		}
		else if (GameStatus.sectionsPassed == 4) {
			SceneManager.LoadScene ("checkpoint 4");
		}
		else if (GameStatus.sectionsPassed == 5) {
			SceneManager.LoadScene ("outro");
		}
	}
}
