using UnityEngine;
using System.Collections;

public class NethonScript : MonoBehaviour {
	
	public Vector3 force;
	
	private const float SPEED = 40f;
	private const float FRICTION = .9f;
	
	void OnMouseEnter ()
	{
		
		//
		// Turn off renderer
		//
			
		foreach (Transform child in transform) {
			foreach (Transform grandchild in child) {
				grandchild.GetComponent<ParticleRenderer> ().enabled = true;
			}
		}


	}
	
	void OnMouseExit ()
	{
		
		foreach (Transform child in transform) {
			
			foreach (Transform grandchild in child) {
				grandchild.GetComponent<ParticleRenderer>().enabled = false;
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		force = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (force != Vector3.zero) {
			
			//
			// Reduce force overtime
			//
			
			force *= FRICTION;
		}
		
		//
		// Update position
		//
		
		transform.Translate (Time.deltaTime * force * SPEED);
		
	}
}
