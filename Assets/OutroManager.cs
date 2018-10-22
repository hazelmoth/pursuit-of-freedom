using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OutroManager: MonoBehaviour {

	[SerializeField] TextMeshProUGUI introText;
	[SerializeField] SpriteRenderer introRenderer;
	int currentSlide = 1;

	// Use this for initialization
	void Start () {
		ToSlide1 ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if (currentSlide == 8)
				FinishSlides ();
			else {
				Invoke ("ToSlide" + (currentSlide + 1), 0f);
				currentSlide++;
			}
		}
	}

	void ToSlide1 () {
		introText.text = "At last, you have arrived at EARTH.";
	}
	void ToSlide2 () {
		introText.text = "The planet is dying.";
	}
	void ToSlide3 () {
		introText.text = "Overpopulation and unrestrained pollution have rendered Earth almost uninhabitable.";
	}
	void ToSlide4 () {
		introText.text = "You will live the rest of your days in poverty, struggling to survive.";
	}
	void ToSlide5 () {
		introText.text = "It's worth it though, isn't it?";
	}
	void ToSlide6 () {
		introText.text = "Surely any price is worth paying...";
	}
	void ToSlide7 () {
		introText.text = "For FREEDOM?";
	}
	void ToSlide8 () {
		introText.text = "Right?";
	}
	void FinishSlides () {
		Application.Quit ();
	}
}
