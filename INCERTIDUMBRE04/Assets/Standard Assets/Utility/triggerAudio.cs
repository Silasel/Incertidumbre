using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class triggerAudio: MonoBehaviour {
	public AudioClip interviewAudio;
	public AudioSource interviewClip;
	//public Animation anim;

	/*
	void Start() {
		interviewClip = GetComponent<AudioSource>();
	}
	*/

	//void OnCollisionEnter(){
	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Player") {
			//triggerAudio.SetActive (true);
			//interviewClip.PlayOneShot(interviewAudio, 1);
			interviewClip.Play ();
			//anim["dollAnimation"].speed = 1.0f;
			//anim.GetComponent<Animator>().Play("anim");
		}
		//interviewAudio.PlayClipAtPoint(interviewClip, transform.position);

		//interviewClip.Play();
		//audio.Play(44100);
	}
	void OnTriggerExit(Collider collider){
		interviewClip.Pause ();
		//anim["video"].speed = 0.0f;
	}
}