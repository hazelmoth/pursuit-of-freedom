using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CheckpointManager : MonoBehaviour {

	[SerializeField] GameObject popupPanel;
	[SerializeField] GameObject optionsPanel;
	[SerializeField] GameObject throwButtons;
	[SerializeField] GameObject finishButton;
	[SerializeField] GameObject checkpointSprite;
	[SerializeField] GameObject duelSprite;
	[SerializeField] GameObject gunshotSprite;
	[SerializeField] TextMeshProUGUI popupText;
	[SerializeField] TextMeshProUGUI finishButtonText;
	[SerializeField] TextMeshProUGUI popupWindowTitle;
	[SerializeField] TextMeshProUGUI duelCountdownText;
	[SerializeField] TextMeshProUGUI gunJammedText;
	bool lostTheThrow = false;
	bool isPreparingToDuel = false;
	bool isCountingDown = false;
	bool isDueling = false;
	bool hasWonTheDuel = false;
	bool gunIsJammed = false;
	bool countdownTextShouldBeFlyingOffTheScreen = false;

	// Use this for initialization
	void Start () {
		popupPanel.SetActive (false);
		optionsPanel.SetActive (true);
		checkpointSprite.SetActive (true);
		duelSprite.SetActive (false);
		duelCountdownText.text = "";
		duelCountdownText.gameObject.SetActive (true);
		gunJammedText.gameObject.SetActive (false);
		gunshotSprite.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isDueling && !gunIsJammed)
				OnWinDuel ();
			else if (isCountingDown)
				OnGunJammed ();
		}
		if (countdownTextShouldBeFlyingOffTheScreen && duelCountdownText.transform.position.y <= 30f) {
			duelCountdownText.transform.Translate (Vector3.up * 15f * Time.deltaTime);
		}
	}

	public void OnPersuadeButton () {
		popupPanel.SetActive (true);
		optionsPanel.SetActive (false);
		finishButton.SetActive (false);
		throwButtons.SetActive (true);
	}
	public void OnDuelButton () {
		PrepareToDuel ();
	}

	public void OnThrowRockButton () {
		EventSystem.current.SetSelectedGameObject(null);
		Throw ("rock");
	}
	public void OnThrowPaperButton () {
		EventSystem.current.SetSelectedGameObject(null);
		Throw ("paper");
	}
	public void OnThrowScissorsButton () {
		EventSystem.current.SetSelectedGameObject(null);
		Throw ("scissors");
	}
	public void OnFinishButton () {
		EventSystem.current.SetSelectedGameObject(null);
		if (hasWonTheDuel) {
			SceneManager.LoadScene ("main");
		} else if (isPreparingToDuel) {
			StartDuel ();
		} else if (lostTheThrow) {
			PrepareToDuel ();
		} else {
			SceneManager.LoadScene ("main");
		}
	}
	void StartDuel () {
		popupPanel.SetActive (false);
		isPreparingToDuel = false;
		isCountingDown = true;
		duelCountdownText.text = "3";
		Invoke ("CountDownTo2", 1f);
		Invoke ("CountDownTo1", 2f);
		Invoke ("FinishCountdown", 3f);
	}
	void CountDownTo2 () {
		duelCountdownText.text = "2";
	}
	void CountDownTo1 () {
		duelCountdownText.text = "1";
	}
	void FinishCountdown () {
		duelCountdownText.text = "DUEL!";
		isPreparingToDuel = false;
		isDueling = true;
		isCountingDown = false;
		countdownTextShouldBeFlyingOffTheScreen = true;
		Invoke ("GetShot", 0.5f);
	}
	void OnWinDuel () {
		popupPanel.SetActive (true);
		popupWindowTitle.text = "DUELING";
		popupText.text = "The SECURITY OFFICER is now DEAD.\nYou can continue on your way.";
		finishButtonText.text = "Onward!";
		isDueling = false;
		hasWonTheDuel = true;
		duelCountdownText.text = " ";
	}
	void OnGunJammed () {
		gunJammedText.gameObject.SetActive (true);
		gunIsJammed = true;
		Invoke ("UnjamGun", 1.5f);
	}
	void UnjamGun () {
		gunJammedText.gameObject.SetActive (false);
		gunIsJammed = false;
	}
	void GetShot () {
		if (!isDueling)
			return;
		isDueling = false;
		Invoke ("Die", 0.5f);
		gunshotSprite.SetActive (true);
	}
	void Die () {
		SceneManager.LoadScene ("death");
	}
	void ClearCountdownText () {
		duelCountdownText.text = "";
	}
	void PrepareToDuel () {
		finishButton.SetActive (true);
		throwButtons.SetActive (false);
		checkpointSprite.SetActive (false);
		duelSprite.SetActive (true);
		popupPanel.SetActive (true);
		optionsPanel.SetActive (false);
		popupText.text = "Hit SPACE to fire after the countdown finishes.\nFire too early and your gun will jam!";
		finishButtonText.text = "Let's go!";
		isPreparingToDuel = true;
		popupWindowTitle.text = "DUELING";
	}
	void Throw (string thing) {
		int otherThrow = Random.Range (0, 3);
		string otherThing;
		bool win = false;
		bool tie = false;
		switch (otherThrow) {
		case 0:
			otherThing = "rock";
			if (thing == "paper")
				win = true;
			else
				win = false;
			break;
		case 1:
			otherThing = "paper";
			if (thing == "scissors")
				win = true;
			else
				win = false;
			break;
		default:
			otherThing = "scissors";
			if (thing == "rock")
				win = true;
			else
				win = false;
			break;
		}
		if (thing == otherThing)
			tie = true;

		popupText.text = "SECURITY OFFICER throws " + otherThing.ToUpper () + ".\n";
		if (tie) {
			popupText.text += "It's a tie. What do you throw?";
		} else if (win) {
			popupText.text += "You win. The officer lets you through.";
			throwButtons.SetActive (false);
			finishButton.SetActive (true);
			finishButtonText.text = "LET'S GO";
		} else {
			popupText.text += "You lose. There's only one thing left to do.";
			throwButtons.SetActive (false);
			finishButton.SetActive (true);
			finishButtonText.text = "DUEL!";
			lostTheThrow = true;
		}
	}
}
