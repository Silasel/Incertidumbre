using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This is from YouTube video tutorial
public class chase : MonoBehaviour {
	//youtube
	public Transform player;
	static Animator anim;
	//unity in action
	public float speed = 1.5f;
	public float obstacleRange = 0.5f;
	//private bool _alive;

	// Use this for initialization
	void Start () {
		//_alive = true;//unity in action
		anim = GetComponent<Animator> ();//youtube
	}

	// Update is called once per frame
	void Update () {
		//unity in action
		//if (_alive) {
			transform.Translate (0, 0, speed * Time.deltaTime);

			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast (ray, 0.75f, out hit)) {
				if (hit.distance < obstacleRange) {
					float angle = Random.Range (-110, 110);
					transform.Rotate (0, angle, 0);
				}
			}//end unity in action

			//youtube
			//set the direction of the bad guy to the player
			Vector3 direction = player.position - this.transform.position;
			//give the bad guy a limited field of vision, rather than all around including back
			float angleTurn = Vector3.Angle (direction, this.transform.forward);

			//distance between player and ice, if less than 10 do something
			if (Vector3.Distance (player.position, this.transform.position) < 5 && angleTurn < 80) {
			

				//take y axis out so the bad guy doesn't tip back when Player is near
				direction.y = 0;
				//Rotate to player
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);

				//code to have the bad guy move, blue is z "zed" axis, forward - moves to player
				anim.SetBool ("isIdle", false);
				if (direction.magnitude > 3) {
					//walk or attack or idle based on proximity
					this.transform.Translate (0, 0, 0.5f);
					anim.SetBool ("isWalking", true);
					anim.SetBool ("isAttacking", false);
				} else {
					anim.SetBool ("isAttacking", true);
					anim.SetBool ("isWalking", false);
				}
			} else {
				anim.SetBool ("isIdle", true);
				anim.SetBool ("isWalking", false);
				anim.SetBool ("isAttacking", false);
			}
			//end youtube

		}
	//}
	/*
	public void SetAlive(bool alive) {
		_alive = alive;
	}
	*/

	}