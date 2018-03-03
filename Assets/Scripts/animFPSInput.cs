using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animFPSInput : MonoBehaviour {

	public const float baseSpeed = 6.0f;

	public float speed = 6.0f;
	public float gravity = -9.8f;

	private CharacterController _charController;
	private Animator animator;

	private float previousDeltaX;
	private float previousDeltaZ;


	void Awake() {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}
	void OnDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void Start() {
		_charController = GetComponent<CharacterController>();
		animator = GetComponent<Animator> ();
		animator.SetBool ("startPunch", false);
		animator.SetBool ("isRunning", false);
		animator.SetBool ("gameOver", false);

		previousDeltaX = Input.GetAxis("Horizontal") * speed;
		previousDeltaZ = Input.GetAxis("Vertical") * speed;

	}

	private bool playerHasMoved(float x, float z){
		return (x != 0) && (z != 0);
	}


	void Update() {
		//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;

		if(playerHasMoved(deltaX, deltaZ)){
			animator.SetBool ("isRunning", true);

			Vector3 movement = new Vector3(deltaX, 0, deltaZ);
			movement = Vector3.ClampMagnitude(movement, speed);

			movement.y = gravity;

			movement *= Time.deltaTime;
			movement = transform.TransformDirection(movement);
			_charController.Move (movement);
		}else{
			animator.SetBool ("isRunning", false);
		}

	}

	private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
	}
}
