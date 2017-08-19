using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayShooter : MonoBehaviour {
	private Camera _camera;
	//get heart firing
	[SerializeField]
	GameObject heartprefab;

	void Start() {
		_camera = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
				} else {
					//StartCoroutine(SphereIndicator(hit.point));
					StartCoroutine(HeartIndicator(hit.point));
				}
			}
		}
	}

	//private IEnumerator SphereIndicator(Vector3 pos) {
	private IEnumerator HeartIndicator(Vector3 pos) {
		
		//Is Working to create bullet sphere
		/*
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;
		*/

		GameObject heart = Instantiate (heartprefab);
		heart.transform.position = pos; //the heart is shooting high!!!


		yield return new WaitForSeconds(3);

		Destroy(heart);
		//Destroy(sphere);
	}
}