using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RayShooter : MonoBehaviour {
	[SerializeField] private Camera _camera;
	private Animator animator;
	[SerializeField] private Sprite xHair;

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

		/*
		RaycastHit hit; //raycast from player forward  
		Physics.Raycast(transform.position,transform.forward,out hit);  
		//align crosshair to appear in front of environment  
		xHair.transform.rotation = Quaternion.LookRotation(hit.normal);  
		Vector3 offset = new Vector3(0, 0, 0.05f);  
		reticle.transform.position = hit.point + (xHair.transform.rotation   * offset);  

		//fire sphere with mouse  
		if (Input.GetMouseButtonDown(0)) {    
			StartCoroutine(SphereIndicator(hit.point)); 
		}
	*/


		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) {
			
			//Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			//Ray ray = _camera.ScreenPointToRay (point);

			//Vector3 slightlyAbovePosition = new Vector3(transform.forward.x, transform.forward.y + 3,transform.forward.z);

			Ray ray = new Ray (transform.position, transform.forward);

			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				//ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				AnimationReactiveTarget target = hitObject.GetComponent<AnimationReactiveTarget> ();
				if (target != null) {
					target.ReactToHit ();
					Messenger.Broadcast (GameEvent.ENEMY_HIT);
				} 
				animator.SetTrigger ("punch");
				StartCoroutine (SphereIndicator (hit.point));

			}

		}

	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.GetComponent<Renderer> ().material.color = new Color (1, 0, 0);

		sphere.transform.position = pos;

		sphere.transform.position = new Vector3(sphere.transform.position.x, sphere.transform.position.y + 1f, sphere.transform.position.z);

		yield return new WaitForSeconds(1);

		Destroy(sphere);

	}
}