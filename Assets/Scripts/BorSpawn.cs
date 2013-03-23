using UnityEngine;
using System.Collections;

public class BorSpawn : MonoBehaviour {
	
	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject.CompareTag ("Player")) {
			
			//
			// Reset position of bors
			//
			
			foreach (Transform child in transform) {
				
				if (child.gameObject.CompareTag ("Nethon")) {
					child.localPosition = Vector3.zero;
				}
			}
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
