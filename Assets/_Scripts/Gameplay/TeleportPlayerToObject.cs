using System.Collections;
using System.Collections.Generic;
using Sanicball.Gameplay;
using UnityEngine;

public class TeleportPlayerToObject : MonoBehaviour {
	[SerializeField]
	public GameObject target;
	private void OnTriggerEnter(Collider other) {
		other.transform.position = target.transform.position;
		var bc = other.GetComponent<Ball>();
        if (bc != null) {
			bc.rb.angularVelocity = Vector3.zero;
			bc.rb.linearVelocity = Vector3.zero;
		}
	}
}
