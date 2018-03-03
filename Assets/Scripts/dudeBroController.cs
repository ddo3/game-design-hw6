using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dudeBroController : MonoBehaviour {
	private int _health;
	Animator animator;
	// Use this for initialization
	void Start () {
		_health = 5;
		animator = GetComponent<Animator> ();
		//animator.SetBool ("isDead", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hurt(int damage) {
		_health -= damage;
		Debug.Log("Health: " + _health);
	}

}
