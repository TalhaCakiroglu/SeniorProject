using UnityEngine;
using System.Collections;

public class Isınlanma : MonoBehaviour {
	public GameObject karakter;
	public Transform spawn;
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Biri değdi");
		karakter.transform.position = new Vector3(spawn.position.x, spawn.position.y, spawn.position.z + 0.7f);
	}

	void Update(){

	}
}
