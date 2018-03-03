using UnityEngine;
using System.Collections;


public class AnimationReactiveTarget : MonoBehaviour {
	Animator animator;

	void Start(){
		animator = GetComponent<Animator> ();
		animator.SetBool ("isDead", false);

	}

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();

		if (behavior != null) {
			behavior.SetAlive(false);
		}

		StartCoroutine(Die());
	}

	private IEnumerator Die() {

		animator.SetBool ("isDead", true);
		//this.transform.Rotate(-75, 0, 0);

		yield return new WaitForSeconds(1.5f);

		Destroy(this.gameObject);
	}
}


