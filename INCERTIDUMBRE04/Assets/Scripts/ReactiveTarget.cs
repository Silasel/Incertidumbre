using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	public void ReactToHit() {
		//comment to float up
		iceAI behavior = GetComponent<iceAI> ();
		//commented this out so that the target floats up and disappears when shot, instead of laying down and disappearing
		//but by turning this off does the game think it's still alive?
		if (behavior != null) {
			behavior.SetAlive(false);
		}
		//end comment to float up
		StartCoroutine (Die ());
	}

	private IEnumerator Die() {
		//float x = 100;
		//this.transform.Rotate(-75, 0, (x = ++x));
		this.transform.Rotate(-75, 0, 0);

		yield return new WaitForSeconds(3.5f);

		Destroy(this.gameObject);
	}
}