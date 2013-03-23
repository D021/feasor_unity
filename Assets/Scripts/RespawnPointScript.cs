using UnityEngine;
using System.Collections;

public class RespawnPointScript : MonoBehaviour {
	
	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject.CompareTag ("Player")) {
			
			//
			// Set this as the new spawn point
			//
			
			other.gameObject.GetComponent<PlayerStatus>().spawnPoint = this.gameObject;
			
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
