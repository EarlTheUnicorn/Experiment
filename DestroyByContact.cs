using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {


	public GameObject boom;
	public GameObject boom2;
	public GameObject boom3; 
	public int scoreValue;
	private Controller controller;


	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent <Controller>();
		}
		if (controller == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	IEnumerator destroy() {
		
		GetComponent<MeshRenderer>().enabled = false;

		Instantiate (boom, transform.position, transform.rotation);
		yield return new WaitForSeconds(.15f);
		Instantiate(boom2, transform.position, transform.rotation);
		yield return new WaitForSeconds(.15f);
		Instantiate(boom3, transform.position, transform.rotation);
		yield return new WaitForSeconds(.15f);
		Object.Destroy(GameObject.Find("Explosion_Effect_0.0.1_Stage_01(Clone)")); 
		Object.Destroy(GameObject.Find("Explosion_Effect_0.0.1_Stage_02(Clone)")); 
		Object.Destroy(GameObject.Find("Explosion_Effect_0.0.1_Stage_03(Clone)")); 
		Object.Destroy (gameObject);


	}
		



	void OnTriggerEnter(Collider other){
		int exp = 0;
		int lol = 0;
		Debug.Log (other.name);
		if (other.tag == "Boundary") {
			return;
		} 
		if (other.tag == "Player") {
			exp++;
			lol++;
			controller.GameOver ();

		}
		controller.UpdateScore (scoreValue);
		if (exp == 0){
			StartCoroutine (destroy ());

		}
		if (lol == 0) {
			Destroy (other.gameObject);
		}
}
}
