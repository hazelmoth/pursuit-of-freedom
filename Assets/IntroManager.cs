using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

	[SerializeField] TextMeshProUGUI introText;
	[SerializeField] SpriteRenderer introRenderer;
	[SerializeField] Sprite spritePrefab1;
	[SerializeField] Sprite spritePrefab2;
	[SerializeField] Sprite spritePrefab3;
	int currentSlide = 0;

	// Use this for initialization
	void Start () {
		ToSlide0 ();
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
	void ToSlide0 () {
		introRenderer.sprite = null;
		introText.text = "(ANY KEY TO CONTINUE)";
	}
	void ToSlide1 () {
		introRenderer.sprite = spritePrefab1;
		introText.text = "Since the dawn of the modern era, two nations have ruled over the universe:";
	}
	void ToSlide2 () {
		introRenderer.sprite = spritePrefab1;
		introText.text = "EARTH and SPACE.";
	}
	void ToSlide3 () {
		introRenderer.sprite = spritePrefab2;
		introText.text = "Since its inception, SPACE has been hailed for the FREEDOM offered to its citizens.";
	}
	void ToSlide4 () {
		introRenderer.sprite = spritePrefab2;
		introText.text = "The last decade, however, has been a time of great TURMOIL throughout space.";
	}
	void ToSlide5 () {
		introRenderer.sprite = spritePrefab3;
		introText.text = "The freedoms that defined the nation have gradually been eroded;";
	}
	void ToSlide6 () {
		introRenderer.sprite = spritePrefab3;
		introText.text = "Where they once reigned, AUTOCRACY has taken hold.";
	}
	void ToSlide7 () {
		introRenderer.sprite = spritePrefab3;
		introText.text = "As a FREEDOM-loving REBEL, you are left with only one option:";
	}
	void ToSlide8 () {
		introRenderer.sprite = spritePrefab1;
		introText.text = "ESCAPE SPACE at all costs.";
	}
	void FinishSlides () {
		SceneManager.LoadScene ("main");
	}
}
