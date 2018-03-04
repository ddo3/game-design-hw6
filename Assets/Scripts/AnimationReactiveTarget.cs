using UnityEngine;
using System.Collections;


public class AnimationReactiveTarget : MonoBehaviour {
	private Animator animator;

	void Start(){
		animator = GetComponent<Animator> ();
		animator.SetBool ("isDead", false);
		//animator.SetBool ();
	}

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();

		if (behavior != null) {
			behavior.SetAlive(false);
		}

		animator.SetBool ("isDead", true);

	}

	private IEnumerator Die() {

		yield return new WaitForSeconds(1.5f);

		Destroy(this.gameObject);
	}
}


