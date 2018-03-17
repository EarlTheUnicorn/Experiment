using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Boundary


{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;

	public float speed;
	public float tilt;
	public Boundary boundary;

	private float nextFire = 0.5F;
	public Transform ShotSpawn;
	public GameObject shot;
	public float fireRate = 0.5F;
	public GameObject playerBoom;
	public GameObject playerBoom2;
	public GameObject playerBoom3;
	public Transform tr;

	void Update() {

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, ShotSpawn.transform.position, ShotSpawn.transform.rotation);
		}

	}
	IEnumerator destroyPlayer() {
		//yield return new WaitForSeconds(.f);

		GetComponent<MeshRenderer>().enabled = false;
		tr = GetComponent<Transform> ();
		yield return new WaitForSeconds(.3f);
		Instantiate (playerBoom2, tr.transform.position, Quaternion.Euler (-90.0f, 0.0f, 0));
		yield return new WaitForSeconds(.3f);
		Instantiate (playerBoom3, tr.transform.position, Quaternion.Euler (-90.0f, 0.0f, 0));
		yield return new WaitForSeconds(.3f);
		Instantiate (playerBoom, tr.transform.position, Quaternion.Euler (-90.0f, 0.0f, 0));
		yield return new WaitForSeconds(.3f);
		Object.Destroy(gameObject);
		Object.Destroy(GameObject.Find("Player_Explosion_0.0.0_Stage_02(Clone)")); 
		Object.Destroy(GameObject.Find("Player_Explosion_0.0.0_Stage_03(Clone)")); 
		Object.Destroy(GameObject.Find("Player_Explosion_0.0.0_Stage_01(Clone)")); 

	}

	void FixedUpdate ()
	{     
		rb = GetComponent<Rigidbody> ();
		//for(int x; x<1000; x+28){
		//	}
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3 
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}


	void OnTriggerEnter(Collider other){

		//Debug.Log (other.name);

		if (other.tag == "Boundary") {
			return;
		} 

		StartCoroutine (destroyPlayer ());
		Destroy(other.gameObject);

	}

}