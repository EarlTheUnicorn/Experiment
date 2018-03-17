using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover2 : MonoBehaviour {
		public float speed;

		private Rigidbody rb;

		void Start () {
			rb = GetComponent<Rigidbody> ();
			rb.velocity = transform.forward * speed;
		}

	}


