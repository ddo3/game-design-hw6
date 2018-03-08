using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using  System.Collections.Generic;

public class UIController : MonoBehaviour {
	[SerializeField] private Text scoreLabel;
	[SerializeField] private SettingsPopup settingsPopup;
	[SerializeField] private int zombieNum;
	[SerializeField] private List<GameObject> zombies;
	[SerializeField] private GameObject gameOverMenu; 


	private int _score;
	private GameOverUIController gameOverController; 

	void Awake() {
		Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}
	void OnDestroy() {
		Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	void Start() {
		_score = 0;
		scoreLabel.text = _score.ToString();

		settingsPopup.Close();

		gameOverController = this.GetComponent <GameOverUIController>();
		gameOverController.disableView ();
	}


	private bool allZombiesAreDead(){

		bool allDead = true;
		foreach (GameObject zombie in zombies){

			if (zombie.GetComponent<WanderingAI> ().isAlive ()) {
				allDead = false;
			}
		}

		return allDead;
	}

	void Update(){
		//if(allZombiesAreDead()){
		if (_score == 1){
			//for some reason, this is 
			gameOverController.activateMenu ();
		}
	}

	private void OnEnemyHit() {
		_score += 1;
		scoreLabel.text = _score.ToString();
	}

	public void OnOpenSettings() {
		settingsPopup.Open();
	}

	public void OnPointerDown() {
		Debug.Log("pointer down");
	}
}
