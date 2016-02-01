﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class tutorial : MonoBehaviour {

	public Texture2D introPerson;
	private bool hasIntroducedPerson;
	private bool showPersonGUI;


	public Texture2D introPath;
	private bool hasIntroducedPath;
	private bool showPathGUI;

	public Texture2D introPath2;
	private bool hasIntroducedPath2;
	private bool showPathGUI2;

	public Texture2D introHome;
	private bool hasIntroducedHome;
	private bool showHomeGUI;

	public Texture2D introHome2;
	private bool hasIntroducedHome2;
	private bool showHomeGUI2;

	public Texture2D introFood;
	private bool hasIntroducedFood;
	private bool showFoodGUI;

	public Texture2D introWork;
	private bool hasIntroducedWork;
	private bool showWorkGUI;

	public Texture2D introStar;
	private bool hasIntroducedStar;
	private bool showStarGUI;

	public Texture2D introUpgrade;
	private bool hasIntroducedUpgrade;
	private bool showUpgradeGUI;

	public static tutorial instance = null;

	Blur _blur;
	Stratecam _cam;
	// Use this for initialization
	void Start () {
		_blur = Camera.main.GetComponent<Blur> ();
		_cam = Camera.main.GetComponent<Stratecam> ();
	}

	void Awake (){
		instance = this;
	}

	float height = 290;
	float width = 529;

	public bool Active() {
		return showPersonGUI || showPathGUI || showPathGUI2 || showHomeGUI || showHomeGUI2 || showFoodGUI || showWorkGUI || showStarGUI || showUpgradeGUI;
	}

	void OnGUI() {
		if (showPersonGUI){
			GUI.DrawTexture(new Rect((Screen.width/2) - (width/2), Screen.height/2-(height/2), width, height), introPerson);
		}
		if (showPathGUI){
			GUI.DrawTexture(new Rect((Screen.width/2) - (width/2), Screen.height/2-(height/2), width, height), introPath);
		}
		if (showPathGUI2){
			GUI.DrawTexture(new Rect((Screen.width/2) - (width/2), Screen.height/2-(height/2), width, height), introPath2);
		}
		if (showHomeGUI){
			GUI.DrawTexture(new Rect((Screen.width/2) - (width/2), Screen.height/2-(height/2), width, height), introHome);
		}
		if (showHomeGUI2){
			GUI.DrawTexture(new Rect((Screen.width/2) - (width/2), Screen.height/2-(height/2), width, height), introHome2);
		}
		if (showFoodGUI){
			GUI.DrawTexture(new Rect((Screen.width/2) - (width/2), Screen.height/2-(height/2), width, height), introFood);
		}
		if (showWorkGUI){
			GUI.DrawTexture(new Rect((Screen.width/2) - (width/2), Screen.height/2-(height/2), width, height), introWork);
		}
		if (showStarGUI){
			GUI.DrawTexture(new Rect((Screen.width/2) - (width/2), Screen.height/2-(height/2), width, height), introStar);
		}
		if (showUpgradeGUI){
			GUI.DrawTexture(new Rect((Screen.width/2) - (width/2), Screen.height/2-(height/2), width, height), introUpgrade);
		}
	}

	void ShowTutorial() {
		_cam.useKeyboardInput = false;
		_cam.useMouseInput = false;
		DayNightController.instance.pauseNoPreview = true;
		_blur.enabled = true;

	}

	void HideTutorial() {
		_cam.useKeyboardInput = true;
		_cam.useMouseInput = true;
		DayNightController.instance.pauseNoPreview = false;
		_blur.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		if (!hasIntroducedPerson && GameObject.FindWithTag ("Player")) {
			kickOffIntroducePerson ();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			showPersonGUI = false;
			showPathGUI = false;
			showPathGUI2 = false;
			showHomeGUI = false;
			showHomeGUI2 = false;
			showFoodGUI = false;
			showWorkGUI = false;
			showStarGUI = false;
			showUpgradeGUI = false;
			StopAllCoroutines();
			_cam.objectToFollow = null;
			_cam.maxZoomDistance = 40;
			_cam.minZoomDistance = 10;
		}
		if (Input.GetMouseButtonUp(0)) {
			showPersonGUI = false;
			showPathGUI = false;
			showPathGUI2 = false;
			showHomeGUI = false;
			showHomeGUI2 = false;
			showFoodGUI = false;
			showWorkGUI = false;
			showStarGUI = false;
			showUpgradeGUI = false;
			_cam.objectToFollow = null;
			_cam.maxZoomDistance = 40;
			_cam.minZoomDistance = 10;
			HideTutorial();
		}
	}

	public void kickOffIntroducePerson(){
		if (!hasIntroducedPerson) {
			StartCoroutine(IntroducePerson());
			hasIntroducedPerson = true;
		}
	}


	public void kickOffIntroducePath(){
		if (!hasIntroducedPath) {
			StartCoroutine(IntroducePath());
			hasIntroducedPath = true;
		}
	}


	public void kickOffIntroduceHome(){
		if (!hasIntroducedHome) {
			StartCoroutine(IntroduceHome());
			hasIntroducedHome = true;
		}
	}


	public void kickOffIntroduceFood(){
		if (!hasIntroducedFood) {
			StartCoroutine(IntroduceFood());
			hasIntroducedFood = true;
		}
	}


	public void kickOffIntroduceWork(){
		if (!hasIntroducedWork) {
			StartCoroutine(IntroduceWork());
			hasIntroducedWork = true;
		}
	}


	public void kickOffIntroduceStar(){
		if (!hasIntroducedStar) {
			StartCoroutine(IntroduceStar());
			hasIntroducedStar = true;
		}
	}

	public void kickOffIntroduceUpgrade(){
		if (!hasIntroducedUpgrade) {
			IntroduceUpgrade();
			hasIntroducedUpgrade = true;
		}
	}


	IEnumerator IntroducePerson() {
		_cam.maxZoomDistance = 11;
		_cam.minZoomDistance = 10;
		_cam.objectToFollow = GameObject.FindWithTag("Player");
		yield return new WaitForSeconds (5);
		ShowTutorial();
		showPersonGUI = true;
		_cam.objectToFollow = null;
		_cam.maxZoomDistance = 40;
		_cam.minZoomDistance = 10;
		yield return new WaitForSeconds (5);
		showPersonGUI = false;
		HideTutorial();
		//StartCoroutine(IntroducePath());
	}

	IEnumerator IntroducePath() {
		yield return new WaitForSeconds (1);
		ShowTutorial();
		showPathGUI = true;
		yield return new WaitForSeconds (7);
		showPathGUI = false;

		showPathGUI2 = true;
		yield return new WaitForSeconds (5);
		showPathGUI2 = false;
		HideTutorial();
	}

	IEnumerator IntroduceHome() {
		ShowTutorial();
		_cam.maxZoomDistance = 11;
		_cam.minZoomDistance = 10;
		_cam.objectToFollow = GameObject.Find("Home (1)");
		yield return new WaitForSeconds (1);
		showHomeGUI = true;
		yield return new WaitForSeconds (8);
		showHomeGUI = false;
		showHomeGUI2 = true;
		_cam.objectToFollow = null;
		_cam.maxZoomDistance = 40;
		_cam.minZoomDistance = 10;
		HideTutorial();
		//StartCoroutine(IntroduceFood());
	}

	IEnumerator IntroduceFood() {
		ShowTutorial();
		_cam.maxZoomDistance = 11;
		_cam.minZoomDistance = 10;
		_cam.objectToFollow = GameObject.Find("Noodle Shop");
		yield return new WaitForSeconds (1);
		showFoodGUI = true;
		_cam.objectToFollow = null;
		_cam.maxZoomDistance = 40;
		_cam.minZoomDistance = 10;
		yield return new WaitForSeconds (5);
		showFoodGUI = false;
		HideTutorial();
		//StartCoroutine(IntroduceWork());
	}

	IEnumerator IntroduceWork() {
		ShowTutorial();
		_cam.maxZoomDistance = 11;
		_cam.minZoomDistance = 10;
		_cam.objectToFollow = GameObject.Find("Star Factory");
		yield return new WaitForSeconds (1);
		showWorkGUI = true;
		_cam.objectToFollow = null;
		_cam.maxZoomDistance = 40;
		_cam.minZoomDistance = 10;
		yield return new WaitForSeconds (5);
		showWorkGUI = false;
		HideTutorial();
		//StartCoroutine(IntroduceStar());
	}

	IEnumerator IntroduceStar() {
		ShowTutorial();
		_cam.maxZoomDistance = 11;
		_cam.minZoomDistance = 10;
		_cam.objectToFollow = GameObject.Find("StarResource");
		yield return new WaitForSeconds (1);
		_cam.objectToFollow = null;
		_cam.maxZoomDistance = 40;
		_cam.minZoomDistance = 10;
		showStarGUI = true;
		HideTutorial();
		kickOffIntroduceUpgrade ();
	}

	void IntroduceUpgrade() {
		ShowTutorial();
		showUpgradeGUI = true;
		HideTutorial();
	}
		
}
