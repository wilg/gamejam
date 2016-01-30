﻿using UnityEngine;
using System.Collections;

public class pathManager : MonoBehaviour {

	public AudioClip positiveSound;
	public AudioClip negativeSound;

	bool startNewPath;
	Ray ray;
	int i = 0;
	GameObject pathToSet;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			// Casts the ray and get the first game object hit
			Physics.Raycast(ray, out hit);
			if (hit.transform != null && hit.transform.gameObject.tag == "Player") {

				DayNightController.instance.BeginPreview (0);

				i = 0;
				startNewPath = true;
				pathToSet = hit.transform.gameObject;

				var person = pathToSet.GetComponent<Person> ();
				person.selected = true;
				person.ClearPaths ();
				DayNightController.instance.BeginPreview (0);

			} else if (hit.transform != null && startNewPath && hit.transform.gameObject.tag == "Building") {
				
				var person = pathToSet.GetComponent<Person> ();
				// Search the hit object or its parents
				Building building = hit.transform.gameObject.GetComponent<Building> ();
				if (!building) {
					building = hit.transform.parent.gameObject.GetComponent<Building> ();
				}
				if (building.Full ()) {

					AudioSource.PlayClipAtPoint (negativeSound, Camera.main.transform.position);
				} else {
					AudioSource.PlayClipAtPoint (positiveSound, Camera.main.transform.position);


					i++;
					if (i < person.Buildings().Length) {

						DayNightController.instance.BeginPreview (i * 4.0f / 24.0f);


						person.Buildings()[i] = building;

						// Debug.Log ("Advancing path to " + i.ToString());
						if (i == person.Buildings().Length - 1) {
							DayNightController.instance.EndPreview ();
							startNewPath = false;
							person.state = Person.State.walking;
							person.MoveToNext();
						}
					}


				}

			}
		}
	}
}
