using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIController : MonoBehaviour {


	[SerializeField] private GameObject gameOverMenu;

	private Canvas c;

	// Use this for initialization
	void Start () {
		disableView ();
	}

	public void disableView(){
		c = gameOverMenu.GetComponent<Canvas> ();

		c.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//c.enabled = false;
	}


	public void activateMenu(){
		c.enabled = true;
	}


}
