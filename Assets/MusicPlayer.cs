using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else
			Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
