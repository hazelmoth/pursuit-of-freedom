using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildEnabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Transform[] children = GetComponentsInChildren<Transform> (true);
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
		transform.GetChild (Random.Range (0, transform.childCount)).gameObject.SetActive (true);
		Debug.Log (children.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
