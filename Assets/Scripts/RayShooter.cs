using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RayShooter : MonoBehaviour {
	[SerializeField] private Camera _camera;
	private Animator animator;

	void Start() {
		//
		//_camera = GetComponent<Camera>();
		//input the camera using serial 
		animator = GetComponent<Animator>();
		//this.transform.position;
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}

	//keep this 
	void OnGUI() {
		//int size = 12;
		//float posX = _camera.pixelWidth/2 - size/4;
		//float posY = _camera.pixelHeight/2 - size/2;
		//GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	//
	void Update() {
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) {
			animator.SetBool ("startPunch", true);
			//Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			//Ray ray = _camera.ScreenPointToRay (point);

			//Vector3 slightlyAbovePosition = new Vector3(transform.forward.x, transform.forward.y + 3,transform.forward.z);

			Ray ray = new Ray(transform.position, transform.forward);

			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				//ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				AnimationReactiveTarget target = hitObject.GetComponent<AnimationReactiveTarget> ();
				if (target != null) {
					target.ReactToHit ();
					Messenger.Broadcast (GameEvent.ENEMY_HIT);
				} else {
					StartCoroutine (SphereIndicator (hit.point));
				}
			}
		}
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}
}